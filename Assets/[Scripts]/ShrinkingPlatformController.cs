//  Daekeone Lee 101076401
//  ShrinkingPlatformController.cs
//  Last Update 2021-12-17
//  Shrinking Platform Behavior

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatformController : MonoBehaviour
{
    public bool isActive;
    public float platformTimer;
    public float threshold;

    private Vector3 scale;

    private void Start()
    {
        scale = transform.localScale;
    }

    void Update()
    {

        if(isActive)
        {
            Shrinking();
        }
        else
        {
            DeShrinking();
        }

    }
    private void Reset()
    {
        scale.x = 1;
    }

    void Shrinking()
    {        
        if (scale.x > 0)
        {
            scale.x -= Time.deltaTime;
            transform.localScale = scale;
        }
        else
        {
            scale.x = 0;
        }
    }
    void DeShrinking()
    {
        if(scale.x < 1)
        {
            scale.x += Time.deltaTime;
            transform.localScale = scale;
        }
        else
        {
            scale.x = 1;
        }
    }
}
