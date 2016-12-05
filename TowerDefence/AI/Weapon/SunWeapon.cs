using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：CircleWeapon  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 16:47:58
// ================================
namespace TowerDefence.AI
{
    public class SunWeapon : WeaponBase
    {
        /// <summary>
        /// 半径
        /// </summary>
        public float radius;

        public override void Launch()
        {
            base.Launch();

            if (listMonsters.Count > 0)
            {
                name = "SunWeapon";
                //dir = (listMonsters[0].transform.position - launcher.transform.position).normalized;
                speed = 0.2f;
                duration = 0.5f;
            }
        }

        public override void OnHit(string _monsterId)
        {
            base.OnHit(_monsterId);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            radius += speed * Time.deltaTime;

            for (int i = 0; i < listMonsters.Count; i++)
            {
                if ((listMonsters[i] as Monster).BeInCircle(this))
                {
                    
                    OnHit(listMonsters[i].id);
                    listMonsters.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
