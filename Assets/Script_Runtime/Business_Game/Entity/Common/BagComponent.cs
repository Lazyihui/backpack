using System;
using System.Collections.Generic;
using UnityEngine;

public class BagComponent {

    BagItemModel[] all;

    public void Init(int bagMaxSlot) {
        all = new BagItemModel[bagMaxSlot];
    }

    // 添加物品
    public bool /*返回是否添加成功*/ AddItem(int typeID, int count, Func<BagItemModel> onAddItemToNewSlot) {
        // 是否已经存在相同id
        for (int i = 0; i < all.Length; i++) {

            BagItemModel old = all[i];

            if (old != null && old.typeID == typeID) {
                int allowCount = old.countMax - old.count;
                if (allowCount >= count) {
                    old.count += count;
                    return true;
                } else {
                    old.count = old.countMax;
                    count -= allowCount;

                }
            }
        }

        // 没有加完的
        if (count > 0) {
            //1  // 并没有添加在相同的 typeID上？
            int index = -1;
            for (int i = 0; i < all.Length; i++) {
                BagItemModel old = all[i];
                if (old == null) {
                    index = i;
                    break;
                }
            }
            // 没有空格子
            if (index == -1) {
                return false;
            }
            //2 // 
            all[index] = onAddItemToNewSlot.Invoke();
            return true;


        } else {
            return true;
        }
    }
    // 查找物品

    // 移除物品

    // 遍历物品



    public int GetOccupiedSlot() {
        int count = 0;
        for (int i = 0; i < all.Length; i++) {
            if (all[i] != null) {
                count++;
            }
        }
        return count;
    }

    public int GetEmptySlot() {
        return all.Length;
    }

}

