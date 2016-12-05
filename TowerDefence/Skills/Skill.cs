using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.AI;
using TowerDefence.Cmds;
using TowerDefence.Util;
using UnityEngine;

// ================================
//* 功能描述：Skill  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/2 10:35:28
// ================================
namespace TowerDefence.Skills
{
    public abstract class Skill : MonoBehaviour
    {
        public string name;

        public Charactor launcher;

        public List<Charactor> listTargets = new List<Charactor>();

        public List<Cmd> listCmds;


        Echo echoSystem = new Echo();

        

        /// <summary>
        /// 指令集准备
        /// </summary>
        public void CmdReady()
        {
            if (listCmds != null)
            {
                for (int i = 0; i < listCmds.Count; i++)
                {
                    echoSystem.Add(listCmds[i].Run, 0);
                }
            }
        }

        /// <summary>
        /// 组装指令
        /// </summary>
        public void AssemblyCmd()
        {
            if (listCmds != null)
            {
                for (int i = 0; i < listCmds.Count; i++)
                {
                    listCmds[i].currentSk = this;
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void Delete()
        {
            if (this.gameObject != null)
                GameObject.Destroy(this.gameObject);
        }

        //-----------------------------------------------------

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init() { }
        /// <summary>
        /// 发射
        /// </summary>
        public virtual void Launch() { }
        /// <summary>
        /// 集中目标
        /// </summary>
        public virtual void LaunchAttackOnTarget() { }
        /// <summary>
        /// 没有集中目标，生命周期结束
        /// </summary>
        public virtual void LaunchLifeCycle() { }
    }
}
