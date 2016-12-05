using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.FSM;
using TowerDefence.Msg;
using TowerDefence.Util;

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

        public bool canLaunch = false;
        /// <summary>
        /// 塔的数据
        /// </summary>
        public TowerVo voData;
        /// <summary>
        /// 目标列表
        /// </summary>
        public List<Charactor> listTargets = new List<Charactor>();

        Echo echoSystem = new Echo();

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

            if (GameApp.gameData.settingTarget != null &&
                GameApp.gameData.settingTarget.IsAlive)
            {
                AutoSearch = false;
            }
            else 
            {
                AutoSearch = true;
            }
        }

        public override void OnLateUpdate()
        {
            base.OnLateUpdate();
        }

        //----------------------------------

        public virtual void RadarSearch()
        {

        }

        public virtual void Launch()
        {
            if (AutoSearch)
            {
                RadarSearch();
            }
            else 
            {
                if (GameApp.gameData.settingTarget != null &&
                    GameApp.gameData.settingTarget.IsAlive)
                {
                    listTargets.Clear();
                    listTargets.Add(GameApp.gameData.settingTarget);
                }
            }
        }


        //----------------------------------------回调-----------------------------------
        public virtual void OnTowerLevelUp(object sender, MsgArgs e)
        {

        }

        public virtual void OnMonsterDie(object sender, MsgArgs e)
        {
            string monsterId = e.listParams[0].ToString();
            if (listTargets.Count > 0)
            {
                int idx = -1;
                for (int i = 0; i < listTargets.Count; i++)
                {
                    if (listTargets[i].id.Equals(monsterId))
                    {
                        idx = i;
                        break;
                    }
                }

                if (idx != -1)
                {
                    listTargets.RemoveAt(idx);
                }
            }
        }
    }
}
