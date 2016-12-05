using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：Message  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 10:31:05
// ================================
namespace TowerDefence.Msg
{
    public delegate void MsgHandler(object sender,MsgArgs e);

    public class MsgItem 
    {
        public MsgHandler handler;

        public object receiver;
    }

    public class MsgArgs 
    {
        public List<object> listParams = new List<object>();
    }
    public class Message
    {
        private Dictionary<string, List<MsgItem>> dic = new Dictionary<string, List<MsgItem>>();


        public void AddListener(object _receiver,string _type, MsgHandler _callback) 
        { 
            if(_receiver == null)
            {
                throw new Exception("没有接受者");
            }

            if (string.IsNullOrEmpty(_type))
            {
                throw new Exception("没有类型");
            }

            if (_callback == null)
            {
                throw new Exception("没有回调函数");
            }

            MsgItem item = new MsgItem();
            item.receiver = _receiver;
            if (dic.ContainsKey(_type))
            {
                int idx = -1;
                for (int i = 0; i < dic[_type].Count; i++)
                {
                    if (dic[_type][i].receiver == _receiver)
                    {
                        dic[_type][i].handler += _callback;
                        idx = i;
                        break;
                    }
                }

                if (idx == -1)
                {
                    item.receiver = _receiver;
                    item.handler += _callback;

                    dic[_type].Add(item);
                }

                
            }
            else 
            {
                item.receiver = _receiver;
                item.handler += _callback;

                dic[_type].Add(item);
            }
        }

        public void DelListener(object _receiver, string _type, MsgHandler _callback) 
        {
            if (_receiver == null)
            {
                throw new Exception("没有接受者");
            }

            if (string.IsNullOrEmpty(_type))
            {
                throw new Exception("没有类型");
            }

            if (_callback == null)
            {
                throw new Exception("没有回调函数");
            }

          
            if (dic.ContainsKey(_type))
            {
                for (int i = 0; i < dic[_type].Count; i++)
                {
                    if (dic[_type][i].receiver == _receiver)
                    {
                        dic[_type][i].handler -= _callback;
                        break;
                    }
                }
            }

            if (dic[_type].Count == 0)
                dic.Remove(_type);
        }

        public void SendMsg(object sender, string _type, params object[] param) 
        {
            if (dic.ContainsKey(_type)) 
            {
                List<MsgItem> mlist = dic[_type];

                MsgArgs args = new MsgArgs();
                if(param.Length != 0)
                    args.listParams = param.ToList<object>();
                for (int i = 0; i < mlist.Count; i++) 
                {
                    mlist[i].handler(sender, args);
                }
            }
        }
    }
}
