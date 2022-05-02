using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveVFX : MonoBehaviour
{
    public GameObject vfx;
    private bool isStart;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void StartVFX()
    {
        if (isStart == false)
        {
            vfx.SetActive(true);
            isStart = true;
        }
    }

    public void StopVFX()
    {
        if (isStart == true)
        {
            vfx.SetActive(false);
            isStart = false;
        }
    }
}
