# ZRC_ARPG — 基于 Unity 的联机动作 RPG 客户端

> 仿《绝区零》(ZZZ) 的 3D 联机动作角色扮演游戏客户端，配合自研权威服务器实现完整联机战斗体验。

---

## 项目概览

| 项目 | 说明 |
|---|---|
| **引擎** | Unity 2022.3.8f1c1 + URP 渲染管线 |
| **定位** | 3D 联机动作 RPG（ARPG），支持多人同房间战斗 |
| **核心玩法** | 3 人队伍切人战斗、技能连招、闪避格挡、角色养成、任务对话、社交系统 |
| **配套服务器** | [Server-main](https://github.com/your-username/Server-main)（C# .NET 8 权威服务器） |

---

## 技术栈

| 领域 | 技术 | 说明 |
|---|---|---|
| 引擎/管线 | Unity 2022.3 + URP | |
| 资源/热更 | **YooAsset** | 编辑器模拟/单机/联机/WebGL 四种运行模式 |
| 异步 | **UniTask** | 零 GC 协程替代，贯穿全项目异步流程 |
| 输入 | Unity Input System | 生成 `GameInput`，支持 Down/Up/Press 三阶段 |
| 镜头 | Cinemachine | 战斗/切人/对话/支援多相机切换 |
| UI 动画 | DOTween | 面板入场/退场/弹窗动画 |
| 脚本热更 | **XLua** | Buff 逻辑用 Lua 实现，支持发版后热更平衡性 |
| 配置表 | **Luban** | Schema + JSON → C# 强类型代码生成，22 张配置表 |
| 网络协议 | **Protobuf + 自研二进制协议** | TCP 长连接，14B 固定头 + Protobuf Body |
| 数据库 | MongoDB（服务器侧） | 玩家数据持久化 |

---

## 核心系统

### 1. 自研 Timeline 动作系统（项目最大亮点）

**设计思想**：用 Unity Timeline 做「动作编辑器 + 数据容器」，但运行时不跑 PlayableGraph，而是自写轻量解释器。

- 每个动作 = 一个 `KiraraActionSO`（继承 `TimelineAsset`），携带动画轨道、自定义轨道（命中盒/粒子/音效/相机）及元数据（动作类型、跳转表、参数等）
- 播放前 `ActionUnpacker.Unpack()` 把 Timeline 拍平成按时间排序的三个列表：`Notify`（瞬时标记）、`NotifyState`（区间）、`EnterTrack`（起始触发）
- 动画由 `Animator.CrossFadeInFixedTime` 播放，动作逻辑/通知/跳转由 `ActionCtrl` 自己的 `Time` 游标在 `Update()` 推进

**输入驱动的动作跳转**：
- 指令类型：Move / Dodge / BaseAttack / SpecialAttack / Ultimate
- 跳转优先级：当前动作指令跳转表 → 时间窗口内取消/连招窗口 → 继承动作跳转表（公共招式复用）→ 能量谓词判定
- **输入缓冲**：`Deque<InputBufferItem>(128)` 预输入队列，带时间戳，1s 过期，保证连招手感

**自定义通知轨道**：BoxNotifyState（命中盒）、AttackingNotifyState、ControlDodgeNotifyState（无敌帧）、ControlParryAidNotifyState（格挡帧）、ConsumeEnergyNotify、HitstopNotify（顿帧）、CameraShakeMarker（震屏）、ParticleControlTrack、RandomAudioTrack 等

### 2. 战斗系统

- **RoleCtrl**：角色战斗中枢，串联动画/镜头/移动/网络/Buff/特效；Root Motion 驱动移动，相机相对方向转向
- **PlayerSystem**：3 人队伍 + 切人系统，切人时自动绑定 Cinemachine 相机；每 16ms 上报队伍位置给服务器
- **伤害结算管线**：客户端命中检测（`Physics.OverlapSphere/Box`）→ 读配置表算伤害（攻击×倍率×暴击×增伤）→ 上报服务器 → 播命中表现（粒子/音效/顿帧）
- **格挡/完美闪避**：切人格挡支援切入；完美闪避用 `Physics.OverlapCapsule` 检测闪避判定盒
- **顿帧 Hitstop**：命中时 `ActionCtrl.Speed = 0`，UniTask 延时恢复，增强打击感

### 3. 网络通信框架

- **自研二进制协议（MyProtocol）**：`[MagicNum 2B][Len 4B][CmdId 4B][RpcSeq 4B][Protobuf Body]`，大端序，14B 固定头
- **环形缓冲 `MyBuffer`** 处理 TCP 粘包/拆包，magicNum 校验非法包
- **Handler 反射自动扫描注册**：`KiraraNetwork.Scan(assembly)` 遍历程序集，自动映射 CmdId → Handler，新增消息零注册代码
- **RPC 机制**：自增 seq + 回调字典，`CallAsync<T>` 用 `UniTaskCompletionSource` 包装成 await 强类型 API
- **统一错误拦截**：响应 `Code != 0` 直接抛 `ResultException`，业务层 try/catch 统一处理
- **心跳与时间同步**：每 1s Ping/Pong 算 RTT，估算服务器时间 `serverTime = pong.UnixTimeMs + rtt/2`

### 4. 配置驱动与角色养成

- **Luban 配置表**：22 张 JSON 表生成 C# 强类型类，覆盖属性、动作数值、命中数值、货币材料、对话图、驱动盘/词条、怪物、NPC、任务链、角色、武器等
- **多层属性公式**：一级属性（攻击力等）= 基础值 + Buff增量 + 白值×(1+百分比) + 固定值；二级属性（暴击率/增伤等）= 基础值 + Buff增量；惰性求值，读属性时实时叠加所有 Buff
- **一切皆 Buff**：武器（主副属性+被动）、驱动盘（6 槽主副词条）、套装效果（2件/4件）、能量恢复统一建模为 Buff 挂在 `AttrBuffSet` 上，装备变更即增减 Buff
- **XLua 热更 Buff**：C# 侧 `IBuffComponent` 接口 + `AttrBuffSet` 管理生命周期；Lua 侧 `BuffComponent.lua` 基类（层数/刷新策略/钩子 OnUpdate/OnActionStart/OnAttackHit）+ 具体 Buff 定义；易变数值逻辑放 Lua 支持发版后热更

### 5. UI 框架

- **三层 Canvas 面板栈**：HUD(0) / Normal(1) / Top(2)，各自独立栈，入栈自动 Pause 上一个，出栈恢复
- **面板基类**：`AbstractBasePanel` 生命周期（PlayEnter/PlayExit/OnPause/OnResume）+ `BasePanel`（DirectBinder 绑定 + DOTween 动画）
- **KiraraDirectBinder（组件直绑）**：运行时 `b.Q<T>(index, "fieldName")` 取组件，同时校验索引/字段名/类型，替代层层 GetComponent
- **KiraraLoopScroll（循环滚动列表）**：对象池 + 虚拟化，只实例化可视区 Item，Deque 管理首尾索引，支撑几百件物品大列表恒定内存
- **LiveData\<T\>**：可观察数据 holder（类似 Android LiveData），Value 变化通知订阅者，实现「选中项 → 详情面板」响应式联动
- **23 个业务面板**：背包、驱动盘升级、聊天、对话、任务、兑换、设置、登录、角色详情、社交、战斗 HUD、飘字等

### 6. 编辑器工具链（工程化闭环）

- **动作编辑器**：`ActionListWindow` / `ActionDetailsWindow` / `ActionTimelineWindow` 自定义窗口，支持搜索、切换、Timeline 联动预览
- **KiraraActionSOInspector**：自定义 Inspector，展示动作参数、跳转关系与反向引用
- **BoxNotifyStateInspector**：命中盒可视化编辑，Scene 视图画 Gizmo
- **⭐ 动作提取器（ActionExtractorWindow）**：选中 `KiraraActionSO` 一键导出 JSON——从 AnimationClip 按 60fps 采样 Root Motion 曲线（位移+旋转），提取命中盒时间轴；导出的 JSON 供服务器 `ActionMgr` 加载重放，**同一份动作数据同时驱动客户端表现和服务器权威判定**

### 7. 其他玩法系统

- **任务系统**：多态设计（6 种任务子类：击败/前往/收集/升级/对话/进度）+ 任务链串联推进 + 配置驱动 + NPC 行为覆盖
- **对话系统**：自定义节点图 `MyNodeGraph` 编辑对话流程 + 配置表存句子/选项分支 + 黑板记录选择；CinemachineTargetGroup 自动挑选最近机位
- **交互与 NPC**：`IInteractable` 接口 + 对话/拾取/开面板/采集材料实现
- **社交系统**：好友（搜索/申请/接受/拒绝/删除）、聊天（发送/拉取记录）、个性签名/头像

---

## 项目结构（核心目录）

```
Assets/Scripts/
├── TimelineAction/          # 自研动作系统（ActionCtrl / KiraraActionSO / ActionUnpacker）
├── TimelineActionCustom/    # 自定义通知轨道（命中盒/无敌帧/顿帧/粒子/音效等）
├── Role/                    # 角色控制器 RoleCtrl
├── System/                  # PlayerSystem 队伍编排
├── SceneManager/            # AttackProcessManager 伤害管线
├── Network/                 # 网络通信（Session / MyProtocol / KiraraNetwork / NetMsgProcessor）
├── Manager/                 # 基础设施 Manager（UIMgr / NetMgr / ConfigMgr / LuaMgr / EventMgr 等）
├── AttrBuff/                # 属性系统 + Buff 管理
├── UI/                      # 面板基类 + 23 个业务面板
├── AssetModule/             # YooAsset 热更 PatchController
├── ActionExtractor/         # 动作提取器（导出 JSON 给服务器）
├── KiraraDirectBinder/      # 组件直绑工具
├── KiraraLoopScroll/        # 循环滚动列表
└── Utils/                   # LiveData / UnitySingleton 等工具
```

---

## 启动流程

```
BootScene.Start()
  → UIMgr.PushPanel<BootPanel>()
  → BootPanel.Boot()（UniTask 异步流水线）
      ├─ 设置分辨率
      ├─ YooAssets.Initialize()
      ├─ PatchController.PatchAsync()（资源热更 6 步状态机）
      ├─ NetMgr.Init() / ConnectAsync()（连服务器）
      ├─ LuaMgr.Init()（XLua 环境）
      ├─ ConfigMgr.LoadTables()（Luban 配置表）
      ├─ 点击登录 → PlayerService.FetchData()（拉玩家数据）
      ├─ SettingsMgr.Init(uid)
      └─ 进入 → LoadSceneMgr.LoadScene(MainScene)
```

---

## 与服务器的联动闭环

```
Timeline 可视化编辑动作 (KiraraActionSO)
   ├─ 运行时：ActionUnpacker 拍平 → ActionCtrl 解释执行（客户端表现）
   └─ 提取器：导出 RootMotion + 命中盒 JSON → 服务器 ActionMgr 加载
                                          → ActionPlayer 重放（服务器权威判定）
```

**同一份动作数据同时驱动客户端表现和服务器判定**，这是整个战斗联机方案的基石。

---

## 技术亮点总结

1. **自研 Timeline 动作系统**：复用 Timeline 可视化编辑 + 自写运行时解释器；输入缓冲 + 多类型跳转（指令/信号/继承/时间窗口）；数据驱动替代硬编码状态机
2. **端到端权威战斗方案**：一份动作数据（RootMotion + 命中盒）由提取器导出，客户端表现 + 服务器重放判定共用；服务器单线程 tick + Recast 寻路 + 权威命中/格挡/闪避
3. **完整工程化**：YooAsset 热更、Luban 配表、Protobuf + 自研协议、代码生成（Handler 反射注册 / NetFn 强类型 RPC）、编辑器工具链、C# ↔ Lua 热更 Buff

---

## 配套仓库

- **服务器端**：[Server-main](https://github.com/Ahri-MIko/GraduationProject_Server) — C# .NET 8 权威游戏服务器

---

*注：美术资源、模型、动作及部分插件源码来自外部素材/二创整合，非个人产出。核心代码（动作系统、网络框架、战斗管线、服务器、编辑器工具链等）为个人实现。*
