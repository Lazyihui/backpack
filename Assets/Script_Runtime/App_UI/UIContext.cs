using System;
using UnityEngine;


public class UIContext {

    // inject
    public AssetsContext assets;

    public Canvas canvas;

    public Panel_Bag panel_Bag;
    public UIContext() {

    }


    public void Inject(AssetsContext assets, Canvas canvas) {
        this.assets = assets;
        this.canvas = canvas;
    }


}