using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：UIType  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/6 10:56:10
// ================================
namespace TowerDefence.UI
{
    /// <summary>
    /// UI类型（给定UI的路径)
    /// </summary>
    public class UIType
    {
        public const string UI_MAIN = "UI_MAIN";
    }
    /// <summary>
    /// UI挂载点类型
    /// </summary>
    public enum eUIRootType 
    { 
        CANVAS_MESSAGE,
        CANVAS_UI,
    }
}
