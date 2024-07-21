using System;
using UnityEngine;

public static class RoleDomain {
    public static RoleEntity Spawn(GameContext ctx, int id) {

        bool has = ctx.assets.TryGetEntity("RoleEntity", out GameObject prefab);

        if (!has) {
            Debug.LogError("RoleEntity not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        RoleEntity entity = go.GetComponent<RoleEntity>();
        entity.id = id;
        entity.Ctor();
        return entity;


    }
}