using System;

using UnityEngine;

public class GameContext {

    public AssetsContext assets;

    public UIContext UIContext;

    public RoleRespository roleRespository;

    public LootRespository lootRespository;

    public IDService idService;

    public GameContext() {
        roleRespository = new RoleRespository();
        lootRespository = new LootRespository();
        idService = new IDService();
    }

    public void Inject(AssetsContext assets, UIContext UIContext) {
        this.assets = assets;
        this.UIContext = UIContext;
    }
}