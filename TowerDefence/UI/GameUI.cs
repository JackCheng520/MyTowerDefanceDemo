using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：GameUI  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/6 10:57:20
// ================================
namespace TowerDefence.UI
{
    public abstract class GameUI : MonoBehaviour
    {
        public GameUI() { }

        //是否是常驻UI
        public bool isResidentUI;
        //UI类型
        public string uiType;
        //挂载点类型
        public eUIRootType rootType = eUIRootType.CANVAS_UI;
        //UI的root
        public Transform root;

        //--------------------------------------

        void OnEnable() 
        {
            this.Register();
        }

        void OnDisable() 
        {
            this.Disregister();
        }


        //--------------------------------------
        
        
        public virtual void Register() { }

        public virtual void Disregister() { }

        public virtual void Appear() {
            this.root.gameObject.SetActive(true);
        }

        public virtual void Disappear() {
            this.root.gameObject.SetActive(false);
        }

        public virtual void Enter() { }
    }
}
