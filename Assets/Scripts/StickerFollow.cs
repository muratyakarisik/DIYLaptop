using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerFollow : MonoBehaviour
{
    public bool isFollow;

    private Vector3 lastMousePos;
    private Vector3 direction;
    private bool isfirstTouch;
    public bool isClamp;

    private void FixedUpdate()
    {
        if (isFollow == true && FindObjectOfType<Sticker>().isDragging == false && isClamp == false)
        {
            direction = lastMousePos - Input.mousePosition;
            lastMousePos = Input.mousePosition;
            direction = new Vector3(-direction.x, 0f, -direction.y);
            direction = direction / 100f;

            if (isfirstTouch == false)
            {
                direction = Vector3.zero;
                isfirstTouch = true;
            }

            Vector3 checkPos = transform.position - direction;
            
            if (checkPos.x < 14.75f && checkPos.x > 6.25f && checkPos.z > -10f && checkPos.z < -6f)
            {
                transform.position = transform.position - direction;
            }
        }
    }

    private void OnMouseDown()
    {
        isFollow = true;
    }

    private void OnMouseUp()
    {
        isFollow = false;
        isfirstTouch = false;
    }
}
