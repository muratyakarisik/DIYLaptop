using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickerCloseButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject pos;

    void Start()
    {
        transform.GetComponent<RectTransform>().position = pos.transform.position;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.GetComponent<RectTransform>().position = pos.transform.position;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {

    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        FindObjectOfType<Manager>().StickerCloseButton();
    }
}
