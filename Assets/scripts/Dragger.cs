using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Dragger : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Item item;
    [SerializeField] private GameObject modal;

    private RectTransform rectTransform;
    private Vector3 defaultPos;
    private CanvasGroup canvasGroup;

    private bool isModalPresent = false;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        defaultPos = rectTransform.anchoredPosition;
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = defaultPos;

    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!isModalPresent) 
        {
            modal = Instantiate(modal, rectTransform.transform);

            isModalPresent = true;
        }
        else{
            modal.SetActive(true);
        }
    }

    public Item getItem()
    {
        return item;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        modal.SetActive(false);
    }
}
