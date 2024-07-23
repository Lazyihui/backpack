using System;
using System.Collections.Generic;


public class LootRespository {

    Dictionary<int, LootEntity> all;

    LootEntity[] temArray;

    public LootRespository() {
        all = new Dictionary<int, LootEntity>();
        temArray = new LootEntity[5];
    }

    public void Add(LootEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(LootEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out LootEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new LootEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out LootEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<LootEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }
    public LootEntity Find(Predicate<LootEntity> predicate) {
        foreach (LootEntity Loot in all.Values) {
            bool isMatch = predicate(Loot);

            if (isMatch) {
                return Loot;
            }
        }
        return null;
    }

}