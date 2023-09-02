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
    private bool deletable = false;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        defaultPos = rectTransform.anchoredPosition;
    }
    public void ResetState()
    {
        isModalPresent = false;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
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
        if (deletable)
        {
            Destroy(this.gameObject);
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        if (!isModalPresent) 
        {
            modal = Instantiate(modal, rectTransform.transform);

            isModalPresent = true;
        }
        else
        {
            modal.SetActive(true);
        }
    }

    public Item getItem()
    {
        return item;
    }

    public void Cook()
    {
        item = item.Cook(null);
        modal.GetComponent<Descriptor>().show();
        deletable = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        modal.SetActive(false);
    }
}
