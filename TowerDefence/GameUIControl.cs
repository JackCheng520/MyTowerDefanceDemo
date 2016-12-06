using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：GameUIControl  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/6 10:43:14
// ================================
namespace TowerDefence.UI
{
    public class GameUIControl
    {
        //所有UI
        private Dictionary<string, GameUI> dicUIs = new Dictionary<string, GameUI>();
        //当前打开的UI
        private List<string> listOpenUIs = new List<string>();
        //隐藏但是没有删除的UI
        private List<string> listDisActiveUIs = new List<string>();
        //最大UI打开数量
        private int capacity = 5;

        /// <summary>
        /// 加入UI队列
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="_hideLastUI"></param>
        public void AddUI(string uiType, bool _hideLastUI = true)
        {
            //隐藏队列中最后一个UI
            if (_hideLastUI)
            {
                if (listOpenUIs.Count > 0)
                {
                    string _type = listOpenUIs[listOpenUIs.Count - 1];
                    if (dicUIs.ContainsKey(_type))
                    {
                        dicUIs[_type].Disappear();
                    }
                }
            }

            GameObject newUI = null;
            GameUI newUIScript = null;
            if (dicUIs.ContainsKey(uiType))
            {
                newUI = dicUIs[uiType].gameObject;
                newUIScript = newUI.GetComponent<GameUI>();

                int idx = GetOpenUIListIdx(uiType);
                if (idx != -1)
                {
                    listOpenUIs.RemoveAt(idx);
                }
            }
            else
            {
                newUI = GameObject.Instantiate(Resources.Load(uiType) as GameObject);
                newUIScript = newUI.GetComponent<GameUI>();
                Transform parent = GetUIRoot(newUIScript.rootType);
                newUI.transform.SetParent(parent, false);
                newUI.SetActive(true);

                dicUIs.Add(uiType, newUIScript);
            }

            //进入逻辑
            newUIScript.Enter();

            listOpenUIs.Add(uiType);
            //刷新
            Canvas.ForceUpdateCanvases();
        }
        /// <summary>
        /// 删除UI（根据容量删除)
        /// </summary>
        /// <param name="showPreUI"></param>
        public void RemoveUI(string _uiType, bool _showLastUI = true)
        {
            //关闭当前UI
            GameUI removeUIScript = null;
            if (dicUIs.ContainsKey(_uiType))
            {
                removeUIScript = dicUIs[_uiType];
                if (removeUIScript != null)
                    removeUIScript.Disappear();

                int idx = GetOpenUIListIdx(_uiType);
                if (idx != -1)
                {
                    listOpenUIs.RemoveAt(idx);
                }

                idx = GetDisactiveUIListIdx(_uiType);
                if (idx == -1)
                {
                    listDisActiveUIs.Add(_uiType);
                }

                //大于容量才处理
                if (listDisActiveUIs.Count >= capacity)
                {
                    for (int i = 0; i < listDisActiveUIs.Count; i++)
                    {
                        if (dicUIs.ContainsKey(listDisActiveUIs[i]) &&
                            !dicUIs[listDisActiveUIs[i]].isResidentUI)
                        {
                            string _type = listDisActiveUIs[i];
                            listDisActiveUIs.RemoveAt(i);

                            GameObject.Destroy(dicUIs[_type].gameObject);

                            dicUIs.Remove(_type);

                            i--;
                        }
                    }

                }
            }



            //显示上次打开的UI
            GameUI lastUIScript = null;
            if (_showLastUI)
            {
                if (listOpenUIs.Count > 0)
                {
                    string lastUI = listOpenUIs[listOpenUIs.Count - 1];
                    if (dicUIs.ContainsKey(lastUI))
                    {
                        lastUIScript = dicUIs[lastUI];

                        int idx = GetOpenUIListIdx(lastUI);
                        if (idx != -1)
                        {
                            listOpenUIs.RemoveAt(idx);
                        }
                    }
                }
            }
            if (lastUIScript != null)
                lastUIScript.Appear();
        }

        /// <summary>
        /// 获得UItype在listOpenUIs列表的idx
        /// </summary>
        /// <param name="_uiType"></param>
        /// <returns></returns>
        private int GetOpenUIListIdx(string _uiType)
        {
            int idx = -1;
            for (int i = 0; i < listOpenUIs.Count; i++)
            {
                if (listOpenUIs[i].Equals(_uiType))
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }

        /// <summary>
        /// 获得UItype在listDisActiveUIs列表的idx
        /// </summary>
        /// <param name="_uiType"></param>
        /// <returns></returns>
        private int GetDisactiveUIListIdx(string _uiType)
        {
            int idx = -1;
            for (int i = 0; i < listDisActiveUIs.Count; i++)
            {
                if (listDisActiveUIs[i].Equals(_uiType))
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }

        /// <summary>
        /// 获得UI挂载点
        /// </summary>
        /// <returns></returns>
        private Transform GetUIRoot(eUIRootType e)
        {
            GameObject root = GameObject.Find("DT_UICanvas");
            if (root == null)
            {
                root = Resources.Load<GameObject>("");
            }
            if (e == eUIRootType.CANVAS_MESSAGE)
            {
                return root.GetComponent<DTCanvas>().GetMsgCanvas();
            }
            else
            {
                return root.GetComponent<DTCanvas>().GetUICanvas();
            }
        }


    }
}
