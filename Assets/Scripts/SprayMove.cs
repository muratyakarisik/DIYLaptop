using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SprayMove : MonoBehaviour
{
    private Vector3 lastMousePos;
    private Vector3 direction;
    private bool isfirstTouch;
    public GameObject counter;
    public GameObject[] vfx;
    public float timer;
    private float currentTimer;
    private bool isActive;
    public bool isSpray;
    public bool isPencil;
    public bool isRemove;
    public GameObject pencil;
    public GameObject remove;
    public float moveSpeed;
    public Transform removeHead;
    private bool isMove;

    void Start()
    {
        
    }

    void Update()
    {
        if (isRemove == true)
        {
            removeHead.transform.Rotate(0f, 90f * Time.deltaTime * 8f, 0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                lastMousePos = Input.mousePosition;
                currentTimer = timer;
                isActive = true;
                isMove = true;

                if (isPencil == true)
                {
                    pencil.GetComponent<Animator>().SetBool("Active", true);
                }

                if (isRemove == true)
                {
                    remove.GetComponent<Animator>().SetBool("Active", true);
                }
            }

            if (FindObjectOfType<Manager>().isFirstTouch == false)
            {
                FindObjectOfType<Manager>().swerve.SetActive(false);
                FindObjectOfType<Manager>().isFirstTouch = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isfirstTouch = false;
            isActive = false;
            isMove = false;
            if (isSpray == true)
            {
                vfx[FindObjectOfType<Manager>().sprayNumber].SetActive(false);
            }

            if (isPencil == true)
            {
                pencil.GetComponent<Animator>().SetBool("Active", false);
            }

            if (isRemove == true)
            {
                remove.GetComponent<Animator>().SetBool("Active", false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject() && isMove == true)
        {
            direction = lastMousePos - Input.mousePosition;
            lastMousePos = Input.mousePosition;
            direction = new Vector3(-direction.x, 0f, -direction.y);
            direction = direction / moveSpeed;

            if (isfirstTouch == false)
            {
                direction = Vector3.zero;
                isfirstTouch = true;
            }

            transform.position = transform.position - direction;
        }

        if (isActive == true && isSpray == true && !EventSystem.current.IsPointerOverGameObject())
        {
            currentTimer -= Time.fixedDeltaTime;

            if (currentTimer <= 0f)
            {
                vfx[FindObjectOfType<Manager>().sprayNumber].SetActive(true);
            }
        }
    }
}
