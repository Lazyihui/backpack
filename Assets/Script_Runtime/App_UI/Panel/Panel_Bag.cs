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


    public void Init() {


    }
    public void Ctor() {
        elements = new List<Panel_BagElement>();
    }
    // 添加物品
    public void Add(int id, Sprite icon, int count) {
        Panel_BagElement ele = GameObject.Instantiate(prefabElement, group.transform);
        ele.Ctor();
        ele.Init(id, null, count);
        elements.Add(ele);
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