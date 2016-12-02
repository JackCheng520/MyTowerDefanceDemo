using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.Skills;
using UnityEngine;

// ================================
//* 功能描述：指令集  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/2 10:55:31
// ================================
namespace TowerDefence.Cmds
{
    public class Cmd : MonoBehaviour
    {
        [HideInInspector]
        public Skill currentSk;

        public virtual void Run(params object[] args) 
        { 
        
        }
    }
}
