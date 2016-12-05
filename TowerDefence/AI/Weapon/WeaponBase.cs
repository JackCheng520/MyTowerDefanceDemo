﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.Define;
using TowerDefence.Msg;
using TowerDefence.Util;
using UnityEngine;

// ================================
//* 功能描述：WeaponBase  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 16:03:50
// ================================
namespace TowerDefence.AI
{
    public abstract class WeaponBase : MonoBehaviour
    {
        public string name;

        public Vector3 dir;

        public float speed;

        public float duration;

        public TowerBase launcher;

        public List<Charactor> listMonsters = new List<Charactor>();

        Echo echoSystem = new Echo();

        private bool beLaunch = false;
        void Update()
        {
            if (beLaunch)
            {
                echoSystem.Update();

                OnUpdate();
            }
        }


        

        private void OnTimeOver(params object[] args)
        {
            beLaunch = false;
            launcher.canLaunch = true;
            GameApp.messageControl.SendMsg(this, MsgType.MSG_WEAPON_TIME_OVER);

            Delete();
        }


        public void Delete() 
        {
            Destroy(this.gameObject);
        }

        //-----------------------------------------
        public virtual void Launch()
        {
            beLaunch = true;
            launcher.canLaunch = false;
            echoSystem.Add(OnTimeOver, duration);
        }

        public virtual void OnUpdate() { }


        public virtual void OnHit(string _monsterId)
        {
            launcher.canLaunch = true;
            GameApp.messageControl.SendMsg(this, MsgType.MSG_WEAPON_TIME_OVER);
        }
    }
}
