using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Descriptor : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;

    // Start is called before the first frame update
    void Start()
    {
        show();
    }

    // Update is called once per frame
    public void show()
    {
        Dragger dragger = GetComponentInParent<Dragger>();
        itemName.text = dragger.getItem().name;
        itemDescription.text = dragger.getItem().description;
    }
}
