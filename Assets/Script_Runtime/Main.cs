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


        RoleEntity role = RoleDomain.Spawn(ctx.gameContext, 1);

        BagDomaim.OpenBag(ctx.gameContext, role.bag);
        Binding();
    }
    void Binding() {
        var uiEvent = ctx.UIContext.uiEvent;

        uiEvent.OnBagElementHandle += (id) => {
            Debug.Log("OnPanel_BagElement_Use:" + id);
        };
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
