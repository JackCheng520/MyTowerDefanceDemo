using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.FSM.Config;

// ================================
//* 功能描述：Param  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 13:39:27
// ================================
namespace TowerDefence.FSM
{
    public abstract class Param
    {
        private ParamType pType;
        public ParamType PType
        {
            get
            {
                return pType;
            }
        }

        private string name;
        public string ParamName
        {
            get
            {
                return name;
            }
        }


        private object _value;
        public object Value
        {
            set {
                this._value = value;
            }
            get
            {
                return _value;
            }
        }
        public Param(string _name, ParamType _type)
        {
            this.name = _name;
            this.pType = _type;
        }


        public virtual bool CheckValue()
        {
            switch (pType)
            {
                case ParamType.Int:
                    return this._value is int;
                case ParamType.Float:
                    return this._value is float;
                case ParamType.Double:
                    return this._value is double;
                case ParamType.Boolen:
                    return this._value is bool;
                case ParamType.Func:
                    return true;
                default:
                    return false;

            }
        }
    }
}
