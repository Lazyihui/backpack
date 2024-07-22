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

        Binding();
    }
    void Binding() {
        var uiEvent = ctx.UIContext.uiEvent;

        uiEvent.OnBagElementHandle += (id) => {
            Debug.Log("OnPanel_BagElement_Use:" + id);
        };
    }
    void Update() {


        ctx.moduleInput.Process();

        int lenRole = ctx.gameContext.roleRespository.TakeAll(out RoleEntity[] roles);

        RoleEntity role = roles[0];
        RoleDomain.Move(role, ctx.moduleInput.moveAxis);

        ModuleInput input = ctx.moduleInput;
        if (input.isToggleBag) {
            BagDomaim.Toggle(ctx.gameContext, role.bag);
        }




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
