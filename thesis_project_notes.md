# 项目梳理笔记

## 1. 项目定位

- 项目类型：Unity 3D 动作角色扮演游戏（ARPG）
- 引擎版本：Unity 2022.3.8f1c1
- 渲染管线：URP
- 主要运行流程：`BootScene -> 资源更新/网络连接/脚本初始化/配置加载 -> MainScene`

## 2. 技术栈

- 资源管理与热更新：YooAsset
- 异步任务：UniTask
- 输入系统：Unity Input System
- 镜头系统：Cinemachine
- UI 动画：DOTween
- Lua 热更/脚本层：XLua
- 配置表：Luban 生成表结构 + JSON 配置
- 网络协议：Google Protobuf
- 自研模块：
  - Timeline 动作系统与动作编辑辅助工具
  - UI 框架与面板栈管理
  - KiraraDirectBinder 组件直绑工具
  - KiraraLoopScroll 循环滚动列表
  - 战斗状态与角色控制系统
  - 属性 Buff 与装备系统

## 3. 当前仓库中可量化的工作量

以下统计尽量排除了 `.g.cs`、`Message.cs`、配置表生成代码、`Backup` 目录等明显不适合直接当作个人代码量的部分。

- 自研 UI 模块：82 个 C# 文件，约 5584 行
- TimelineAction 模块：35 个 C# 文件，约 1851 行
- ActionEditor 模块：24 个 C# 文件，约 1708 行
- KiraraLoopScroll 模块：15 个 C# 文件，约 1485 行
- TimelineActionCustom 模块：27 个 C# 文件，约 1079 行
- CombatStateMachine 模块：32 个 C# 文件，约 896 行
- KiraraDirectBinder 模块：11 个 C# 文件，约 762 行
- Manager 模块：12 个 C# 文件，约 729 行
- UI 预制体数量：74
- Panel 脚本数量：23
- 动作资源数量：154
- 配置表 JSON 数量：22
- Lua 脚本数量：8
- 场景数量：7

## 4. 最能体现个人工作量的模块

### 4.1 自研动作系统与战斗驱动

这是目前最适合在论文中重点展开的部分。

- 关键文件：
  - `Assets/Scripts/TimelineAction/Runtime/ActionCtrl.cs`
  - `Assets/Scripts/TimelineAction/Runtime/ActionUnpacker.cs`
  - `Assets/Scripts/TimelineAction/Runtime/KiraraActionSO.cs`
  - `Assets/Scripts/TimelineActionCustom/...`
  - `Assets/Scripts/System/PlayerSystem.cs`
  - `Assets/Scripts/Role/RoleCtrl.cs`
  - `Assets/Scripts/CombatStateMachine/...`
- 可写点：
  - 基于 Timeline 资产定义角色动作
  - 将动作播放、输入缓冲、动作跳转、信号跳转统一收敛到 `ActionCtrl`
  - 支持普通攻击、闪避、特殊技、大招、切人、格挡支援等动作分支
  - 动作通知扩展为命中盒、攻击提示、粒子、耗能等自定义轨道/标记
  - 角色控制、镜头跟随、朝向修正、锁敌倾向与战斗表现联动

为什么这个部分很强：

- 不只是“播放动画”，而是做了动作资源组织、运行时解释、输入驱动跳转、战斗盒检测、表现通知和镜头协同。
- 这类系统兼具架构设计、玩法逻辑和工具支持，论文很容易写出“设计与实现”深度。

### 4.2 动作编辑与内容生产工具链

这部分非常适合体现“你不仅实现玩法，还提升了制作效率”。

- 关键文件：
  - `Assets/Scripts/TimelineAction/Editor/ActionListWindow.cs`
  - `Assets/Scripts/TimelineAction/Editor/ActionDetailsWindow.cs`
  - `Assets/Scripts/TimelineAction/Editor/KiraraActionSOInspector.cs`
  - `Assets/Scripts/ActionExtractor/Editor/ActionExtractorWindow.cs`
- 可写点：
  - 自定义动作列表窗口，支持搜索、动作切换、与 Timeline 联动预览
  - 自定义 Inspector，展示动作参数、动作跳转关系、反向引用
  - 动作提取器可从 Timeline/AnimationClip 中导出 RootMotion 和命中盒数据
  - 形成“编辑器配置 -> 运行时执行 -> 数据提取导出”的闭环

这一点对毕业设计很加分，因为它说明你不是只堆功能，而是在做工具化和工程化。

### 4.3 UI 框架与界面系统

项目 UI 量很大，而且不是简单单页。

- 关键文件：
  - `Assets/Scripts/Manager/UIMgr.cs`
  - `Assets/Scripts/UI/Panel/BasePanel.cs`
  - `Assets/Scripts/UI/Panel/AbstractBasePanel.cs`
  - `Assets/Scripts/UI/Panel/InventoryPanel.cs`
  - `Assets/Scripts/UI/Panel/QuestPanel.cs`
  - `Assets/Scripts/UI/Panel/DialoguePanel.cs`
  - `Assets/Scripts/UI/Panel/SocialPanel.cs`
- 体现点：
  - HUD / Normal / Top 三层 UI 栈管理
  - 面板入栈/出栈、暂停/恢复、过渡动画统一封装
  - 背包、任务、对话、社交、设置、角色详情等多个系统化面板
  - 结合自研循环滚动列表和数据绑定工具，降低复杂列表界面的实现成本

这部分适合在论文里写成“人机交互与系统界面设计”章节。

### 4.4 自研 UI 开发效率工具

#### KiraraDirectBinder

- 关键文件：
  - `Assets/Scripts/KiraraDirectBinder/Runtime/KiraraDirectBinder.cs`
  - `Assets/Scripts/KiraraDirectBinder/Editor/KiraraDirectBinderWindow.cs`
- 作用：
  - 通过索引 + 字段名快速绑定组件
  - 提供编辑器窗口自动维护绑定项
  - 减少传统 `GetComponent`/手工拖引用成本

#### KiraraLoopScroll

- 关键文件：
  - `Assets/Scripts/KiraraLoopScroll/Runtime/Scroller.cs`
  - `Assets/Scripts/KiraraLoopScroll/Runtime/GridScrollView.cs`
  - `Assets/Scripts/KiraraLoopScroll/Runtime/LinearScrollView.cs`
- 作用：
  - 自定义循环滚动、惯性、回弹、对齐、无限滚动
  - 支撑背包、任务链等复杂列表展示

这两个模块很适合包装成“为复杂 UI 开发设计的通用基础设施”。

### 4.5 配置表驱动的角色、装备与 Buff 系统

- 关键文件：
  - `Assets/Scripts/Manager/ConfigMgr.cs`
  - `Assets/Scripts/Model/Role.cs`
  - `Assets/Scripts/AttrBuff/AttrBuffSet.cs`
  - `Assets/Scripts/Service/DiscService.cs`
  - `Assets/Scripts/Service/InventoryService.cs`
  - `Assets/LuaScripts/Buff/BuffComponent.lua.txt`
  - `Assets/LuaScripts/Buff/ConfigBuff_Role.lua.txt`
- 体现点：
  - 角色、武器、驱动盘、对话、任务均由配置表驱动
  - 属性集支持基础值、Buff 叠加、装备加成
  - 驱动盘套装效果、武器被动、能量恢复等都可配置化扩展
  - C# 与 Lua 协同实现 Buff 逻辑，保留一定热更新能力

如果论文题目偏“系统设计与实现”，这一块可以作为数据驱动设计的重要章节。

### 4.6 网络同步与多人/社交要素

- 关键文件：
  - `Assets/Scripts/Manager/NetMgr.cs`
  - `Assets/Scripts/Network/Common/Session.cs`
  - `Assets/Scripts/Network/Common/KiraraNetwork.cs`
  - `Assets/Scripts/Network/Client/NetMsgProcessor.cs`
  - `Assets/Scripts/NetHandler/...`
  - `Assets/Scripts/System/SimPlayerSystem.cs`
  - `Assets/Scripts/Model/SimPlayer.cs`
  - `Assets/Scripts/Service/SocialService.cs`
- 体现点：
  - Protobuf 消息收发与 RPC 回调处理
  - 客户端消息分发器与 Handler 自动扫描注册
  - 其他玩家状态同步、动作同步、模拟玩家渲染
  - 好友与聊天模块

需要注意：

- 当前仓库里主要是客户端实现，服务器代码不在仓库中。
- 论文里如果要写“网络模块”，要明确你负责的是客户端协议处理、同步表现和业务联动，避免把不存在于仓库的后端部分写得过满。

### 4.7 启动流程、资源更新与工程化

- 关键文件：
  - `Assets/Scripts/UI/Panel/BootPanel.cs`
  - `Assets/Scripts/AssetModule/PatchController.cs`
  - `Assets/Scripts/Manager/LuaMgr.cs`
  - `Assets/Scripts/Manager/SettingsMgr.cs`
- 体现点：
  - 启动阶段串联资源更新、网络连接、Lua 初始化、配置表加载、玩家数据拉取
  - 使用 YooAsset 处理不同播放模式和资源补丁流程
  - 启动异常与重试对话框逻辑较完整

这部分适合写“系统初始化流程设计”或“客户端启动与资源管理”。

## 5. 可作为论文章节的结构建议

如果按“系统设计与实现类”毕业论文写法，可以这样组织：

1. 绪论
2. 相关技术与开发工具
3. 系统需求分析
4. 系统总体设计
5. 核心功能模块设计与实现
6. 系统测试与结果分析
7. 总结与展望

其中第 5 章最适合重点写下面 4 个部分：

1. 动作战斗系统设计与实现
2. UI 框架与交互系统设计与实现
3. 配置表与角色养成系统设计与实现
4. 资源热更新与网络同步模块设计与实现

## 6. 目前我对项目的初步判断

### 最应该重点突出

- 自研 Timeline 动作系统
- 战斗行为与动作通知扩展
- 自定义编辑器工具链
- UI 框架与大规模界面实现
- 配置驱动的角色/装备/Buff 系统

### 可以作为辅助亮点

- 资源更新与启动流程
- Lua 热更新尝试
- 社交/聊天/多人同步
- 自研循环滚动与绑定工具

### 不建议作为“个人核心工作量”主讲

- 第三方资源包、美术资源、插件源码
- 自动生成的 Protobuf 文件
- Luban 自动生成的配置类
- `Backup` 中已废弃或注释掉的旧代码

## 7. 后续写论文前需要确认的事实

这些内容会影响论文表述是否准确：

- 这个项目是你独立完成，还是多人协作完成客户端？
- 网络后端是否也是你写的？如果不是，论文中应只写客户端部分。
- 美术资源、模型、动作资源是否主要来自外部素材包或二创整合？
- 你的论文题目最终是偏“动作游戏系统设计与实现”，还是偏“基于 Unity 的 ARPG 游戏设计与开发”？

## 8. 现阶段可直接下结论的写作方向

如果不等你补充信息，我也可以先按下面这个方向起草初稿：

“基于 Unity 的 3D 动作角色扮演游戏客户端设计与实现”

这个题目下，你的核心创新/工作量可以概括为：

- 设计并实现了基于 Timeline 的角色动作与战斗驱动系统
- 构建了支持面板栈管理的 UI 框架与多种游戏界面
- 实现了配置表驱动的角色、装备、Buff 与任务系统
- 完成了客户端资源更新、网络通信与部分社交功能集成

