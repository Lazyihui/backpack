using System;
using UnityEngine;

public static class BagDomaim {

    public static void OpenBag(GameContext ctx, BagComponent bag) {

        var ui = ctx.UIContext;
        UIApp.Panel_Bag_Opne(ui, bag.GetMaxSlot());
        bag.Foreach(item => {
            UIApp.Panel_BagElement_Add(ui, item.typeID, item.icon, item.count);
        });

    }


    public static void Toggle(GameContext ctx, BagComponent bag) {
        var ui = ctx.UIContext;

        if (ctx.UIContext.panel_Bag == null) {
            OpenBag(ctx, bag);
        } else {
            UIApp.Bag_Close(ui);
        }
    }

    public static void UpdateBag(GameContext ctx, BagComponent bag) {
        var ui = ctx.UIContext;


        if (ctx.UIContext.panel_Bag == null) {
            Debug.Log("刷新背包");
        }
    }

}