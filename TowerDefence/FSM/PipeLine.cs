using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：PipeLine  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 13:11:47
// ================================
namespace TowerDefence.FSM
{
    public class PipeLine
    {
        private string fromName;
        public string FromName {
            get {
                return fromName;
            }
        }
        private string toName;
        public string ToName {
            get {
                return toName;
            }
        }
        private List<Condition> listCondition = new List<Condition>();

        public PipeLine(string _src, string _org) {
            this.fromName = _src;
            this.toName = _org;
        }

        public void AddCondition(Condition _condition) {
            if (listCondition.Contains(_condition))
                return;
            listCondition.Add(_condition);
        }

        public void RemoveCondition(Condition _condition) {
            int idx = -1;

            for (int i = 0; i < listCondition.Count; i++) {
                if (listCondition[i].KEY.Equals(_condition.KEY)) {
                    idx = i;
                    break;
                }
            }
            if (idx != -1) 
            {
                listCondition.RemoveAt(idx);
            }
        }

        public void AddConditons(List<Condition> _conditions) 
        {
            listCondition.AddRange(_conditions);
        }

        public bool Update(Fsm fsm) {
            bool result = true;
            for (int i = 0; i < listCondition.Count; i++) 
            {
                if (listCondition[i] != null) 
                {
                    result = listCondition[i].Update(fsm);
                    if (!result)
                        break;
                }
            }
            return result;
        }
    }
}
