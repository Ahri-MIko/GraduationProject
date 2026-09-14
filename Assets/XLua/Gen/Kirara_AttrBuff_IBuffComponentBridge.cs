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
using System;


namespace XLua.CSObjectWrap
{
    public class KiraraAttrBuffIBuffComponentBridge : LuaBase, Kirara.AttrBuff.IBuffComponent
    {
	    public static LuaBase __Create(int reference, LuaEnv luaenv)
		{
		    return new KiraraAttrBuffIBuffComponentBridge(reference, luaenv);
		}
		
		public KiraraAttrBuffIBuffComponentBridge(int reference, LuaEnv luaenv) : base(reference, luaenv)
        {
        }
		
        
		void Kirara.AttrBuff.IBuffComponent.Update(float dt)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
				RealStatePtr L = luaEnv.L;
				int err_func = LuaAPI.load_error_func(L, luaEnv.errorFuncRef);
				
				
				LuaAPI.lua_getref(L, luaReference);
				LuaAPI.xlua_pushasciistring(L, "Update");
				if (0 != LuaAPI.xlua_pgettable(L, -2))
				{
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				if(!LuaAPI.lua_isfunction(L, -1))
				{
					LuaAPI.xlua_pushasciistring(L, "no such function Update");
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				LuaAPI.lua_pushvalue(L, -2);
				LuaAPI.lua_remove(L, -3);
				LuaAPI.lua_pushnumber(L, dt);
				
				int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
				if (__gen_error != 0)
					luaEnv.ThrowExceptionFromError(err_func - 1);
				
				
				
				LuaAPI.lua_settop(L, err_func - 1);
				
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		void Kirara.AttrBuff.IBuffComponent.Attached()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
				RealStatePtr L = luaEnv.L;
				int err_func = LuaAPI.load_error_func(L, luaEnv.errorFuncRef);
				
				
				LuaAPI.lua_getref(L, luaReference);
				LuaAPI.xlua_pushasciistring(L, "Attached");
				if (0 != LuaAPI.xlua_pgettable(L, -2))
				{
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				if(!LuaAPI.lua_isfunction(L, -1))
				{
					LuaAPI.xlua_pushasciistring(L, "no such function Attached");
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				LuaAPI.lua_pushvalue(L, -2);
				LuaAPI.lua_remove(L, -3);
				
				int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
				if (__gen_error != 0)
					luaEnv.ThrowExceptionFromError(err_func - 1);
				
				
				
				LuaAPI.lua_settop(L, err_func - 1);
				
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		double Kirara.AttrBuff.IBuffComponent.GetMinRemainingTime()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
				RealStatePtr L = luaEnv.L;
				int err_func = LuaAPI.load_error_func(L, luaEnv.errorFuncRef);
				
				
				LuaAPI.lua_getref(L, luaReference);
				LuaAPI.xlua_pushasciistring(L, "GetMinRemainingTime");
				if (0 != LuaAPI.xlua_pgettable(L, -2))
				{
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				if(!LuaAPI.lua_isfunction(L, -1))
				{
					LuaAPI.xlua_pushasciistring(L, "no such function GetMinRemainingTime");
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				LuaAPI.lua_pushvalue(L, -2);
				LuaAPI.lua_remove(L, -3);
				
				int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
				if (__gen_error != 0)
					luaEnv.ThrowExceptionFromError(err_func - 1);
				
				
				double __gen_ret = LuaAPI.lua_tonumber(L, err_func + 1);
				LuaAPI.lua_settop(L, err_func - 1);
				return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		void Kirara.AttrBuff.IBuffComponent.OnAttackHit(Kirara.AttrBuff.OnAttackHitContext ctx)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
				RealStatePtr L = luaEnv.L;
				int err_func = LuaAPI.load_error_func(L, luaEnv.errorFuncRef);
				ObjectTranslator translator = luaEnv.translator;
				
				LuaAPI.lua_getref(L, luaReference);
				LuaAPI.xlua_pushasciistring(L, "OnAttackHit");
				if (0 != LuaAPI.xlua_pgettable(L, -2))
				{
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				if(!LuaAPI.lua_isfunction(L, -1))
				{
					LuaAPI.xlua_pushasciistring(L, "no such function OnAttackHit");
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				LuaAPI.lua_pushvalue(L, -2);
				LuaAPI.lua_remove(L, -3);
				translator.Push(L, ctx);
				
				int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
				if (__gen_error != 0)
					luaEnv.ThrowExceptionFromError(err_func - 1);
				
				
				
				LuaAPI.lua_settop(L, err_func - 1);
				
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		void Kirara.AttrBuff.IBuffComponent.OnActionStart(Kirara.AttrBuff.OnActionStartContext ctx)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
				RealStatePtr L = luaEnv.L;
				int err_func = LuaAPI.load_error_func(L, luaEnv.errorFuncRef);
				ObjectTranslator translator = luaEnv.translator;
				
				LuaAPI.lua_getref(L, luaReference);
				LuaAPI.xlua_pushasciistring(L, "OnActionStart");
				if (0 != LuaAPI.xlua_pgettable(L, -2))
				{
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				if(!LuaAPI.lua_isfunction(L, -1))
				{
					LuaAPI.xlua_pushasciistring(L, "no such function OnActionStart");
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				LuaAPI.lua_pushvalue(L, -2);
				LuaAPI.lua_remove(L, -3);
				translator.Push(L, ctx);
				
				int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
				if (__gen_error != 0)
					luaEnv.ThrowExceptionFromError(err_func - 1);
				
				
				
				LuaAPI.lua_settop(L, err_func - 1);
				
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        

        
        Kirara.AttrBuff.AttrBuffSet Kirara.AttrBuff.IBuffComponent.set 
        {
            
            get 
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					ObjectTranslator translator = luaEnv.translator;
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "set");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					Kirara.AttrBuff.AttrBuffSet __gen_ret = (Kirara.AttrBuff.AttrBuffSet)translator.GetObject(L, -1, typeof(Kirara.AttrBuff.AttrBuffSet));
					LuaAPI.lua_pop(L, 2);
					return __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
            
            set
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					ObjectTranslator translator = luaEnv.translator;
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "set");
					translator.Push(L, value);
					if (0 != LuaAPI.xlua_psettable(L, -3))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					LuaAPI.lua_pop(L, 1);
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
        }
        
        string Kirara.AttrBuff.IBuffComponent.name 
        {
            
            get 
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "name");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					string __gen_ret = LuaAPI.lua_tostring(L, -1);
					LuaAPI.lua_pop(L, 2);
					return __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
            
            set
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "name");
					LuaAPI.lua_pushstring(L, value);
					if (0 != LuaAPI.xlua_psettable(L, -3))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					LuaAPI.lua_pop(L, 1);
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
        }
        
        double Kirara.AttrBuff.IBuffComponent.duration 
        {
            
            get 
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "duration");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					double __gen_ret = LuaAPI.lua_tonumber(L, -1);
					LuaAPI.lua_pop(L, 2);
					return __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
            
            set
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "duration");
					LuaAPI.lua_pushnumber(L, value);
					if (0 != LuaAPI.xlua_psettable(L, -3))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					LuaAPI.lua_pop(L, 1);
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
        }
        
        int Kirara.AttrBuff.IBuffComponent.stackLimit 
        {
            
            get 
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "stackLimit");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					int __gen_ret = LuaAPI.xlua_tointeger(L, -1);
					LuaAPI.lua_pop(L, 2);
					return __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
            
            set
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "stackLimit");
					LuaAPI.xlua_pushinteger(L, value);
					if (0 != LuaAPI.xlua_psettable(L, -3))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					LuaAPI.lua_pop(L, 1);
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
        }
        
        double Kirara.AttrBuff.IBuffComponent.attachInterval 
        {
            
            get 
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "attachInterval");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					double __gen_ret = LuaAPI.lua_tonumber(L, -1);
					LuaAPI.lua_pop(L, 2);
					return __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
            
            set
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "attachInterval");
					LuaAPI.lua_pushnumber(L, value);
					if (0 != LuaAPI.xlua_psettable(L, -3))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					LuaAPI.lua_pop(L, 1);
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
        }
        
        XLua.LuaTable Kirara.AttrBuff.IBuffComponent.attrs 
        {
            
            get 
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					ObjectTranslator translator = luaEnv.translator;
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "attrs");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					XLua.LuaTable __gen_ret = (XLua.LuaTable)translator.GetObject(L, -1, typeof(XLua.LuaTable));
					LuaAPI.lua_pop(L, 2);
					return __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
            
            set
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					ObjectTranslator translator = luaEnv.translator;
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "attrs");
					translator.Push(L, value);
					if (0 != LuaAPI.xlua_psettable(L, -3))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					LuaAPI.lua_pop(L, 1);
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
        }
        
        int Kirara.AttrBuff.IBuffComponent.stackCount 
        {
            
            get 
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "stackCount");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					int __gen_ret = LuaAPI.xlua_tointeger(L, -1);
					LuaAPI.lua_pop(L, 2);
					return __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
            
            set
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "stackCount");
					LuaAPI.xlua_pushinteger(L, value);
					if (0 != LuaAPI.xlua_psettable(L, -3))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					LuaAPI.lua_pop(L, 1);
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
        }
        
        XLua.LuaTable Kirara.AttrBuff.IBuffComponent.remainingTimes 
        {
            
            get 
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					ObjectTranslator translator = luaEnv.translator;
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "remainingTimes");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					XLua.LuaTable __gen_ret = (XLua.LuaTable)translator.GetObject(L, -1, typeof(XLua.LuaTable));
					LuaAPI.lua_pop(L, 2);
					return __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
            
            set
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					ObjectTranslator translator = luaEnv.translator;
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "remainingTimes");
					translator.Push(L, value);
					if (0 != LuaAPI.xlua_psettable(L, -3))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					LuaAPI.lua_pop(L, 1);
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
        }
        
        
        
		
		
	}
}
