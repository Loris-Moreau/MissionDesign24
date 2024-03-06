using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Quest System/Item")]
public class ItemData : ScriptableObject
{
    public Guid UID;
    public string label;
    public Sprite icon;

    public bool isInfo;
    
    private void OnValidate()
    {
#if UNITY_EDITOR
        if (UID != Guid.Empty) return;

        UID = Guid.NewGuid();
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
    
    public bool Equals(ItemData data)
    {
        return data != null && UID == data.UID;
    }
}
