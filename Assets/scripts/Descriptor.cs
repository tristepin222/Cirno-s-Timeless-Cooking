using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Descriptor : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;


    // Update is called once per frame
    public void show(Item item)
    {

        itemName.text = item.name;
        itemDescription.text = item.description;
    }
}
