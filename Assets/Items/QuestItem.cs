using System;

namespace Items
{
    [Serializable]
    public class QuestItem
    {
        public ItemData item;
        public int quantity = 0;

        public QuestItem(ItemData data, int _quantity = 1)
        {
            item = data;
            quantity = _quantity;
        }
    }
}
