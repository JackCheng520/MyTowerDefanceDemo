using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.Util;
using UnityEngine;

// ================================
//* 功能描述：EffectItem  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 14:07:56
// ================================
namespace TowerDefence.Effect
{
    public class EffectItem : MonoBehaviour
    {
        public float duration;

        Echo echoSystem = new Echo();

        public void Play() 
        {
            echoSystem.Add(Stop, duration);
        }

        public void Stop(params object[] args) 
        { 
        
        }

        void Update() 
        {
            echoSystem.Update();
        }

    }
}
