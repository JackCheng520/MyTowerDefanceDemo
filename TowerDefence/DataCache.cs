using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.Po;

// ================================
//* 功能描述：DataCache  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 9:53:46
// ================================
namespace TowerDefence
{
    public class DataCache
    {
        private Dictionary<string, object> dic = new Dictionary<string, object>();

        public void AddPo<T>(T _t) 
        { 
            Type type = typeof(T);
            (_t as IBasePo).Init();
            if (dic.ContainsKey(type.Name))
            {
                List<T> mlist = dic[type.Name] as List<T>;
                mlist.Add(_t);
                dic[type.Name] = mlist;
            }
            else 
            {
                dic.Add(type.Name, new List<T>() { _t });    
            }
        }

        public void AddPo<T>(List<T> _list) 
        {
            Type type = typeof(T);
            if (dic.ContainsKey(type.Name))
            {
                List<T> mlist = dic[type.Name] as List<T>;
                List<T> listTemp = new List<T>();
                for (int i = 0; i < _list.Count; i++)
                {
                    if (!mlist.Contains(_list[i])) 
                    {
                        (_list[i] as IBasePo).Init();
                        listTemp.Add(_list[i]);
                    }
                }
                mlist.AddRange(listTemp);
                dic[type.Name] = mlist;
            }
            else 
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    (_list[i] as IBasePo).Init();
                }
                dic.Add(type.Name, _list);
            }
        }

        public T GetPo<T>(int _id) 
        {
            Type type = typeof(T);
            if (dic.ContainsKey(type.Name)) 
            {
                List<T> mlist = dic[type.Name] as List<T>;
                for (int i = 0; i < mlist.Count; i++) {
                    IBasePo po = mlist[i] as IBasePo;
                    if (po.id == _id)
                    {
                        return (T)po;
                    }
                }
            }

            return default(T);
        }

        public List<T> GetPoList<T>() 
        {
            Type type = typeof(T);
            if (dic.ContainsKey(type.Name)) 
            {
                return dic[type.Name] as List<T>;
            }

            return null;
        }
    }
}
