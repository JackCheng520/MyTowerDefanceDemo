using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：Charactor  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 19:18:29
// ================================
namespace TowerDefence.AI
{
    public abstract class Charactor : MonoBehaviour
    {
        public string name;

        public int hp;


        void Awake() 
        {
            this.OnInit();
        }

        void Update() 
        {
            this.OnUpdate();
        }

        void LateUpdate() 
        {
            this.OnLateUpdate();
        }

        void OnDestroy() 
        {
            this.OnExit();
        }

        public virtual void OnInit() { }

        public virtual void OnExit() { }

        public virtual void OnUpdate() { }

        public virtual void OnLateUpdate() { }
    }
}
