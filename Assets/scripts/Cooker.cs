using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Cooker : MonoBehaviour, IDropHandler
{
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    [SerializeField] Color toastedColor;
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            Dragger dragger = eventData.pointerDrag.GetComponent<Dragger>();
            if (dragger.getItem().CanCook())
            {
                GameObject item = Instantiate(eventData.pointerDrag.gameObject, transform.parent);
                item.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                item.GetComponent<Image>().color = toastedColor;
                dragger = item.GetComponent<Dragger>();
                dragger.ResetState();
                dragger.Cook();
            }
        }
    }
}
