using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Bowl : MonoBehaviour, IDropHandler
{
    private int count = 0;
    private Item[] items = new Item[26];

    private bool nothing = false;
    private bool containsFish = false;
    private bool containsEgg = false;
    private bool containsFrogs = false;
    private bool containsMagicMushrooms = false;
    private bool containsMysterPlants = false;
    private bool hasRaw = false;
    private bool basicMealOnigiri = false;
    private bool basicMealRamen = false;
    private bool goodMealCake = false;
    private bool goodMealStuffedMagicianMushrooms = false;
    private bool goodMealFrogLegs = false;
    private bool goodMealWine = false;
    private bool goodMealMushroomFriedRice = false;
    private bool goodMealFriedChicken = false;
    private bool goodMealSimpleStirFry = false;
    private bool masterpieceMochi = false;
    private bool masterpieceDevil = false;
    private bool masterpieceForeign = false;
    private bool masterpieceYoukai = false;
    private bool badMeal = false;
    void IDropHandler.OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            Dragger dragger = eventData.pointerDrag.GetComponent<Dragger>();
            items[count] = dragger.getItem();
            count++;
            
        }
    }

    public void Serve()
    {
        foreach (Item item in items)
        {
            if(item != null)
            {
                nothing = true;
            }
            if(item.itemType == Item.ItemType.CookedFish)
            {
                containsFish = true;
            }
            if (item.itemType == Item.ItemType.CookedEggs)
            {
                containsEgg = true;
            }
            if (item.itemType == Item.ItemType.DefrostedFrogs)
            {
                containsFrogs = true;
            }
            if (item.itemType == Item.ItemType.MagiciansMushrooms)
            {
                containsMagicMushrooms = true;
            }
            if (item.itemType == Item.ItemType.MysteryPlants)
            {
                containsMysterPlants = true;
            }
            if(item.itemType == Item.ItemType.RawBeef || item.itemType == Item.ItemType.Rocks || (item.itemType == Item.ItemType.MagiciansMushrooms && containsMagicMushrooms == false) || item.itemType == Item.ItemType.CookedMysteryPlants || item.itemType == Item.ItemType.CookedMysteryBerries || (item.itemType == Item.ItemType.MysteryPlants && containsMysterPlants == false) || item.itemType == Item.ItemType.MysteryBerries)
            {
                hasRaw = true;
            }
            if(item.itemType == Item.ItemType.CookedRice || item.itemType == Item.ItemType.CookedBeef || item.itemType == Item.ItemType.CookedFish || item.itemType == Item.ItemType.CookedLocallySourcedSparrow)
            {
                basicMealOnigiri = true;
            }
            if (item.itemType == Item.ItemType.CookedLocallySourcedSparrow || item.itemType == Item.ItemType.CookedBeef || item.itemType == Item.ItemType.Ice || item.itemType == Item.ItemType.CookedNoodles)
            {
                basicMealRamen = true;
            }
            if(item.itemType == Item.ItemType.RawEggs || item.itemType == Item.ItemType.Ice || item.itemType == Item.ItemType.MysteryBox)
            {
                goodMealCake = true;
            }
            if (item.itemType == Item.ItemType.RawEggs || item.itemType == Item.ItemType.Bread || item.itemType == Item.ItemType.CookedMagiciansMushrooms)
            {
                goodMealStuffedMagicianMushrooms = true;
            }
            if (item.itemType == Item.ItemType.DefrostedFrogs)
            {
                goodMealFrogLegs = true;
            }
            if (item.itemType == Item.ItemType.ScarletDevilReserve)
            {
                goodMealWine = true;
            }
            if (item.itemType == Item.ItemType.CookedEggs || item.itemType == Item.ItemType.CookedRice || item.itemType == Item.ItemType.CookedMagiciansMushrooms)
            {
                goodMealMushroomFriedRice = true;
            }
            if (item.itemType == Item.ItemType.CookedLocallySourcedSparrow || item.itemType == Item.ItemType.Bread || item.itemType == Item.ItemType.CookedEggs)
            {
                goodMealFriedChicken = true;
            }
            if (item.itemType == Item.ItemType.CookedRice || item.itemType == Item.ItemType.CookedMagiciansMushrooms || item.itemType == Item.ItemType.KappaCucumbers)
            {
                goodMealSimpleStirFry = true;
            }
            if(item.itemType == Item.ItemType.EarthRabbitMochi || item.itemType == Item.ItemType.MysteryBottle)
            {
                masterpieceMochi = true;
            }
            if (item.itemType == Item.ItemType.CookedBeef || item.itemType == Item.ItemType.CookedMinorikosSweetPotatoes || item.itemType == Item.ItemType.CookedMysteryPlants || item.itemType == Item.ItemType.MysteryPowder || item.itemType == Item.ItemType.ScarletDevilReserve)
            {
                masterpieceDevil = true;
            }
            if (item.itemType == Item.ItemType.CookedLocallySourcedSparrow || item.itemType == Item.ItemType.CookedMinorikosSweetPotatoes || item.itemType == Item.ItemType.MysteryCan || item.itemType == Item.ItemType.MysteryPowder)
            {
                masterpieceForeign = true;
            }
            if (item.itemType == Item.ItemType.CookedFish || item.itemType == Item.ItemType.KappaCucumbers || item.itemType == Item.ItemType.Ice || item.itemType == Item.ItemType.CookedNoodles || item.itemType == Item.ItemType.CookedEggs || item.itemType == Item.ItemType.MysteryPowder)
            {
                masterpieceYoukai = true;
            }
            if (!hasRaw && !basicMealOnigiri && !basicMealRamen && !goodMealCake && !goodMealStuffedMagicianMushrooms && !goodMealWine && !goodMealMushroomFriedRice && !goodMealFriedChicken && !goodMealSimpleStirFry && !masterpieceMochi && !masterpieceDevil && !masterpieceForeign && !masterpieceYoukai)
            {
                badMeal = true;
            }
        }

        if(nothing && containsFish && containsEgg && containsFrogs && containsMagicMushrooms && containsMysterPlants)
        {
            //trigger unique killer meal
            Debug.Log("unique killer meal");
        }
        if (hasRaw)
        {
            //trigger killer meal
            Debug.Log("killer meal");
        }
        if (badMeal)
        {
            Debug.Log("bad meal");
        }
        if (basicMealOnigiri)
        {
            //trigger basic meal
            Debug.Log("basic meal");
        }
        if (basicMealRamen)
        {
            //trigger basic meal
            Debug.Log("basic meal");
        }
        if (goodMealCake)
        {
            //trigger basic meal
            Debug.Log("good meal");
        }
        if (goodMealStuffedMagicianMushrooms)
        {
            //trigger basic meal
            Debug.Log("good meal");
        }
        if (goodMealFrogLegs)
        {
            //trigger basic meal
            Debug.Log("good meal");
        }
        if (goodMealWine)
        {
            //trigger basic meal
            Debug.Log("good meal");
        }
        if (goodMealMushroomFriedRice)
        {
            //trigger basic meal
            Debug.Log("good meal");
        }
        if (goodMealFriedChicken)
        {
            //trigger basic meal
            Debug.Log("good meal");
        }
        if (goodMealSimpleStirFry)
        {
            //trigger basic meal
            Debug.Log("good meal");
        }
        if (masterpieceMochi)
        {
            //trigger basic meal
            Debug.Log("masterpiece meal");
        }
        if (masterpieceDevil)
        {
            //trigger basic meal
            Debug.Log("masterpiece meal");
        }
        if (masterpieceForeign)
        {
            //trigger basic meal
            Debug.Log("masterpiece meal");
        }
        if (masterpieceYoukai)
        {
            //trigger basic meal
            Debug.Log("masterpiece meal");
        }

    }
}
