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
        entity.id = ctx.idService.roleIDRecord++;
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
                PickItem(ctx, entity, loot);
            }
        }

    }

    static void PickItem(GameContext ctx, RoleEntity entity, LootEntity loot) {

        //添加到背包里
        bool isPicked = entity.bag.AddItem(loot.itemTyeID, loot.itemCount, () => {
            BagItemModel item = new BagItemModel();
            item.id = ctx.idService.bagItemIDRecord++;
            item.typeID = loot.itemTyeID;
            item.count = loot.itemCount;
            item.countMax = 99;
            return item;
        });

        //移除物品

        if (isPicked) {
            LootDomain.UnSpawn(ctx, loot);
        } else {
            Debug.Log("背包已满");
        }
        // 如果背包是打开的，那么更新背包
        BagDomaim.UpdateBag(ctx, entity.bag);
    }

    static void OntriggerEnter2D(RoleEntity entity, Collider2D other) {
        Debug.Log("OntriggerEnter2D");
        LootEntity loot = other.GetComponent<LootEntity>();
        if (loot != null) {
            Debug.Log("捡到物品" + loot.itemTyeID);
        }

    }
}