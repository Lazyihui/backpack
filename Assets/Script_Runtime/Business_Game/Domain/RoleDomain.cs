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
        entity.Init(16);

        int occupiedSlot = entity.bag.GetOccupiedSlot();


        ctx.roleRespository.Add(entity);
        return entity;


    }

    public static void Move(RoleEntity entity, Vector2 dir) {
        entity.Move(dir);
    }


    public static void ToTouchLoot(GameContext ctx, RoleEntity entity) {

        int lenLoot = ctx.lootRespository.TakeAll(out LootEntity[] loots);
        for (int i = 0; i < lenLoot; i++) {
            LootEntity loot = loots[i];
        
            float disSqr = Vector2.SqrMagnitude(entity.transform.position - loot.transform.position);
            if (disSqr < 1) {
                Debug.Log("捡到物品" + loot.itemTyeID);
            }
        }



    }

    static void OntriggerEnter2D(RoleEntity entity, Collider2D other) {
        Debug.Log("OntriggerEnter2D");
        LootEntity loot = other.GetComponent<LootEntity>();
        if (loot != null) {
            Debug.Log("捡到物品" + loot.itemTyeID);
        }

    }
}