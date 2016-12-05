using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.FSM;
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
        public string id;

        public string charactorType;

        public string name;

        public int hp;

        public Fsm fsm;

        void Awake() 
        {
            this.OnInit();
            fsm = new Fsm(this);
        }

        void Update() 
        {
            this.OnUpdate();
            fsm.Update();
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
