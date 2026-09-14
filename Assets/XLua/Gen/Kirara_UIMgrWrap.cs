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
    public class KiraraUIMgrWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Kirara.UIMgr);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PushPanel", _m_PushPanel);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PopPanel", _m_PopPanel);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PopAllPanel", _m_PopAllPanel);
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
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
					
					var gen_ret = new Kirara.UIMgr();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Kirara.UIMgr constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushPanel(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.UIMgr gen_to_be_invoked = (Kirara.UIMgr)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Kirara.UILayer>(L, 3)) 
                {
                    string _location = LuaAPI.lua_tostring(L, 2);
                    Kirara.UILayer _layer;translator.Get(L, 3, out _layer);
                    
                        var gen_ret = gen_to_be_invoked.PushPanel( _location, _layer );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _location = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.PushPanel( _location );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Kirara.UIMgr.PushPanel!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopPanel(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.UIMgr gen_to_be_invoked = (Kirara.UIMgr)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<Kirara.UI.Panel.AbstractBasePanel>(L, 2)&& translator.Assignable<Kirara.UILayer>(L, 3)) 
                {
                    Kirara.UI.Panel.AbstractBasePanel _panel = (Kirara.UI.Panel.AbstractBasePanel)translator.GetObject(L, 2, typeof(Kirara.UI.Panel.AbstractBasePanel));
                    Kirara.UILayer _layer;translator.Get(L, 3, out _layer);
                    
                    gen_to_be_invoked.PopPanel( _panel, _layer );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<Kirara.UI.Panel.AbstractBasePanel>(L, 2)) 
                {
                    Kirara.UI.Panel.AbstractBasePanel _panel = (Kirara.UI.Panel.AbstractBasePanel)translator.GetObject(L, 2, typeof(Kirara.UI.Panel.AbstractBasePanel));
                    
                    gen_to_be_invoked.PopPanel( _panel );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Kirara.UIMgr.PopPanel!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopAllPanel(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.UIMgr gen_to_be_invoked = (Kirara.UIMgr)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<Kirara.UILayer>(L, 2)) 
                {
                    Kirara.UILayer _layer;translator.Get(L, 2, out _layer);
                    
                    gen_to_be_invoked.PopAllPanel( _layer );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.PopAllPanel(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Kirara.UIMgr.PopAllPanel!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
