using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Bowl : MonoBehaviour, IDropHandler
{
    private int count = 0;
    private Item[] items = new Item[31];

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

    private bool rawBeef, rocks, cookedMysteryplants, cookedMysteryBerries, cookedBeef, cookedRice, cookedFish, cookedLocallySourcedSparrow, cookedNoodles, ice, mysteryBox, cookedMagiciansMushrooms, bread, defrotstedFrogs, scarletDevilReserve, cookedEggs, mysteryBottle, kappaCucumbers, mysteryCan, mochi, cookedSweetPotatoes, mysterPowder, mysteryBerries = false;
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
            if (item == null)
            {
                nothing = true;
            }
            else
            {
                if (item.itemType == Item.ItemType.RawFish)
                {
                    containsFish = true;
                }
                if (item.itemType == Item.ItemType.RawEggs)
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


                if(item.itemType == Item.ItemType.RawBeef)
                {
                    rawBeef = true;
                }
                if(item.itemType == Item.ItemType.Rocks)
                {
                    rocks = true;
                }
                if (item.itemType == Item.ItemType.CookedMysteryPlants)
                {
                    cookedMysteryplants = true;
                }
                if (item.itemType == Item.ItemType.CookedMysteryBerries)
                {
                    cookedMysteryBerries = true;
                }
                if (item.itemType == Item.ItemType.MysteryBerries)
                {
                    mysteryBerries = true;
                }

                if(item.itemType == Item.ItemType.CookedRice)
                {
                    cookedRice = true;
                }
                if (item.itemType == Item.ItemType.CookedBeef)
                {
                    cookedBeef = true;
                }
                if (item.itemType == Item.ItemType.CookedFish)
                {
                    cookedFish = true;
                }
                if (item.itemType == Item.ItemType.CookedLocallySourcedSparrow)
                {
                    cookedLocallySourcedSparrow = true;
                }
                if (item.itemType == Item.ItemType.CookedNoodles)
                {
                    cookedNoodles = true;
                }
                if (item.itemType == Item.ItemType.Ice)
                {
                    ice = true;
                }
                if (item.itemType == Item.ItemType.MysteryBox)
                {
                    mysteryBox = true;
                }
                if (item.itemType == Item.ItemType.Bread)
                {
                    bread = true;
                }
                if (item.itemType == Item.ItemType.CookedMagiciansMushrooms)
                {
                    cookedMagiciansMushrooms = true;
                }
                if (item.itemType == Item.ItemType.DefrostedFrogs)
                {
                    defrotstedFrogs = true;
                }
                if (item.itemType == Item.ItemType.ScarletDevilReserve)
                {
                    scarletDevilReserve = true;
                }
                if (item.itemType == Item.ItemType.KappaCucumbers)
                {
                    kappaCucumbers = true;
                }
                if (item.itemType == Item.ItemType.MysteryBottle)
                {
                    mysteryBottle = true;
                }
                if (item.itemType == Item.ItemType.EarthRabbitMochi)
                {
                    mochi = true;
                }
                if (item.itemType == Item.ItemType.MysteryPowder)
                {
                    mysterPowder = true;
                }
                if (item.itemType == Item.ItemType.CookedMinorikosSweetPotatoes)
                {
                    cookedSweetPotatoes = true;
                }
                if (item.itemType == Item.ItemType.MysteryCan)
                {
                    mysteryCan = true;
                }
                if (item.itemType == Item.ItemType.CookedEggs)
                {
                    cookedEggs = true;
                }

                if (!hasRaw && !basicMealOnigiri && !basicMealRamen && !goodMealCake && !goodMealStuffedMagicianMushrooms && !goodMealWine && !goodMealMushroomFriedRice && !goodMealFriedChicken && !goodMealSimpleStirFry && !masterpieceMochi && !masterpieceDevil && !masterpieceForeign && !masterpieceYoukai)
                {
                    badMeal = true;
                }
            }
        }


        if(containsFish && containsEgg && containsFrogs && containsMagicMushrooms && containsMysterPlants)
        {
            //trigger unique killer meal
            Debug.Log("unique killer meal");
        }
        if (cookedRice && (cookedBeef || cookedFish || cookedLocallySourcedSparrow))
        {
            //trigger basic meal
            Debug.Log("basic onigiri meal");
        }
        if (cookedNoodles && ice && (cookedBeef || cookedLocallySourcedSparrow))
        {
            //trigger basic meal
            Debug.Log("basic ramen meal");
        }
        if (containsEgg && ice && mysteryBox)
        {
            //trigger basic meal
            Debug.Log("good cake meal");
        }
        if (containsEgg && bread && cookedMagiciansMushrooms)
        {
            //trigger basic meal
            Debug.Log("good stuffed meal");
        }
        if (defrotstedFrogs)
        {
            //trigger basic meal
            Debug.Log("good frog meal");
        }
        if (scarletDevilReserve)
        {
            //trigger basic meal
            Debug.Log("good wine meal");
        }
        if (cookedEggs && cookedRice && cookedMagiciansMushrooms)
        {
            //trigger basic meal
            Debug.Log("good fried rice meal");
        }
        if (cookedLocallySourcedSparrow && bread && cookedEggs)
        {
            //trigger basic meal
            Debug.Log("good fried chicken meal");
        }
        if (cookedRice && cookedMagiciansMushrooms && kappaCucumbers)
        {
            //trigger basic meal
            Debug.Log("good stir fry meal");
        }
        if (mochi && mysteryBottle)
        {
            //trigger basic meal
            Debug.Log("masterpiece mochi meal");
        }
        if (cookedBeef && cookedSweetPotatoes && cookedMysteryplants && mysterPowder)
        {
            //trigger basic meal
            Debug.Log("good devil meal");
        }
        if (cookedBeef && cookedSweetPotatoes && cookedMysteryplants && mysterPowder && scarletDevilReserve)
        {
            //trigger basic meal
            Debug.Log("masterpiece devil meal");
        }
        if (cookedLocallySourcedSparrow && cookedSweetPotatoes && mysterPowder && mysteryCan)
        {
            //trigger basic meal
            Debug.Log("masterpiece foreign meal");
        }
        if (cookedFish && kappaCucumbers && ice && cookedNoodles && cookedEggs && mysterPowder)
        {
            //trigger basic meal
            Debug.Log("masterpiece youkai meal");
        }
        if (rawBeef || rocks || cookedMysteryplants || cookedMysteryBerries || containsMagicMushrooms || containsMysterPlants || mysteryBerries)
        {
            //trigger unique killer meal
            Debug.Log("killer meal");
        }
        Debug.Log("bad meal");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
