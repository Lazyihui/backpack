using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class ModuleAssets {

    public static void Load(AssetsContext ctx) {

        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "Panels";
            var ptr = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.panels.Add(go.name, go);
            }
            ctx.panelPtr = ptr;

        }

        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "Entities";
            var ptr = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.entities.Add(go.name, go);
            }
            ctx.entityPtr = ptr;


        }

    }

    public static void Unload(AssetsContext ctx) {
        if (ctx.panelPtr.IsValid()) {
            Addressables.Release(ctx.panelPtr);
        }
        if (ctx.entityPtr.IsValid()) {
            Addressables.Release(ctx.entityPtr);
        }
    }




}