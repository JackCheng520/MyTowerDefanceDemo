using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.Util;
using UnityEngine;

// ================================
//* 功能描述：Monster  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 15:24:27
// ================================
namespace TowerDefence.AI
{
    public class MonsterBase : Charactor
    {
        public MonsterVo voData;

        public Vector2 range;

        public override void OnInit()
        {
            base.OnInit();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLateUpdate()
        {
            base.OnLateUpdate();
        }

        //---------------------------------------------
        /// <summary>
        /// 子弹类型是否击中
        /// </summary>
        /// <param name="wb"></param>
        /// <returns></returns>
        public bool BeHit(WeaponBase wb) 
        {
            Vector3 mPos = transform.position;
            Vector3 topLeft     = new Vector3(mPos.x - range.x,mPos.y - range.y);
            Vector3 topRight    = new Vector3(mPos.x + range.x,mPos.y - range.y);
            Vector3 bottomLeft  = new Vector3(mPos.x - range.x,mPos.y + range.y);
            Vector3 bottomRight = new Vector3(mPos.x + range.x,mPos.y + range.y);

            return PointInRectangleUtil.IsPointInRectangle(topLeft, topRight, bottomRight, bottomLeft, wb.transform.position);
        }
        /// <summary>
        /// 太阳类型，是否在圆中
        /// </summary>
        /// <param name="wb"></param>
        /// <returns></returns>
        public bool BeInCircle(WeaponBase wb) 
        {
            CircleWeapon cw = wb as CircleWeapon;

            Vector3 mPos = transform.position;
            if (Vector3.Distance(mPos, wb.transform.position) <= cw.radius) 
            {
                return true;
            }
            return false;
        }

    }
}
