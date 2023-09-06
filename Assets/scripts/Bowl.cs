using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Bowl : MonoBehaviour, IDropHandler
{
    [SerializeField] WritterTypeEffect writterTypeEffect;
    [SerializeField] List<string> texts = new List<string>();
    [SerializeField] AudioSource theme;
    [SerializeField] AudioSource goodTheme;
    [SerializeField] AudioSource thinkTheme;
    [SerializeField] AudioSource badTheme;
    [SerializeField] AudioSource release;
    [SerializeField] AudioSource serve;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject table;
    [SerializeField] GameObject mokou;
    [SerializeField] Animator animator;
    [SerializeField] GameObject bowlShadow;
    [SerializeField] AudioSource reviveSound;
    [SerializeField] AudioSource deathSound;
    private int count = 0;
    private List<Item> items = new List<Item>();

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
    private bool badMeal = true;
    private bool isSliding = true;
    private bool isServer = false;
    private bool rawBeef, rocks, cookedMysteryplants, cookedMysteryBerries, cookedBeef, cookedRice, cookedFish, cookedLocallySourcedSparrow, cookedNoodles, ice, mysteryBox, cookedMagiciansMushrooms, bread, defrotstedFrogs, scarletDevilReserve, cookedEggs, mysteryBottle, kappaCucumbers, mysteryCan, mochi, cookedSweetPotatoes, mysterPowder, mysteryBerries = false;

    private void Start()
    {
        mokou.GetComponent<Image>().enabled = true;
        if (GlobalController.Instance.deathCount == 0 || !GlobalController.Instance.wasBad)
        {
            animator.SetBool("first", true);
        }
        else
        {
            reviveSound.Play();
            animator.SetBool("first", false);
        }
        if (GlobalController.Instance.wasBad)
        {
            StartCoroutine(writterTypeEffect.ShowText(GlobalController.Instance.nextLine));
        }
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if (!isSliding)
        {
            release.Play();
            if (eventData.pointerDrag != null)
            {
                GlobalController.Instance.isDragging = false;
                Dragger dragger = eventData.pointerDrag.GetComponent<Dragger>();
                if (dragger.deletable)
                {
                    Destroy(dragger.gameObject);
                }
                items.Add(dragger.getItem());
                count++;

            }
        }
    }

    public void StopSliding()
    {
        isSliding = false;
    }

    public void Serve()
    {
        if (!isServer)
        {
            Dragger[] draggers = FindObjectsOfType<Dragger>();
            foreach (Dragger dragger in draggers)
            {
                dragger.enabled = false;
            }
            isServer = true;
            GlobalController.Instance.isDragging = true;
            GetComponent<Image>().enabled = false;
            bowlShadow.SetActive(false);
            //table.transform.SetSiblingIndex(mokou.transform.GetSiblingIndex());
            serve.Play();
            animator.Play("Drink");
        }
    }
    public void Think()
    {
        GlobalController.Instance.isDragging = true;
        canvas.gameObject.SetActive(true);
        theme.Stop();
        thinkTheme.Play();
        animator.Play("Think");
    }

    public void Result()
    {
        GlobalController.Instance.isDragging = true;
        canvas.gameObject.SetActive(false);
        foreach (Item item in items)
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


            if (item.itemType == Item.ItemType.RawBeef)
            {
                rawBeef = true;
            }
            if (item.itemType == Item.ItemType.Rocks)
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

            if (item.itemType == Item.ItemType.CookedRice)
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


        }
        int randomKillerMeal = Random.Range(1, 4);
        int randomBadMeal = Random.Range(5, 8);
        int randomBasicMeal = Random.Range(9, 10);
        if (containsFish && containsEgg && containsFrogs && containsMagicMushrooms && containsMysterPlants && items.Count == 5)
        {
            //trigger unique killer meal
            GlobalController.Instance.nextLine = texts[0];
            playBadEnding();
            return;
        }
        if (cookedRice && (cookedBeef || cookedFish || cookedLocallySourcedSparrow) && items.Count == 2)
        {
            GlobalController.Instance.nextLine = texts[randomBasicMeal];
            playGoodEnding();
            return;
        }
        if (cookedNoodles && ice && (cookedBeef || cookedLocallySourcedSparrow) && items.Count == 3)
        {
           
            GlobalController.Instance.nextLine = texts[randomBasicMeal];
            playGoodEnding();
            return;
        }
        if (containsEgg && ice && mysteryBox && items.Count == 3)
        {
         
            GlobalController.Instance.nextLine = texts[11];
            playGoodEnding();
            return;
        }
        if (containsEgg && bread && cookedMagiciansMushrooms && items.Count == 3)
        {
           
            GlobalController.Instance.nextLine = texts[12];
            playGoodEnding();
            return;
        }
        if (defrotstedFrogs && items.Count == 1)
        {
           
            GlobalController.Instance.nextLine = texts[13];
            playGoodEnding();
            return;
        }
        if (scarletDevilReserve && items.Count == 1)
        {
            
            GlobalController.Instance.nextLine = texts[14];
            playGoodEnding();
            return;
        }
        if (cookedBeef && cookedSweetPotatoes && cookedMysteryplants && mysterPowder && items.Count == 4)
        {
           
            GlobalController.Instance.nextLine = texts[15];
            playGoodEnding();
            return;
        }
        if (cookedEggs && cookedRice && cookedMagiciansMushrooms && items.Count == 3)
        {

            GlobalController.Instance.nextLine = texts[16];
            playGoodEnding();
            return;
        }
        if (cookedLocallySourcedSparrow && bread && cookedEggs && items.Count == 3)
        {
           
            GlobalController.Instance.nextLine = texts[17];
            playGoodEnding();
            return;
        }
        if (cookedRice && cookedMagiciansMushrooms && kappaCucumbers && items.Count == 3)
        {
        
            GlobalController.Instance.nextLine = texts[18];
            playGoodEnding();
            return;
        }
        if (mochi && mysteryBottle && items.Count == 2)
        {
          
            GlobalController.Instance.nextLine = texts[19];
            playGoodEnding();
            return;
        }
        if (cookedBeef && cookedSweetPotatoes && cookedMysteryplants && mysterPowder && items.Count == 4)
        {
           
            GlobalController.Instance.nextLine = texts[15];
            playGoodEnding();
            return;
        }
        if (cookedBeef && cookedSweetPotatoes && cookedMysteryplants && mysterPowder && scarletDevilReserve && items.Count == 5)
        {
           
            GlobalController.Instance.nextLine = texts[20];
            playGoodEnding();
            return;
        }
        if (cookedLocallySourcedSparrow && cookedSweetPotatoes && mysterPowder && mysteryCan && items.Count == 4)
        {

            GlobalController.Instance.nextLine = texts[21];
            playGoodEnding();
            return;
        }
        if (cookedFish && kappaCucumbers && ice && cookedNoodles && cookedEggs && mysterPowder && items.Count == 6)
        {
            
            GlobalController.Instance.nextLine = texts[22];
            playGoodEnding();
            return;
        }
        if (rawBeef || rocks || cookedMysteryplants || cookedMysteryBerries || containsMagicMushrooms || containsMysterPlants || mysteryBerries)
        {
            //trigger unique killer meal
            GlobalController.Instance.nextLine = texts[randomKillerMeal];
            playBadEnding();
            return;
        }
        GlobalController.Instance.nextLine = texts[randomBadMeal];
        playBadEnding();
    }

    private void playGoodEnding()
    {
        thinkTheme.Stop();
        animator.Play("Yay");
        goodTheme.Play();
        StartCoroutine(writterTypeEffect.ShowText(GlobalController.Instance.nextLine));
        GlobalController.Instance.wasBad = false;
    }

    private void playBadEnding()
    {
        GlobalController.Instance.deathCount++;
        deathSound.Play();
        animator.Play("SlideMokou 1");
        thinkTheme.Stop();
        badTheme.Play();
        GlobalController.Instance.wasBad = true;
    }

    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
