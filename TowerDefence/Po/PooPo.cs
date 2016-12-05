using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：PooPo  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 10:26:35
// ================================
namespace TowerDefence.Po
{
    public class PooPo : IBasePo
    {
        public int id { set; get; }
        /// <summary>
        /// 单发伤害
        /// </summary>
        public float dph = 0;
        /// <summary>
        /// 射程
        /// </summary>
        public float rang = 0;
        /// <summary>
        /// 攻击间隔
        /// </summary>
        public float interval = 0;
        /// <summary>
        /// 减速效果
        /// </summary>
        public float slowDown = 0;
        /// <summary>
        /// 减速时间d
        /// </summary>
        public float slowDownTime = 0;
        /// <summary>
        /// 造价
        /// </summary>
        public float cost = 0;
        /// <summary>
        /// 每秒伤害
        /// </summary>
        public float dps = 0;

        public void Init() { }
    }
}
