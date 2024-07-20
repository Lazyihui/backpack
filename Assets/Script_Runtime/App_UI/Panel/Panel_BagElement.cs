using System;
using UnityEngine;
using UnityEngine.UI;


public class Panel_BagElement : MonoBehaviour {
    public int id;

    [SerializeField] Image imgicon;
    [SerializeField] Text txtCount;
    [SerializeField] Button btnUse;

    public Action<int> OnUseHandle;
    public void Ctor() {
         btnUse.onClick.AddListener(() => {
            OnUseHandle.Invoke(id);
        });
    }

    public void Init(int id, Sprite icon, int count) {
        this.id = id;
        this.imgicon.sprite = icon;
        if (count <= 0) {
            this.txtCount.text = null;
        } else {
            this.txtCount.text = count.ToString();

        }
    }
}
