using System;
using UnityEngine;


public class UIEvent{
    public Action<int> OnBagElementHandle;
    
    public void OnUseHandle(int id) {
        if(OnBagElementHandle != null) {
            OnBagElementHandle.Invoke(id);
        }
    }

}