using System;

using UnityEngine;

public class GameContext {

    public AssetsContext assets;

    public UIContext UIContext;

    public RoleRespository roleRespository;

    public LootRespository lootRespository;

    public GameContext() {
        roleRespository = new RoleRespository();
        lootRespository = new LootRespository();
    }

    public void Inject(AssetsContext assets, UIContext UIContext) {
        this.assets = assets;
        this.UIContext = UIContext;
    }
}