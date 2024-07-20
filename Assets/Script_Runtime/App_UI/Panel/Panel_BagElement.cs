using System;
using UnityEngine;
using UnityEngine.UI;


public class Panel_BagElement : MonoBehaviour {
    public int id;

    [SerializeField] Image imgicon;
    [SerializeField] Text txtCount;

    public void Ctor() {

    }

    public void Init(int id, Sprite icon, int count) {
        this.id = id;
        this.imgicon.sprite = icon;
        this.txtCount.text = count.ToString();
    }
}
