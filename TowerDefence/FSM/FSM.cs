using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.AI;
using TowerDefence.STATE;

// ================================
//* 功能描述：FSM  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 15:33:36
// ================================
namespace TowerDefence.FSM
{
    public delegate bool FuncCallBack(params object[] args);
    public class Fsm
    {
        private string fsmName;

        private Charactor me;
        public Charactor ME {
            get {
                return this.me;
            }
        }

        public Fsm(Charactor _me) 
        {
            this.me = _me;
        }

        public void SetFsmName(string _name) {
            this.fsmName = _name;
        }

        #region 切换参数
        private Dictionary<string, Param> dicParam = new Dictionary<string, Param>();

        public void AddParam(Param _param)
        {
            if (_param != null && !dicParam.ContainsKey(_param.ParamName) && _param.CheckValue())
            {
                dicParam.Add(_param.ParamName, _param);
            }
        }

        public void RemoveParam(Param _param){
            if(_param != null && dicParam.ContainsKey(_param.ParamName))
            {
                dicParam.Remove(_param.ParamName);
            }
        }

        public void SetParam(string _name,object _value) {
            Param p = GetParam(_name);
            if (p != null) 
            {
                p.Value = _value;

                curState.Dirty();
            }
        }

        public Param GetParam(string _name) 
        {
            if (dicParam.ContainsKey(_name)) 
            {
                return dicParam[_name];
            }
            return null;
        }
        #endregion

        #region 状态
        private Dictionary<string, State> dicState = new Dictionary<string, State>();

        private State curState;

        private State lastState;

        public void AddState(State _state) { 
            if(_state == null)
                return;
            if (!dicState.ContainsKey(_state.Name)) {
                dicState.Add(_state.Name, _state);
            }
        }

        public void RemoveState(string _name) 
        {
            if (dicState.ContainsKey(_name)) 
            {
                dicState.Remove(_name);
            }
        }

        public State GetState(string _name)
        {
            if (dicState.ContainsKey(_name))
                return dicState[_name];

            return null;
        }

        public void SetState(string _name) 
        {
            curState = GetState(_name);
        }

        public void Update() 
        {
            if (curState != lastState) 
            {
                if (lastState != null) 
                {
                    lastState.OnExit(this);
                }
                if (curState != null) 
                {
                    curState.OnEnter(this);
                    lastState = curState;
                }
            }

            if (curState != null)
                curState.Update(this);
        }
        #endregion

        public void TransitionTo(Fsm fsm, string fromState, string toState, List<Condition> conditions)
        {
            Transition t = null;
            PipeLine p = null;
            GetTransitionAndPipeline(fsm, fromState, toState, out t, out p);
            p.AddConditons(conditions);
        }

        public void GetTransitionAndPipeline(Fsm fsm, string fromState, string toState, out Transition t, out PipeLine p)
        {
            t = null;
            p = null;
            var _state = fsm.GetState(fromState);
            if (_state == null)
                return;
            var _transitions = _state.GetTransitions(fromState, toState);
            if (_transitions.Count > 0)
                t = _transitions[0];
            if (t == null)
            {
                t = new Transition(fromState, toState);
                _state.AddTransition(t);
            }
            var _pipelines = t.GetPipeLines(fromState, toState);
            if (_pipelines.Count > 0)
                p = _pipelines[0];
            if (p == null)
            {
                p = new PipeLine(fromState, toState);
                t.AddPipeLine(p);
            }
        }
    }
}
