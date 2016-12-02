using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：Config  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/2 9:59:05
// ================================
namespace TowerDefence.FSM.Config
{
    [Flags]
    public enum ParamType 
    { 
        NONE = 0,
        Int = 1,
        Float = 2,
        Double = 4,
        Boolen = 8,
        Func = 16,
    }

    public class StateType
    {
        public const string IDLE = "IDLE";

        public const string MOVE = "MOVE";
    }

    public class ConditionKey
    {
        public const string CONDITION_IDLE_TO_MOVE = "CONDITION_IDLE_TO_MOVE";

        public const string CONDITION_MOVE_TO_IDLE = "CONDITION_MOVE_TO_IDLE";
    }
}
