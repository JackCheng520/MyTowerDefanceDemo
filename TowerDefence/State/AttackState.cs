using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.AI;
using TowerDefence.STATE;

// ================================
//* 功能描述：AttackState  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 11:21:27
// ================================
namespace TowerDefence.STATE
{
    public class AttackState : State
    {
        private TowerBase tower;
        public AttackState(string _name) : base(_name) { }

        public override void OnEnter(FSM.Fsm _fsm)
        {
            base.OnEnter(_fsm);
            tower = _fsm.ME as TowerBase;
            tower.canLaunch = true;
        }

        public override void OnExecute(FSM.Fsm _fsm)
        {
            base.OnExecute(_fsm);

            tower = _fsm.ME as TowerBase;
            if (tower != null) 
            {
                tower.Launch();
            }
        }

        public override void OnExit(FSM.Fsm _fsm)
        {
            tower = _fsm.ME as TowerBase;
            tower.canLaunch = false;
            base.OnExit(_fsm);
        }

    }
}
