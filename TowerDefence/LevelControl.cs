using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.UI;
using UnityEngine;

// ================================
//* 功能描述：LevelControl  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/6 19:51:00
// ================================
namespace TowerDefence
{
    public class GridData
    {
        public int index;

        public int value;

        public Vector3 pos;
    }

    public class LevelControl
    {

        public List<GridData> GetFileData(int level) 
        {

            DTCanvas canvas = GameObject.Find("DT_UICanvas").GetComponent<DTCanvas>();
            float cellWidth = canvas.MapScreenWidthHeight().x / SettingControl.COL;
            float cellHeight = canvas.MapScreenWidthHeight().y / SettingControl.ROW;

            Vector3 topleft = canvas.MapTopLeftPos();
            List<GridData> listData = TowerDefence.Util.IOUtil.Read("level01.txt");
            for (int i = 0; i < listData.Count; i++)
            {
                int row = i / SettingControl.COL;
                int col = i - row * SettingControl.COL;
                listData[i].pos = topleft + new Vector3(cellWidth, -1 * cellHeight) * 0.5f + new Vector3(col * cellWidth, -1 * row * cellHeight);
            }

            return listData;
        }


    }
}
