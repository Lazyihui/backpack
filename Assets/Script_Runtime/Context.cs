using System;
using UnityEngine;
using UnityEngine.UI;

public class Context {
    public AssetsContext assets;

    public UIContext UIContext;

    public GameContext gameContext;

    public ModuleInput moduleInput;

    public Canvas canvas;

    public Context() {
        assets = new AssetsContext();
        UIContext = new UIContext();
        gameContext = new GameContext();
        moduleInput = new ModuleInput();
    }
    public void Inject(Canvas canvas) {
        this.canvas = canvas;
        UIContext.Inject(assets, canvas);
        gameContext.Inject(assets, UIContext);
    }


}