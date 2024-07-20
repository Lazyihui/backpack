using System;
using UnityEngine;

public static class UIApp {
    // --bag

    public static void Panel_Bag_Opne(UIContext ctx,int maxSlot) {
        Panel_Bag panel = ctx.panel_Bag;

        if (panel == null) {
            bool has = ctx.assets.TryGetPanel("Panel_Bag", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Bag not found");
                return;
            }

            GameObject go = GameObject.Instantiate(prefab, ctx.canvas.transform);
            panel = go.GetComponent<Panel_Bag>();
            panel.Ctor();

            ctx.panel_Bag = panel;
        }

        panel.Show();
        panel.Init(maxSlot);

    }


    public static void Panel_BagElement_Add(UIContext ctx, int id, Sprite icon, int count) {
        Panel_Bag panel = ctx.panel_Bag;
        if (panel == null) {
            Debug.LogError("Panel_Bag not found");
            return;
        }

        panel.Add(id, icon, count);
    }
}