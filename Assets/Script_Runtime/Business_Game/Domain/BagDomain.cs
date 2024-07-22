using System;
using UnityEngine;

public static class BagDomaim {

    public static void OpenBag(GameContext ctx, BagComponent bag) {

        var ui = ctx.UIContext;
        UIApp.Panel_Bag_Opne(ui, bag.GetMaxSlot());
        bag.Foreach(item=>{
            UIApp.Panel_BagElement_Add(ui, item.typeID, item.icon, item.count);
        });

    }
}