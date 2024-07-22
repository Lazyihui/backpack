using System;
using System.Collections.Generic;
using UnityEngine;

public class BagItemModel {
    //  ID
    public int id;
    public int typeID;
    // 数量
    public int count;

    public int countMax;

    //图标 
    public Sprite icon;
    // 特性
    public bool idConsumable;

    public bool idEateble;

    public int eatRestoreHp;
}