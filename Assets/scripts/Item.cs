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
        LocallySourcedSparrow,
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
}
