using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Bowl : MonoBehaviour, IDropHandler
{
    private int count;

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        count++;
        Debug.Log(count);
    }

}
