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
    public class KiraraUIPanelDialogPanelWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Kirara.UI.Panel.DialogPanel);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 5, 4);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BindUI", _m_BindUI);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PlayEnter", _m_PlayEnter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PlayExit", _m_PlayExit);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Title", _g_get_Title);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Content", _g_get_Content);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OkBtnOnClick", _g_get_OkBtnOnClick);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HasCloseBtn", _g_get_HasCloseBtn);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OkText", _g_get_OkText);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Title", _s_set_Title);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Content", _s_set_Content);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "HasCloseBtn", _s_set_HasCloseBtn);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "OkText", _s_set_OkText);
            
			
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
					
					var gen_ret = new Kirara.UI.Panel.DialogPanel();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Kirara.UI.Panel.DialogPanel constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BindUI(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.BindUI(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayEnter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.PlayEnter(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayExit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.PlayExit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Title(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Title);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Content(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Content);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OkBtnOnClick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.OkBtnOnClick);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HasCloseBtn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.HasCloseBtn);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OkText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.OkText);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Title(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Title = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Content(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Content = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HasCloseBtn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.HasCloseBtn = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OkText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Kirara.UI.Panel.DialogPanel gen_to_be_invoked = (Kirara.UI.Panel.DialogPanel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OkText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
