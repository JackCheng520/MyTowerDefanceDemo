﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefence.Msg;
using TowerDefence.Util;

// ================================
//* 功能描述：GameApp  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/12/1 19:16:02
// ================================
namespace TowerDefence
{
    public class GameApp
    {
        public static DataCache dataCache;

        public static Message messageControl;

        public static CharactorsControl charactorControl;

        public static ResourcesControl resourcesControl;

        public static GameData gameData;

        public static PoolUtil weaponPool;

        public static LevelControl levelControl;

        public static void Init() 
        {
            dataCache           = new DataCache();
            messageControl      = new Message();
            charactorControl    = new CharactorsControl();
            resourcesControl    = new ResourcesControl();
            gameData            = new GameData();
            levelControl        = new LevelControl();
        }
    }
}
