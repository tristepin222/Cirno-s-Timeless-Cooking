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
        Ice,
        CookedEggs,
        DefrostedFrogs,
        MagiciansMushrooms,
        CookedMagiciansMushrooms,
        LocallySourcedSparrow,
        CookedLocallySourcedSparrow,
        EarthRabbitMochi,
        MinorikosSweetPotatoes,
        CookedMinorikosSweetPotatoes,
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
            case ItemType.RawFish: return new Item("Cooked fish", "Smells really bad!", ItemType.CookedFish, icon);
            case ItemType.RawRice: return new Item("Cooked rice", "The foundation to many tasty meals", ItemType.CookedRice, icon);
            case ItemType.RawBeef: return new Item("Cooked beef", "It smells funny uncooked", ItemType.CookedBeef, icon);
            case ItemType.RawNoodles: return new Item("Cooked noodles", "They're like bread but really really long", ItemType.CookedNoodles, icon);
            case ItemType.RawEggs: return new Item("cooked eggs", "Eggs from… I don't know where but they taste good cooked", ItemType.CookedEggs, icon);
            case ItemType.MysteryBerries: return new Item("cooked mystery berries", "These berries are all over the forest of magic! They must be great for lost travelers to snack on", ItemType.CookedMysteryBerries, icon);
            case ItemType.MysteryPlants: return new Item("Cooked mystery plants", "I saw other people sprinkle plants on their food. I Think this is what they use?", ItemType.CookedMysteryPlants, icon);
            case ItemType.MagiciansMushrooms: return new Item("I see Marisa the magician picking these off of the forest ground a lot. If she eats them a lot, they must taste great!", description, ItemType.CookedMagiciansMushrooms, icon);
            case ItemType.LocallySourcedSparrow: return new Item("Cooked sparrow", "I borrowed this from some fairies who were delivering several to the netherworld. Do ghosts really get hungry?", ItemType.CookedLocallySourcedSparrow, icon);
            case ItemType.MinorikosSweetPotatoes: return new Item("Cooked sweet potatoes","Sweet potatoes from the autumn harvest. Humans at the village are an extra big fan of these!", ItemType.CookedMinorikosSweetPotatoes, icon);
            default: return new Item("Mystery powder", "what's that ?", ItemType.MysteryPowder, icon);
        }
    }
    public bool IsCook()
    {
        switch (itemType)
        {
            case ItemType.CookedFish: return true;
            case ItemType.CookedRice: return true;
            case ItemType.CookedBeef: return true;
            case ItemType.CookedNoodles: return true;
            case ItemType.CookedEggs: return true;
            case ItemType.CookedMysteryBerries: return true;
            case ItemType.CookedMysteryPlants: return true;
            case ItemType.CookedMagiciansMushrooms: return true;
            case ItemType.CookedLocallySourcedSparrow: return true;
            case ItemType.CookedMinorikosSweetPotatoes: return true;
            default: return false;
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
            case ItemType.MinorikosSweetPotatoes: return true;
            default: return false;
        }
    }
}
