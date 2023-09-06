using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HandFollow : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject hand;
    [SerializeField] GameObject hand2;
    [SerializeField] Image sr;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite cirnoGrab;
    [SerializeField] Sprite handGrab;
    [SerializeField] Sprite handRelease;
    [SerializeField] private Animator animator;

    private float time;
    private float seconds = 700;
    private float percent;
    private Vector3 defaultPos;
    private Vector2 defaultSize;
    private void Start()
    {
        GetComponent<Image>().enabled = false;
        hand2.GetComponent<Image>().enabled = false;
        defaultPos = transform.position;
        defaultSize = GetComponent<RectTransform>().sizeDelta;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetComponent<Image>().enabled = true;
            hand2.GetComponent<Image>().enabled = true;
            animator.enabled = false;
            sr.sprite = cirnoGrab;
            hand.transform.position = Input.mousePosition;

            var step = seconds * canvas.scaleFactor * Time.deltaTime; // calculate distance to move
            hand2.transform.position = Vector3.MoveTowards(hand2.transform.position, hand.transform.position + new Vector3(0.2f, 0.2f, 0.2f), step);


            float angle = AngleBetweenTwoPoints(gameObject.transform.position, hand2.transform.position);

            float distance = Vector3.Distance(GetComponent<RectTransform>().anchoredPosition, hand2.GetComponent<RectTransform>().anchoredPosition);


            GetComponent<RectTransform>().sizeDelta = new Vector2(distance, 20);
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            angle = AngleBetweenTwoPoints(hand2.transform.position, hand.transform.position);
            hand2.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));


        }
        else
        {
            animator.enabled = true;
            GetComponent<Image>().enabled = false;
            hand2.GetComponent<Image>().enabled = false;
            sr.sprite = defaultSprite;
            hand2.transform.position = defaultPos;
            transform.position = defaultPos;
            GetComponent<RectTransform>().sizeDelta = defaultSize;
        }
    }

    public void Grab()
    {
        hand2.GetComponent<Image>().sprite = handGrab;
    }

    public void Release()
    {
        hand2.GetComponent<Image>().sprite = handRelease;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
