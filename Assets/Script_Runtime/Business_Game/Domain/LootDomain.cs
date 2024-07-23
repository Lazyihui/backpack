using System;
using UnityEngine;


public static class LootDomain {
    public static LootEntity Spawn(GameContext ctx) {
        bool has = ctx.assets.TryGetEntity("LootEntity", out GameObject prefab);

        if (!has) {
            Debug.LogError("LootEntity not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        LootEntity entity = go.GetComponent<LootEntity>();

        entity.Ctor();
        entity.id = 1;
        entity.itemTyeID = 1;
        entity.itemCount = 1;

        ctx.lootRespository.Add(entity);
        return entity;
    }
}