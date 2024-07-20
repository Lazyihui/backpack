using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Bag : MonoBehaviour {

    [SerializeField] GridLayoutGroup group;
    [SerializeField] Panel_BagElement prefabElement;

    List<Panel_BagElement> elements;


    public Action<int> OnUseHandle;
    public int id;


    public void Init(int maxSlot) {
        for (int i = 0; i < maxSlot; i++) {
            Panel_BagElement ele = GameObject.Instantiate(prefabElement, group.transform);
            ele.Ctor();
            ele.Init(-1, null, 0);

            ele.OnUseHandle = OnUse;

            elements.Add(ele);

        }

    }

    void OnUse(int id) {
        OnUseHandle.Invoke(id);
    }
    public void Ctor() {
        elements = new List<Panel_BagElement>();
    }
    // 添加物品
    public void Add(int id, Sprite icon, int count) {
        for (int i = 0; i < elements.Count; i++) {

            Panel_BagElement ele = elements[i];
            if (ele.id == -1) {
                ele.Init(id, icon, count);
                break;
            }
        }
    }

    // 移除物品
    public void Remove(int id) {
        int index = elements.FindIndex(value => value.id == id);
        if (index != -1) {
            GameObject.Destroy(elements[index].gameObject);
            elements.RemoveAt(index);
        }
    }

    public void Close() {
        foreach (var ele in elements) {
            GameObject.Destroy(ele.gameObject);
        }

        GameObject.Destroy(gameObject);
    }
    public void Show() {
        gameObject.SetActive(true);
    }

}