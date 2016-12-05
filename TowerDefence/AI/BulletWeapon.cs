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
    public class BulletWeapon : WeaponBase
    {
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
                if ((listMonsters[i] as MonsterBase).BeHit(this))
                {
                    OnHit(listMonsters[i].id);
                    break;
                }
            }
            
        }
    }
}
