﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：MoveState  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 19:13:22
// ================================
namespace TowerDefence.FSM.STATE
{
    public class MoveState : State
    {
        public MoveState(string _name) : base(_name) { }
        public override void OnEnter(Fsm _fsm)
        {
            UnityEngine.Debug.Log("MoveState ---> OnEnter");
            base.OnEnter(_fsm);
        }

        public override void OnExecute(Fsm _fsm)
        {
            base.OnExecute(_fsm);
        }

        public override void OnExit(Fsm _fsm)
        {
            UnityEngine.Debug.Log("MoveState ---> OnExit");
            base.OnExit(_fsm);
        }
    }
}
