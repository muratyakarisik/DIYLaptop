using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject laptopWhite;
    public GameObject removeTool;

    public void LaptopGo1()
    {
        laptopWhite.GetComponent<Animator>().enabled = true;
    }

    public void RemoveTool()
    {
        removeTool.SetActive(true);
        FindObjectOfType<Manager>().swerve.SetActive(true);
        FindObjectOfType<Manager>().topPanel.SetActive(true);
    }
}
