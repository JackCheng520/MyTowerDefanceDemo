using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：PathUtil  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/5 12:00:56
// ================================
namespace TowerDefence.Util
{
    public class PathUtil
    {
        /// <summary>
        /// 根据路径点,获得路径
        /// </summary>
        /// <param name="_waypoint"></param>
        /// <returns></returns>
        public static List<Vector3> GetPath(Vector3[] _waypoint)
        {
            List<Vector3> listPath = new List<Vector3>();
            Vector3[] vector3s = PathControlPointGenerator(_waypoint);

            //Line Draw:
            Vector3 prevPt = Interp(vector3s, 0);
            listPath.Add(prevPt);

            int SmoothAmount = _waypoint.Length * 20;
            for (int i = 1; i <= SmoothAmount; i++)
            {
                float pm = (float)i / SmoothAmount;
                Vector3 currPt = Interp(vector3s, pm);
                
                listPath.Add(currPt);
            }

            return listPath;
        }

        private static Vector3[] PathControlPointGenerator(Vector3[] _path)
        {
            Vector3[] suppliedPath;
            Vector3[] vector3s;

            //create and store path points:
            suppliedPath = _path;

            //populate calculate path;
            int offset = 2;
            vector3s = new Vector3[suppliedPath.Length + offset];
            Array.Copy(suppliedPath, 0, vector3s, 1, suppliedPath.Length);

            //populate start and end control points:
            //vector3s[0] = vector3s[1] - vector3s[2];
            vector3s[0] = vector3s[1] + (vector3s[1] - vector3s[2]);
            vector3s[vector3s.Length - 1] = vector3s[vector3s.Length - 2] + (vector3s[vector3s.Length - 2] - vector3s[vector3s.Length - 3]);

            //is this a closed, continuous loop? yes? well then so let's make a continuous Catmull-Rom spline!
            if (vector3s[1] == vector3s[vector3s.Length - 2])
            {
                Vector3[] tmpLoopSpline = new Vector3[vector3s.Length];
                Array.Copy(vector3s, tmpLoopSpline, vector3s.Length);
                tmpLoopSpline[0] = tmpLoopSpline[tmpLoopSpline.Length - 3];
                tmpLoopSpline[tmpLoopSpline.Length - 1] = tmpLoopSpline[2];
                vector3s = new Vector3[tmpLoopSpline.Length];
                Array.Copy(tmpLoopSpline, vector3s, tmpLoopSpline.Length);
            }

            return (vector3s);
        }

        private static Vector3 Interp(Vector3[] _pts, float _t)
        {
            int numSections = _pts.Length - 3;
            int currPt = Mathf.Min(Mathf.FloorToInt(_t * (float)numSections), numSections - 1);
            float u = _t * (float)numSections - (float)currPt;

            Vector3 a = _pts[currPt];
            Vector3 b = _pts[currPt + 1];
            Vector3 c = _pts[currPt + 2];
            Vector3 d = _pts[currPt + 3];

            return .5f * (
                (-a + 3f * b - 3f * c + d) * (u * u * u)
                + (2f * a - 5f * b + 4f * c - d) * (u * u)
                + (-a + c) * u
                + 2f * b
            );
        }

        /// <summary>
        /// 画路径
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_color"></param>
        public static void DrawPath(List<Vector3> _path,Color _color) 
        {
            Gizmos.color = _color;
            for (int i = 0; i < _path.Count - 1; i++) 
            {
                Gizmos.DrawLine(_path[i], _path[i+1]);
            }    
        }
    }
}
