using System;

[Serializable]
public class QuestItem
{
    public ItemData item;

    public QuestItem(ItemData data)
    {
        item = data;
    }
}
