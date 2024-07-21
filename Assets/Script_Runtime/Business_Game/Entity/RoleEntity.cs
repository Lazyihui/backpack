using System;
using UnityEngine;


public class RoleEntity : MonoBehaviour {
    public int id;

    public BagComponent bag;

    public void Ctor() {
        bag = new BagComponent();
    }

    public void Init(int bagMaxSlot) {
        bag.Init(bagMaxSlot);

    }



}
