using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.AI;
using TowerDefence.Define;
using TowerDefence.Effect;
using UnityEngine;

// ================================
//* 功能描述：ResourcesControl  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 11:51:18
// ================================
namespace TowerDefence
{

    public class ResPath 
    {
        //塔
        public const string PATH_TOWER      = "";
        //怪物
        public const string PATH_MONSTER    = "";
        //萝卜
        public const string PATH_RADISH     = "";
        //声音
        public const string PATH_AUDIO      = "";
        //特效
        public const string PATH_EFFECT     = "";
        //武器
        public const string PATH_WEAPON     = "";
    }
    public class ResourcesControl
    {
        /// <summary>
        /// 加载塔，怪物，萝卜，装饰
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_name"></param>
        /// <returns></returns>
        public Charactor LoadCharactor(string _type,string _name) 
        {
            GameObject obj = null;
            switch (_type) 
            { 
                case CharactorType.CHARACTOR_TOWER:
                    obj = GameObject.Instantiate(Resources.Load(ResPath.PATH_TOWER + _name) as GameObject);
                    break;
                case CharactorType.CHARACTOR_MONSTER:
                    obj = GameObject.Instantiate(Resources.Load(ResPath.PATH_MONSTER + _name) as GameObject);
                    break;
                case CharactorType.CHARACTOR_RADISH:
                    obj = GameObject.Instantiate(Resources.Load(ResPath.PATH_RADISH + _name) as GameObject);
                    break;
            }

            if (obj == null)
                return null;

            return obj.GetComponent<Charactor>();
        }

        /// <summary>
        /// 加载武器
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public GameObject LoadWeapon(string _name)
        {
            GameObject obj = GameObject.Instantiate(Resources.Load(ResPath.PATH_WEAPON + _name) as GameObject);

            return obj;
        }

        /// <summary>
        /// 加载特效
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public EffectItem LoadEffect(string _name) {
            GameObject obj = GameObject.Instantiate(Resources.Load(ResPath.PATH_EFFECT + _name) as GameObject);

            EffectItem ei = obj.GetComponent<EffectItem>();
            if (ei == null)
                ei = obj.AddComponent<EffectItem>();
            return ei;
        }

        /// <summary>
        /// 加载音效
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public AudioSource LoadAudioSource(string _name) 
        {
            GameObject obj = GameObject.Instantiate(Resources.Load(ResPath.PATH_AUDIO) as GameObject);

            if (obj == null)
                return null;

            return obj.GetComponent<AudioSource>();
        }
    }
}
