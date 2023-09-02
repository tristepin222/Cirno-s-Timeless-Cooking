using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollow : MonoBehaviour
{
	[SerializeField] Canvas canvas;
	[SerializeField] GameObject hand;
	void Update()
	{
		hand.transform.position = Input.mousePosition;
		float angle = AngleBetweenTwoPoints(gameObject.transform.position, Input.mousePosition);
		float distance = Vector3.Distance(GetComponent<RectTransform>().anchoredPosition, hand.GetComponent<RectTransform>().anchoredPosition);

		GetComponent<RectTransform>().sizeDelta = new Vector2(distance, 20);
		transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
