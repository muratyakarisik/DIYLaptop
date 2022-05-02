using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        FindObjectOfType<Sticker>().isDragging = true;
        FindObjectOfType<Sticker>().lastMousePos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        FindObjectOfType<Sticker>().isDragging = false;
    }
}
