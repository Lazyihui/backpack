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
    // 特性
    public bool idConsumable;

    public bool idEateble;

    public int eatRestoreHp;
}