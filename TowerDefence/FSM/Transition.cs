using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：Transition  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 16:48:07
// ================================
namespace TowerDefence.FSM
{
    public class Transition
    {
        private string fromStateName;
        public string FromStateName
        {
            get
            {
                return fromStateName;
            }
        }
        private string toStateName;
        public string ToStateName
        {
            get
            {
                return toStateName;
            }
        }
        private List<PipeLine> listPipeLine = new List<PipeLine>();

        public Transition(string _from, string _to) {
            this.fromStateName = _from;
            this.toStateName = _to;
        }

        public void AddPipeLine(PipeLine _pipeline)
        {
            if (listPipeLine.Contains(_pipeline))
                return;
            listPipeLine.Add(_pipeline);
        }

        public void RemovePipeLine(PipeLine _pipeline)
        {
            if (listPipeLine.Contains(_pipeline))
                listPipeLine.Remove(_pipeline);
        }

        public List<PipeLine> GetPipeLines(string _src, string _org)
        {

            List<PipeLine> listPL = new List<PipeLine>();
            for (int i = 0; i < listPipeLine.Count; i++)
            {
                PipeLine pl = listPipeLine[i];
                if (pl.FromName.Equals(_src) && pl.ToName.Equals(_org))
                {
                    listPL.Add(pl);
                }
            }
            return listPL;
        }

        public void Update(Fsm fsm)
        {
            for (int i = 0; i < listPipeLine.Count; i++)
            {
                if (listPipeLine[i] != null && listPipeLine[i].Update(fsm))
                {
                    fsm.SetState(listPipeLine[i].ToName);
                }
            }
        }
    }
}
