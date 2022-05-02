using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    public GameObject cam;
    public GameObject vfx;

    public void CamGo1()
    {
        cam.GetComponent<Animator>().enabled = true;
    }

    public void CamGo2()
    {
        cam.GetComponent<Animator>().SetTrigger("Active2");
    }

    public void CamGo3()
    {
        FindObjectOfType<Manager>().EndTyping();
    }
}
