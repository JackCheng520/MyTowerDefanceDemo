using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.FSM;
using TowerDefence.Msg;
using TowerDefence.Skills;

// ================================
//* 功能描述：Tower  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/2 10:20:25
// ================================
namespace TowerDefence.AI
{
    public abstract class TowerBase : Charactor
    {
        /// <summary>
        /// 自动搜索目标
        /// </summary>
        public bool AutoSearch = true;

        public TowerVo voData;

        public Skill skill;

        public override void OnInit()
        {
            base.OnInit();
            GameApp.messageControl.AddListener(this, MsgType.MSG_LEVEL_UP, OnTowerLevelUp);
            GameApp.messageControl.AddListener(this, MsgType.MSG_MONSTER_DIE, OnMonsterDie);
        }

        public override void OnExit()
        {
            base.OnExit();
            GameApp.messageControl.DelListener(this, MsgType.MSG_LEVEL_UP, OnTowerLevelUp);
            GameApp.messageControl.DelListener(this, MsgType.MSG_MONSTER_DIE, OnMonsterDie);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (AutoSearch) 
            {
                RadarSearch();
            }
        }

        public override void OnLateUpdate()
        {
            base.OnLateUpdate();
        }

        //----------------------------------
        public virtual void UseSkill() { }

        public virtual void RadarSearch() { }


        //----------------------------------------回调-----------------------------------
        public virtual void OnTowerLevelUp(object sender, MsgArgs e)
        {

        }

        public virtual void OnMonsterDie(object sender, MsgArgs e) 
        {
            string monsterId = e.listParams[0].ToString();
            if (skill.listTargets.Count > 0) 
            {
                int idx = -1;
                for (int i = 0; i < skill.listTargets.Count; i++) 
                {
                    if (skill.listTargets[i].id.Equals(monsterId)) 
                    {
                        idx = i;
                        break;
                    }
                }

                if (idx != -1) {
                    skill.listTargets.RemoveAt(idx);
                }
            }
        }
    }
}
