using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：IBasePo  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/3 9:52:21
// ================================
namespace TowerDefence.Po
{
    public interface IBasePo
    {
        int id { set; get; }
        void Init();
    }
}
