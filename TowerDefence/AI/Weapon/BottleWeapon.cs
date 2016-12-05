using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：BulletWeapon  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 16:05:04
// ================================
namespace TowerDefence.AI
{
    public class BottleWeapon : WeaponBase
    {
        public override void Launch()
        {
            base.Launch();
            if (listMonsters.Count > 0) 
            {
                name = "BottleWeapon";
                dir = (listMonsters[0].transform.position - launcher.transform.position).normalized;
                speed = 0.2f;
                duration = 0.5f;
            }
        }

        public override void OnHit(string _monsterId)
        {
            base.OnHit(_monsterId);

            Delete();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            this.transform.position += dir * speed * Time.deltaTime;

            for (int i = 0; i < listMonsters.Count; i++) 
            {
                if ((listMonsters[i] as Monster).BeHit(this))
                {
                    OnHit(listMonsters[i].id);
                    break;
                }
            }
            
        }
    }
}
