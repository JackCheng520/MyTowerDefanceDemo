using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：UIDraw  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/6 15:18:24
// ================================
namespace TowerDefence.UI
{
    [ExecuteInEditMode]
    public class DTDraw : MonoBehaviour
    {
        [SerializeField]
        private Color color = Color.green;
        [SerializeField]
        private DTCanvas canvas;

        private float cellWidth
        {
            get
            {
                return canvas.MapScreenWidthHeight().x / SettingControl.COL;
            }
        }

        public float cellHeight
        {
            get
            {
                return canvas.MapScreenWidthHeight().y / SettingControl.ROW;
            }
        }

#if UNITY_EDITOR

        void OnDrawGizmos()
        {
            Gizmos.color = color;
            Vector3 topleft = canvas.MapTopLeftPos();
            Vector2 wh = canvas.MapScreenWidthHeight();

            for (int i = 0; i < SettingControl.ROW + 1; i++)
            {
                Gizmos.DrawLine(topleft + new Vector3(0, -1 * cellHeight * i), topleft + new Vector3(wh.x, -1 * cellHeight * i));
            }

            for (int i = 0; i < SettingControl.COL + 1; i++)
            {
                Gizmos.DrawLine(topleft + new Vector3(cellWidth * i, 0), topleft + new Vector3(cellWidth * i, -1 * wh.y));
            }

            //if (listPath != null && listPath.Count > 0)
            //    TowerDefence.Util.PathUtil.DrawPath(listPath, Color.blue);
        }

        //List<Vector3> listPath;

        //void OnGUI()
        //{
        //    if (GUILayout.Button("读取文本"))
        //    {
        //        Vector3 topleft = canvas.MapTopLeftPos();

        //        List<GridData> data = TowerDefence.Util.IOUtil.Read("level01.txt");

        //        List<GridData> pathData = new List<GridData>();

        //        List<Vector3> path = new List<Vector3>();

        //        for (int i = 0; i < data.Count; i++)
        //        {
        //            int row = i / SettingControl.COL;
        //            int col = i - row * SettingControl.COL;
        //            data[i].pos = topleft + new Vector3(cellWidth, -1 * cellHeight) * 0.5f + new Vector3(col * cellWidth, -1 * row * cellHeight);
        //            if (data[i].value > 0)
        //            {
        //                GameObject o = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //                o.transform.position = data[i].pos;
        //                o.transform.localScale = Vector3.one * 20f;
        //                o.name = data[i].ToString();

        //                pathData.Add(data[i]);
        //            }
        //        }

        //        pathData.Sort(Compare);

        //        for (int i = 0; i < pathData.Count; i++)
        //            path.Add(pathData[i].pos);

        //        listPath = TowerDefence.Util.PathUtil.GetPath(path);

        //    }
        //}


        
#endif
    }
}

