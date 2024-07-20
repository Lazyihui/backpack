using System;
using UnityEngine;
using UnityEngine.UI;

public class Context {
    public AssetsContext assets;

    public UIContext UIContext;

    public Canvas canvas;

    public Context() {
        assets = new AssetsContext();
        UIContext = new UIContext();
    }
    public void Inject(Canvas canvas) {
        UIContext.Inject(assets, canvas);
    }


}