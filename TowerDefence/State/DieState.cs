using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.AI;
using TowerDefence.Msg;
using TowerDefence.STATE;

// ================================
//* 功能描述：DieState  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 14:18:00
// ================================
namespace TowerDefence.STATE
{
    public class DieState : State
    {
        public DieState(string _name) : base(_name) { }
        public override void OnEnter(FSM.Fsm _fsm)
        {
            base.OnEnter(_fsm);
            Monster m = (Monster)_fsm.ME;
            //死亡广播消息
            GameApp.messageControl.SendMsg(null, MsgType.MSG_MONSTER_DIE, m.id);
        }

        public override void OnExecute(FSM.Fsm _fsm)
        {
            base.OnExecute(_fsm);
        }

        public override void OnExit(FSM.Fsm _fsm)
        {
            base.OnExit(_fsm);
        }
    }
}
