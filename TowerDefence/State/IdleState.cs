using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.FSM;

// ================================
//* 功能描述：IdleState  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 19:10:53
// ================================
namespace TowerDefence.STATE
{
    public class IdleState : State
    {
        public IdleState(string _name) : base(_name) { }
        public override void OnEnter(Fsm _fsm)
        {
            UnityEngine.Debug.Log("IdleState ---> OnEnter");
            base.OnEnter(_fsm);
        }

        public override void OnExecute(Fsm _fsm)
        {
            base.OnExecute(_fsm);
        }

        public override void OnExit(Fsm _fsm)
        {
            UnityEngine.Debug.Log("IdleState ---> OnExit");
            base.OnExit(_fsm);
        }
    }
}
