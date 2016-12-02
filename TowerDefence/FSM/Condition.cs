using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.FSM.Config;

// ================================
//* 功能描述：Condition  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 13:15:51
// ================================
namespace TowerDefence.FSM
{
    [Flags]
    public enum ConditionType { 
        NONE = 0,
        Less = 1,
        LessEquals = 2,
        Equals = 4,
        Greater = 8,
        GreaterEquals = 16,
        NotEqual = 32,
        Func = 64,
    }
    public class Condition
    {
        private string key;
        public string KEY {
            get {
                return key;
            }
        }

        private object value;

        private ConditionType cType;
        public Condition(string _key,object _value,ConditionType _type) 
        {
            this.key = _key;
            this.value = _value;
            this.cType = _type;
        }

        public bool Update(Fsm _fsm)
        {
            Param p = _fsm.GetParam(key);
            if (p != null) 
            {
                switch (p.PType) { 
                    case ParamType.Int:
                    case ParamType.Float:
                    case ParamType.Double:
                        if (p.Value != null)
                        {
                            return CheckValue(p.Value);
                        }
                        break;

                    case ParamType.Boolen:
                        if (p.Value != null) {
                            return CheckBool(p.Value);
                        }
                        break;

                    case ParamType.Func:
                        if (p.Value != null) {
                            return CheckFunc(p.Value);
                        }
                        break;
                }
            }
            return false;
        }

        private bool CheckValue(object val) {
            bool result = false;
            if (IsContainType(cType,ConditionType.Less))
            {
                result = Convert.ToInt32(val.ToString()) < Convert.ToInt32(value);
            }

            if (IsContainType(cType, ConditionType.LessEquals)) 
            {
                result = Convert.ToInt32(val.ToString()) <= Convert.ToInt32(value);
            }

            if (IsContainType(cType, ConditionType.Equals))
            {
                result = Convert.ToInt32(val.ToString()) == Convert.ToInt32(value);
            }

            if (IsContainType(cType, ConditionType.Greater))
            {
                result = Convert.ToInt32(val.ToString()) > Convert.ToInt32(value);
            }

            if (IsContainType(cType, ConditionType.GreaterEquals))
            {
                result = Convert.ToInt32(val.ToString()) >= Convert.ToInt32(value);
            }
            return result;
        }

        private bool CheckBool(object val)
        {
            if (IsContainType(cType, ConditionType.Equals)) 
            {
                return Convert.ToBoolean(val.ToString()) == Convert.ToBoolean(value.ToString());
            }

            if (IsContainType(cType, ConditionType.NotEqual))
            {
                return Convert.ToBoolean(val.ToString()) != Convert.ToBoolean(value.ToString());
            }

            return false;
        }

        private bool CheckFunc(object val)
        {
            if (IsContainType(cType, ConditionType.Func)) 
            {
                FuncCallBack callback = (val == null ? null : (FuncCallBack)val);

                return callback == null ? false:callback(value == null ? null : (value is object[] ? value : new object[]{value}));
            }
            return false;
        }

        public bool IsContainType(ConditionType a,ConditionType b) 
        {
            return (a & b) == a;
        }
    }

}
