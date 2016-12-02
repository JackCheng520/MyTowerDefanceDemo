using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.AI;
using UnityEngine;

// ================================
//* 功能描述：BottleSkill  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/2 13:16:19
// ================================
namespace TowerDefence.Skills
{
    public class BottleSkill : Skill
    {
        /// <summary>
        /// bullet prefab
        /// </summary>
        private GameObject bullet;

        public override void Init()
        {
            base.Init();
        }

        public override void Launch()
        {
            base.Launch();
            BottleTower bt = (BottleTower)launcher;
            //bt.level;
        }

        public override void LaunchAttackOnTarget()
        {
            base.LaunchAttackOnTarget();
        }

        public override void LaunchLifeCycle()
        {
            base.LaunchLifeCycle();
        }

    }
}
