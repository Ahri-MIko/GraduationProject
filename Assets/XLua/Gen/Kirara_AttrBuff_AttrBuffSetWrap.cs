#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class KiraraAttrBuffAttrBuffSetWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Kirara.AttrBuff.AttrBuffSet);
			Utils.BeginObjectRegister(type, L, translator, 0, 9, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttr", _m_GetAttr);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveBuff", _m_RemoveBuff);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTimer", _m_SetTimer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasTimer", _m_HasTimer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AttachBuff", _m_AttachBuff);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Inject", _m_Inject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnActionStart", _m_OnActionStart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAttackHit", _m_OnAttackHit);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Buffs", _g_get_Buffs);
            
			
			
			Utils.EndObjectRegister(type, L, translator, __CSIndexer, __NewIndexer,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new Kirara.AttrBuff.AttrBuffSet();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Kirara.AttrBuff.AttrBuffSet constructor!");
            
        }
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __CSIndexer(RealStatePtr L)
        {
			try {
			    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				
				if (translator.Assignable<Kirara.AttrBuff.AttrBuffSet>(L, 1) && translator.Assignable<cfg.main.EAttrType>(L, 2))
				{
					
					Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
					cfg.main.EAttrType index;translator.Get(L, 2, out index);
					LuaAPI.lua_pushboolean(L, true);
					LuaAPI.lua_pushnumber(L, gen_to_be_invoked[index]);
					return 2;
				}
				
				if (translator.Assignable<Kirara.AttrBuff.AttrBuffSet>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					
					Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
					int index = LuaAPI.xlua_tointeger(L, 2);
					LuaAPI.lua_pushboolean(L, true);
					LuaAPI.lua_pushnumber(L, gen_to_be_invoked[index]);
					return 2;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			
            LuaAPI.lua_pushboolean(L, false);
			return 1;
        }
		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __NewIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
			try {
				
				if (translator.Assignable<Kirara.AttrBuff.AttrBuffSet>(L, 1) && translator.Assignable<cfg.main.EAttrType>(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3))
				{
					
					Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
					cfg.main.EAttrType key;translator.Get(L, 2, out key);
					gen_to_be_invoked[key] = LuaAPI.lua_tonumber(L, 3);
					LuaAPI.lua_pushboolean(L, true);
					return 1;
				}
				
				if (translator.Assignable<Kirara.AttrBuff.AttrBuffSet>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3))
				{
					
					Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
					int key = LuaAPI.xlua_tointeger(L, 2);
					gen_to_be_invoked[key] = LuaAPI.lua_tonumber(L, 3);
					LuaAPI.lua_pushboolean(L, true);
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			
			LuaAPI.lua_pushboolean(L, false);
            return 1;
        }
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttr(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _type = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAttr( _type );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<cfg.main.EAttrType>(L, 2)) 
                {
                    cfg.main.EAttrType _type;translator.Get(L, 2, out _type);
                    
                        var gen_ret = gen_to_be_invoked.GetAttr( _type );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Kirara.AttrBuff.AttrBuffSet.GetAttr!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _dt = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.Update( _dt );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveBuff(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _buffName = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.RemoveBuff( _buffName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTimer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _handle = LuaAPI.lua_tostring(L, 2);
                    float _time = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.SetTimer( _handle, _time );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasTimer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _handle = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.HasTimer( _handle );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AttachBuff(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.AttachBuff( _name );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Collections.Generic.Dictionary<cfg.main.EAttrType, double>>(L, 3)) 
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.Dictionary<cfg.main.EAttrType, double> _attrs = (System.Collections.Generic.Dictionary<cfg.main.EAttrType, double>)translator.GetObject(L, 3, typeof(System.Collections.Generic.Dictionary<cfg.main.EAttrType, double>));
                    
                    gen_to_be_invoked.AttachBuff( _name, _attrs );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Kirara.AttrBuff.AttrBuffSet.AttachBuff!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Inject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _buffName = LuaAPI.lua_tostring(L, 2);
                    string _varName = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = gen_to_be_invoked.Inject( _buffName, _varName );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnActionStart(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Kirara.AttrBuff.OnActionStartContext _ctx = (Kirara.AttrBuff.OnActionStartContext)translator.GetObject(L, 2, typeof(Kirara.AttrBuff.OnActionStartContext));
                    
                    gen_to_be_invoked.OnActionStart( _ctx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnAttackHit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Kirara.AttrBuff.OnAttackHitContext _ctx = (Kirara.AttrBuff.OnAttackHitContext)translator.GetObject(L, 2, typeof(Kirara.AttrBuff.OnAttackHitContext));
                    
                    gen_to_be_invoked.OnAttackHit( _ctx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Buffs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Kirara.AttrBuff.AttrBuffSet gen_to_be_invoked = (Kirara.AttrBuff.AttrBuffSet)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Buffs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
