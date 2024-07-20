using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    Context ctx;
    bool isTearDown = false;
    void Awake() {

        // new 
        ctx = new Context();

        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        ModuleAssets.Load(ctx.assets);
        // inject
        ctx.Inject(canvas);



        UIApp.Panel_Bag_Opne(ctx.UIContext);
        for (int i = 0; i < 100; i++) {
            UIApp.Panel_BagElement_Add(ctx.UIContext, i, null, 5);
        }
    }

    void Update() {

    }
    void OnDestory() {
        TearDown();
    }

    void OnApplicationQuit() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }
        isTearDown = true;
        // === Unload===
        ModuleAssets.Unload(ctx.assets);
    }
}
