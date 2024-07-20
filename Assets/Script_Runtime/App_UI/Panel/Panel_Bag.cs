using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Bag : MonoBehaviour {

    [SerializeField] GridLayoutGroup group;
    [SerializeField] Panel_BagElement prefabElement;

    List<Panel_BagElement> elements;

    public int id;


    public void Init(int maxSlot) {
        for (int i = 0; i < maxSlot; i++) {
            Panel_BagElement ele = GameObject.Instantiate(prefabElement, group.transform);
            ele.Init(i, null, 0);
            elements.Add(ele);
        }

    }
    public void Ctor() {
        elements = new List<Panel_BagElement>();
    }
    // 添加物品
    public void Add(int id, Sprite icon, int count) {
        // ele.Ctor();
        // ele.Init(id, null, count);
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