using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：IOUtil  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/6 17:42:01
// ================================
namespace TowerDefence.Util
{
    public class IOUtil
    {
        private static string path = "E:/B_WuXiaPro_New/Code/Client/JinWarrior/Assets/JackCheng/TowerDefence/Files/";
        public static List<GridData> Read(string _name)
        {
            List<GridData> data = new List<GridData>();
            StreamReader sr = new StreamReader(path+_name, Encoding.Default);
            string line;
            int idx = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] args = line.Split(',');
                for (int i = 0; i < args.Length; i++)
                {
                    GridData gd = new GridData();
                    gd.index = idx;
                    gd.value = int.Parse(args[i]);
                    data.Add(gd);

                    idx++;
                }
            }

            //UnityEngine.Debug.Log("数据个数-->"+data.Count);

            return data;
        }
    }
}
