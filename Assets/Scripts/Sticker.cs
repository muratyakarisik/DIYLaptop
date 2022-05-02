using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticker : MonoBehaviour
{
    public bool isDragging;
    public float currentScale;
    public float minScale;
    public float maxScale;
    public GameObject sticker;

    public Vector3 lastMousePos;
    public GameObject pos;

    void Start()
    {
        transform.GetComponent<RectTransform>().position = pos.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            transform.position = pos.transform.position;
            isDragging = false;
        }
    }

    private void FixedUpdate()
    {
        transform.GetComponent<RectTransform>().position = pos.transform.position;

        if (isDragging == true)
        {
            if (Input.GetMouseButton(0))
            {
                if (lastMousePos.x > Input.mousePosition.x)
                {
                    if (lastMousePos.y < Input.mousePosition.y)
                    {
                        float dis = Vector3.Distance(lastMousePos, Input.mousePosition);
                        dis = dis / 1000f;
                        currentScale = sticker.transform.localScale.x;

                        if (currentScale - dis < minScale)
                        {
                            sticker.transform.localScale = new Vector3(minScale, 1f, minScale);
                        }
                        else
                        {
                            sticker.transform.localScale = new Vector3(currentScale - dis, 1f, currentScale - dis);
                        }

                        lastMousePos = Input.mousePosition;
                    }
                }
                else if (lastMousePos.x < Input.mousePosition.x)
                {
                    if (lastMousePos.y > Input.mousePosition.y)
                    {
                        float dis = Vector3.Distance(lastMousePos, Input.mousePosition);
                        dis = dis / 1000f;
                        currentScale = sticker.transform.localScale.x;

                        if (currentScale + dis > maxScale)
                        {
                            sticker.transform.localScale = new Vector3(maxScale, 1f, maxScale);
                        }
                        else
                        {
                            sticker.transform.localScale = new Vector3(currentScale + dis, 1f, currentScale + dis);
                        }

                        lastMousePos = Input.mousePosition;
                    }
                }
            }
        }
    }
}

