using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.Define;
using UnityEngine;

// ================================
//* 功能描述：PoolUtil  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/2 16:30:32
// ================================
namespace TowerDefence.Util
{
    public class PoolUtil
    {
        private static PoolUtil ins;
        public static PoolUtil Ins {
            get {
                if (ins == null) {
                    ins = new PoolUtil();
                }
                return ins;
            }
        }

        public static int count = 0;

        ////池子容量
        private int capacity = 10;

        private Dictionary<string, List<GameObject>> activePool = new Dictionary<string, List<GameObject>>();

        private Dictionary<string, List<GameObject>> disActivePool = new Dictionary<string, List<GameObject>>();

        Echo echoSystem = new Echo();

        public void Clear() {
            count = 0;
            activePool.Clear();
            disActivePool.Clear();
        }

        /// <summary>
        /// 创建新的子弹
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public GameObject Create(string _type)
        {
            GameObject go = null;
            if (disActivePool.ContainsKey(_type) && disActivePool[_type].Count > 0)
            {
                go = disActivePool[_type][0];
                disActivePool[_type].RemoveAt(0);

                if (disActivePool[_type].Count == 0)
                    disActivePool.Remove(_type);

            }
            else
            {
                go = GameObject.Instantiate(Resources.Load("BottleSkill") as GameObject);
            }

            if (activePool.ContainsKey(_type))
            {
                activePool[_type].Add(go);
            }
            else
            {
                activePool.Add(_type, new List<GameObject>() { go });
            }
            go.name = count.ToString();
            go.SetActive(true);
            count++;
            return go;
        }

        public void Delete(string _type, GameObject _go)
        {
            if (activePool.ContainsKey(_type))
            {
                int idx = -1;
                for (int i = 0; i < activePool[_type].Count; i++)
                {
                    if (activePool[_type][i] == _go)
                    {
                        idx = i;
                        break;
                    }
                }
                if (idx != -1)
                {
                    activePool[_type].RemoveAt(idx);
                }
            }

            if (disActivePool.ContainsKey(_type))
            {
                if (disActivePool[_type].Count > 0)
                {
                    if (disActivePool[_type].Count > capacity)
                    {
                        GameObject.Destroy(_go);
                        return;
                    }
                    else
                    {
                        disActivePool[_type].Add(_go);
                    }
                }
                
            }
            else
            {
                disActivePool.Add(_type, new List<GameObject>() { _go });
            }


            if (disActivePool.ContainsKey(_type))
                Debug.Log(disActivePool[_type].Count);
            _go.SetActive(false);
        }

    }
}
