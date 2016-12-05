using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.FSM.Config;
using TowerDefence.STATE;
using TowerDefence.Msg;
using TowerDefence.Po;
using TowerDefence.Define;
using UnityEngine;

// ================================
//* 功能描述：瓶子  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/2 16:03:06
// ================================
namespace TowerDefence.AI
{
    public class BottleTower : TowerBase
    {

        public override void OnInit()
        {
            base.OnInit();

            //voData =

            fsm.SetFsmName("BottleTower");
            //add state
            fsm.AddState(new IdleState(StateType.IDLE));

        }

        public override void OnExit()
        {
            base.OnExit();

        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (skill.listTargets.Count > 0) 
            {
                Charactor c = skill.listTargets[0];
                GameApp.resourcesControl.LoadWeapon("");
            }
        }

        public override void OnLateUpdate()
        {
            base.OnLateUpdate();
        }

        //----------------------------------------
        public override void UseSkill()
        {
            base.UseSkill();


        }

        public override void RadarSearch()
        {
            base.RadarSearch();
            if (skill.listTargets.Count == 0)
            {
                List<Charactor> listTemp = GameApp.charactorControl.GetCharactorList(CharactorType.CHARACTOR_MONSTER);
                List<Charactor> listMonster = new List<Charactor>();
                if (listTemp != null && listTemp.Count > 0)
                {
                    for (int i = 0; i < listTemp.Count; i++)
                    {
                        float dis1 = Vector3.Distance(this.transform.position, listTemp[0].transform.position);
                        if (dis1 <= voData.distence)
                        {
                            listMonster.Add(listTemp[i]);
                        }
                    }

                    listMonster.Sort(Compare);


                    skill.listTargets.Add(listTemp[0]);
                }
            }
        }

        private int Compare(Charactor a, Charactor b)
        {

            if (int.Parse(a.id) < int.Parse(b.id))
                return -1;
            else if (int.Parse(a.id) > int.Parse(b.id))
                return 1;
            return 0;
        }

        //----------------------------------------回调-----------------------------------
        public override void OnTowerLevelUp(object sender, MsgArgs e)
        {
            base.OnTowerLevelUp(sender, e);
            string id = e.listParams[0].ToString();
            int level = int.Parse(e.listParams[1].ToString());

            if (id == this.id)
            {

            }
        }
    }
}
