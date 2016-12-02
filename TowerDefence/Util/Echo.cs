using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// ================================
//* 功能描述：等待系统  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/8/2 13:41:20
// ================================
namespace TowerDefence.Util
{
    public class Echo
    {
        public delegate void Msg(params object[] args);

        class CallBack
        {
            public Msg call;

            public object[] listParams;

            public float delay;

        }

        private bool beLock = false;

        List<CallBack> listMessage = new List<CallBack>();

        public void Clear()
        {
            listMessage.Clear();
        }

        public void Add(Msg _call)
        {
            CallBack cb = new CallBack();
            cb.call = _call;
            cb.delay = 0;
            listMessage.Add(cb);
        }

        public void Add(Msg _call, float _delay)
        {
            CallBack cb = new CallBack();
            cb.call = _call;
            cb.delay = _delay;
            listMessage.Add(cb);
        }

        public void Add(Msg _call, float _delay, params object[] args) {
            CallBack cb = new CallBack();
            cb.call = _call;
            cb.delay = _delay;
            cb.listParams = args;
            listMessage.Add(cb);
        }


        public void Update()
        {
            SearchEvn();
        }
        private CallBack curMsg;
        private void SearchEvn()
        {
            if (listMessage.Count > 0)
            {

                if (listMessage[0] != null)
                {
                    listMessage[0].delay -= UnityEngine.Time.fixedDeltaTime;
                    if (listMessage[0].delay <= 0)
                    {
                        
                        curMsg = listMessage[0];

                        listMessage.RemoveAt(0);

                        if (curMsg.listParams != null && curMsg.listParams.Length > 0) {
                            curMsg.call(curMsg.listParams);
                        }
                        else
                            curMsg.call();
                        curMsg = null;
                    }
                }
            }
        }
    }
}
