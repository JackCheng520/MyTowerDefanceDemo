using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// ================================
//* 功能描述：DTCanvas  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/6 13:01:46
// ================================
namespace TowerDefence.UI
{
    [ExecuteInEditMode]
    public class DTCanvas : MonoBehaviour
    {
        [SerializeField]
        private Camera uiCamera;
        [SerializeField]
        private Transform msgCanvas;
        [SerializeField]
        private Transform uiCanvas;

        void Awake()
        {
            if (uiCamera.aspect > SettingControl.ASPECT)
            {
                uiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1f;
            }
            else
            {
                uiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
            }

        }

        //void Update() 
        //{
        //    if (uiCamera.aspect > SettingControl.ASPECT)
        //    {
        //        uiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1f;
        //    }
        //    else
        //    {
        //        uiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
        //    }
        //}

        public Camera GetUICamera()
        {
            return uiCamera;
        }

        public Transform GetMsgCanvas()
        {
            return msgCanvas;
        }

        public Transform GetUICanvas()
        {
            return uiCanvas;
        }

        public Vector2 GetUICanvasWH()
        {
            return uiCanvas.GetComponent<Canvas>().rectTransform().sizeDelta;
        }

        public Vector3 GetUICanvasScale()
        {
            return uiCanvas.GetComponent<Canvas>().rectTransform().localScale;
        }

        //Anchor top left
        public Vector3 TopLeftPos()
        {
            Vector2 widthHeight = (GetUICanvasWH() * GetUICanvasScale().x) * 0.5f;
            return uiCanvas.transform.position + new Vector3(-1 * widthHeight.x, widthHeight.y);
        }

        //Anchor top right
        public Vector3 TopRightPos()
        {
            Vector2 widthHeight = (GetUICanvasWH() * GetUICanvasScale().x) * 0.5f;
            return uiCanvas.transform.position + new Vector3(widthHeight.x, widthHeight.y);
        }

        //Anchor bottom left
        public Vector3 BottomLeftPos()
        {
            Vector2 widthHeight = (GetUICanvasWH() * GetUICanvasScale().x) * 0.5f;
            return uiCanvas.transform.position + new Vector3(-1 * widthHeight.x, -1 * widthHeight.y);
        }

        //Anchor bottom right
        public Vector3 BottomRightPos()
        {
            Vector2 widthHeight = (GetUICanvasWH() * GetUICanvasScale().x) * 0.5f;
            return uiCanvas.transform.position + new Vector3(widthHeight.x, -1 * widthHeight.y);
        }

        //screen width and height
        public Vector2 ScreenWidthHeight()
        {
            return GetUICanvasWH() * GetUICanvasScale().x;
        }


        #region Map Rect
        //Anchor top left
        public Vector3 MapTopLeftPos()
        {
            Vector2 widthHeight = (new Vector2(SettingControl.ORIGIN_WIDTH,SettingControl.ORIGIN_HEIGHT) * GetUICanvasScale().x) * 0.5f;
            return uiCanvas.transform.position + new Vector3(-1 * widthHeight.x, widthHeight.y);
        }

        //Anchor top right
        public Vector3 MapTopRightPos()
        {
            Vector2 widthHeight = (new Vector2(SettingControl.ORIGIN_WIDTH, SettingControl.ORIGIN_HEIGHT) * GetUICanvasScale().x) * 0.5f;
            return uiCanvas.transform.position + new Vector3(widthHeight.x, widthHeight.y);
        }

        //Anchor bottom left
        public Vector3 MapBottomLeftPos()
        {
            Vector2 widthHeight = (new Vector2(SettingControl.ORIGIN_WIDTH, SettingControl.ORIGIN_HEIGHT) * GetUICanvasScale().x) * 0.5f;
            return uiCanvas.transform.position + new Vector3(-1 * widthHeight.x, -1 * widthHeight.y);
        }

        //Anchor bottom right
        public Vector3 MapBottomRightPos()
        {
            Vector2 widthHeight = (new Vector2(SettingControl.ORIGIN_WIDTH, SettingControl.ORIGIN_HEIGHT) * GetUICanvasScale().x) * 0.5f;
            return uiCanvas.transform.position + new Vector3(widthHeight.x, -1 * widthHeight.y);
        }

        //screen width and height
        public Vector2 MapScreenWidthHeight()
        {
            return new Vector2(SettingControl.ORIGIN_WIDTH, SettingControl.ORIGIN_HEIGHT) * GetUICanvasScale().x;
        }
        #endregion


        
    }
}
