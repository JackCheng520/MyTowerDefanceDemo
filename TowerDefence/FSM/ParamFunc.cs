using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.FSM.Config;

// ================================
//* 功能描述：ParamFunc  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 15:17:29
// ================================
namespace TowerDefence.FSM
{
    public class ParamFunc : Param
    {
        public ParamFunc(string _name, ParamType _type) :
            base(_name, _type) { 
        
        }

        public override bool CheckValue()
        {
            return base.CheckValue();
        }
    }
}
