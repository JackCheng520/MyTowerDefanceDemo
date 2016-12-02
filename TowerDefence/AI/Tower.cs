using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.Skills;

// ================================
//* 功能描述：Tower  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/2 10:20:25
// ================================
namespace TowerDefence.AI
{
    public abstract class Tower : Charactor
    {
        public int level;

        public Skill skill;
    }
}
