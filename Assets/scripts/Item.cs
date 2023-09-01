using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public ItemType itemType;
    public string name;
    public string description;
    public Sprite icon;
    public enum ItemType
    {
        Coin,
        XPOrb,
        Weapon,
        PassiveItem
    }
}
