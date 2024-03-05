using System;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Quest System/Item")]
    public class ItemData : ScriptableObject
    {
        public Guid UID;
        public string label;
        public Sprite icon;

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
}