using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.AI;
using TowerDefence.Define;
using UnityEngine;

// ================================
//* 功能描述：场景中的角色管理脚本  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 11:24:02
// ================================
namespace TowerDefence
{
    public class CharactorsControl
    {
        public static int count = 0;

        private Dictionary<string, List<Charactor>> dic = new Dictionary<string, List<Charactor>>();


        public void Clear()
        {
            count = 0;
            dic.Clear();
        }

        public Charactor CreateCharactor(string _type,string _prefabName) 
        {
            Charactor c = GameApp.resourcesControl.LoadCharactor(_type,_prefabName);
            c.id = count.ToString();
            c.charactorType = _type;

            AddCharactor(c);

            return c;
        }

        public Charactor GetCharactor(string _type, string _id) 
        {
            if (dic.ContainsKey(_type)) {
                for (int i = 0; i < dic[_type].Count; i++) {
                    if (dic[_type][i].id.Equals(_id))
                    {
                        return dic[_type][i];
                    }
                }

            }
            return null;
        }

        public List<Charactor> GetCharactorList(string _type) {
            if (dic.ContainsKey(_type)) 
            {
                return dic[_type];
            }

            return null;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="c"></param>
        public void AddCharactor(Charactor c)
        {
            if (dic.ContainsKey(c.charactorType))
            {
                int idx = -1;
                for (int i = 0; i < dic[c.charactorType].Count; i++)
                {
                    if (dic[c.charactorType][i].id == c.id)
                    {
                        idx = i;
                        break;
                    }
                }

                if (idx == -1)
                {
                    dic[c.charactorType].Add(c);
                }
            }
            else
            {
                dic.Add(c.charactorType, new List<Charactor>() { c });
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_id"></param>
        public void RemoveCharactor(string _type,string _id) 
        {
            if (dic.ContainsKey(_type))
            {
                int idx = -1;
                for (int i = 0; i < dic[_type].Count; i++) {
                    if (dic[_type][i].id.Equals(_id))
                    {
                        idx = i;
                        break;
                    }
                }

                if (idx != -1) 
                {
                    dic[_type].RemoveAt(idx);
                    if (dic[_type].Count == 0) 
                    {
                        dic.Remove(_type);
                    }
                }
            }
        }

    }
}
