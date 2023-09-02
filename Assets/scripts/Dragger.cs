using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Dragger : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Item item;
    [SerializeField] private GameObject modal;

    private HandFollow handFollow;
    private RectTransform rectTransform;
    private Vector3 defaultPos;
    private CanvasGroup canvasGroup;

    private bool isModalPresent = false;

    private Transform hand;
    public bool deletable = false;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        defaultPos = rectTransform.anchoredPosition;
    }
    private void Start()
    {
        handFollow = FindObjectOfType<HandFollow>();
        hand = GameObject.Find("Hand").transform;
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
        transform.SetSiblingIndex(hand.GetSiblingIndex() - 2);
        handFollow.Grab();
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        handFollow.Release();
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = defaultPos;
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
