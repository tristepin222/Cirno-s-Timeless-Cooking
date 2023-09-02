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
        RawFish,
        CookedFish,
        RawRice,
        CookedRice,
        RawBeef,
        CookedBeef,
        Bread,
        RawNoodles,
        CookedNoodles,
        Rocks,
        RawEggs,
        CookedEggs,
        Ice,
        DefrostedFrogs,
        MagiciansMushrooms,
        CookedMagiciansMushrooms,
        LocallySourcedSparrow,
        CookedLocallySourcedSparrow,
        EarthRabbitMochi,
        MinorikosSweetPotatoes,
        ScarletDevilReserve,
        KappaCucumbers,
        MysteryPowder,
        MysteryBottle,
        MysteryCan,
        MysteryBox,
        MysteryGrass,
        MysteryBerries,
        CookedMysteryBerries,
        MysteryPlants,
        CookedMysteryPlants
    }

    public Item(string name, string description, ItemType type, Sprite icon)
    {
        this.name = name;
        this.description = description;
        this.itemType = type;
        this.icon = icon;
    }


    public Item Cook(Sprite icon)
    {
        switch (itemType)
        {
            case ItemType.RawFish: return new Item("Cooked fish", description, ItemType.CookedFish, icon);
            case ItemType.RawRice: return new Item("Cooked rice", description, ItemType.CookedRice, icon);
            case ItemType.RawBeef: return new Item("Cooked beef", description, ItemType.CookedBeef, icon);
            case ItemType.RawNoodles: return new Item("Cooked noodles", description, ItemType.CookedNoodles, icon);
            case ItemType.RawEggs: return new Item("Cooked eegg", description, ItemType.CookedEggs, icon);
            case ItemType.MysteryBerries: return new Item("Cooked mystery berry", description, ItemType.CookedMysteryBerries, icon);
            case ItemType.MysteryPlants: return new Item("Cooked mystery plant", description, ItemType.CookedMysteryPlants, icon);
            case ItemType.MagiciansMushrooms: return new Item("Cooked magician's mushroom", description, ItemType.CookedMagiciansMushrooms, icon);
            case ItemType.LocallySourcedSparrow: return new Item("Cooked locally sourced sparrow", description, ItemType.CookedLocallySourcedSparrow, icon);
            default: return new Item("Mystery poweder", description, ItemType.MysteryPowder, icon);
        }
    }
    public bool CanCook()
    {
        switch (itemType)
        {
            case ItemType.RawFish: return true;
            case ItemType.RawRice: return true;
            case ItemType.RawBeef: return true;
            case ItemType.RawNoodles: return true;
            case ItemType.RawEggs: return true;
            case ItemType.MysteryBerries: return true;
            case ItemType.MysteryPlants: return true;
            case ItemType.MagiciansMushrooms: return true;
            case ItemType.LocallySourcedSparrow: return true;
            default: return false;
        }
    }
}
