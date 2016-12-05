using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.FSM;
using TowerDefence.FSM.Config;
using TowerDefence.STATE;
using TowerDefence.Util;
using UnityEngine;

// ================================
//* 功能描述：radish  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 19:19:00
// ================================
namespace TowerDefence.AI
{
    public class Radish : Charactor
    {
        //没3秒切换一次状态
        private float fDuration = 5;

        private float fTime = 0;

        private bool idleToMove = false;

        Echo echoSytem = new Echo();

        public override void OnInit()
        {
            base.OnInit();
            fsm.SetFsmName("Radish");

            //Debug.Log("-----OnInit-----");
            fsm.AddState(new IdleState(StateType.IDLE));
            fsm.AddState(new MoveState(StateType.MOVE));
            //true -->idle to move
            fsm.AddParam(new ParamBool(ConditionKey.CONDITION_IDLE_TO_MOVE, ParamType.Boolen) { Value = idleToMove});
            //false -->move to idle
            fsm.AddParam(new ParamBool(ConditionKey.CONDITION_MOVE_TO_IDLE, ParamType.Boolen) { Value = idleToMove });

            fsm.SetState(StateType.IDLE);

            Condition cIdleToMove = new Condition(ConditionKey.CONDITION_IDLE_TO_MOVE, false, ConditionType.Equals);
            fsm.TransitionTo(fsm, StateType.IDLE, StateType.MOVE, new List<Condition>() { cIdleToMove });

            Condition cMoveToIdle = new Condition(ConditionKey.CONDITION_MOVE_TO_IDLE, true, ConditionType.Equals);
            fsm.TransitionTo(fsm, StateType.MOVE, StateType.IDLE, new List<Condition>() { cMoveToIdle });
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            fsm.Update();
        }

        public override void OnLateUpdate()
        {
            base.OnLateUpdate();
            fTime += Time.deltaTime;
            if (fTime >= fDuration) 
            {
                fTime = 0;
                idleToMove = !idleToMove;
                fsm.SetParam(ConditionKey.CONDITION_IDLE_TO_MOVE, idleToMove);
                fsm.SetParam(ConditionKey.CONDITION_MOVE_TO_IDLE, idleToMove);
                Debug.Log(idleToMove);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        

    }
}
