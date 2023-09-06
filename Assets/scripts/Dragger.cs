using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Dragger : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Item item;
    [SerializeField] private GameObject modal;
    [SerializeField] private AudioSource grab;
    [SerializeField] private Cooker cooker;
    private HandFollow handFollow;
    private RectTransform rectTransform;
    private Vector3 defaultPos;
    private CanvasGroup canvasGroup;

    private bool isModalPresent = false;
    private bool blockt = false;
    private Transform hand;
    private int index = 0;
    public bool deletable = false;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        defaultPos = rectTransform.anchoredPosition;
    }
    private void Start()
    {
        if (GlobalController.Instance.wasBad)
        {
            GlobalController.Instance.blockt = true;
        }
        GlobalController.Instance.isDragging = false;
        cooker = GameObject.Find("Pot").GetComponent<Cooker>();
        handFollow = FindObjectOfType<HandFollow>();
        hand = GameObject.Find("Hand").transform;
        index = transform.GetSiblingIndex();
    }
    public void ResetState()
    {
        isModalPresent = false;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {

        grab.Play();
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (item.IsCook())
        {
            cooker.ChangeSprite();
        }
        GlobalController.Instance.isDragging = true;
        transform.SetSiblingIndex(hand.GetSiblingIndex() - 2);
        handFollow.Grab();
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        transform.SetSiblingIndex(index);
        handFollow.Release();
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = defaultPos;
        GlobalController.Instance.isDragging = false;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!GlobalController.Instance.isDragging)
        {
            if (!GlobalController.Instance.blockt)
            {
                modal.SetActive(true);
                modal.GetComponent<Descriptor>().show(item);
            }
        }
    }

    public Item getItem()
    {
        return item;
    }

    public void Cook()
    {
        item = item.Cook(null);
        modal.GetComponent<Descriptor>().show(item);
        deletable = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        modal.SetActive(false);
    }
}
