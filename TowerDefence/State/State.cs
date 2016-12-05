using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.FSM;

// ================================
//* 功能描述：State  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 16:46:01
// ================================
namespace TowerDefence.STATE
{
    public abstract class State
    {
        private string name;
        public string Name {
            get {
                return name;
            }
        }
        public State(string _name) {
            this.name = _name;
        }

        private bool needUpdate = false;
        public List<Transition> listTransition = new List<Transition>();

        public void AddTransition(Transition _transition) {
            if (!listTransition.Contains(_transition))
            {
                listTransition.Add(_transition);
            }
        }

        public void RemoveTransition(Transition _transition) {
            if (listTransition.Contains(_transition)) {
                listTransition.Remove(_transition);
            }
        }

        public List<Transition> GetTransitions(string _src,string _org) 
        {
            List<Transition> listT = new List<Transition>();
            for (int i = 0; i < listTransition.Count; i++)
            {
                Transition pl = listTransition[i];
                if (pl.FromStateName.Equals(_src) && pl.ToStateName.Equals(_org))
                {
                    listT.Add(pl);
                }
            }
            return listT;
        }

        public void Update(Fsm fsm)
        {
            if (needUpdate)
            {
                for (int i = 0; i < listTransition.Count; i++)
                {
                    if (listTransition[i] != null)
                    {
                        listTransition[i].Update(fsm);
                    }
                }
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        public void Dirty() 
        {
            needUpdate = true;
        }

        //------------------------------------------------
        public virtual void OnEnter(Fsm _fsm) { }

        public virtual void OnExecute(Fsm _fsm) { }

        public virtual void OnExit(Fsm _fsm) { }
    }
}
