using System;

using UnityEngine;

public class GameContext {

    public AssetsContext assets;

    public UIContext UIContext;

    public RoleRespository roleRespository;

    public GameContext() {
        roleRespository = new RoleRespository();
    }

    public void Inject(AssetsContext assets, UIContext UIContext) {
        this.assets = assets;
        this.UIContext = UIContext;
    }
}