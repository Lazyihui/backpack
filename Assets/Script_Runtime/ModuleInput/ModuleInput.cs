using System;
using UnityEngine;

public class ModuleInput {
    public Vector2 moveAxis;

    public bool isToggleBag;
    public ModuleInput() { }


    public void Process() {
        // 角色移动
        Vector2 moveAxis = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.W)) {
            moveAxis.y = 1;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            moveAxis.y = -1;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            moveAxis.x = -1;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            moveAxis.x = 1;
        }
        moveAxis.Normalize();
        this.moveAxis = moveAxis;

        // ==== ui ====
        isToggleBag = Input.GetKeyDown(KeyCode.B);

    }
}