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
    private Vector3 orignalPos;
    private Vector3 scale;
    private bool expand;
    public float waitingTime;
    private void Start()
    {
        scale = transform.localScale;
        orignalPos = transform.position;
        Invoke("Floating", 1f);
        expand = false;
    }

    void Update()
    {
        if(isActive)
        {
            Shrinking();
        }
        else
        {
            if (expand)
                Expand(expand);
            else
                platformTimer += Time.deltaTime;
            if (platformTimer > waitingTime)
            {
                expand = true;
                platformTimer = 0;
            }
            
        }
        Floating();
    }
    private void Reset()
    {
        scale.x = 1;
        transform.position = orignalPos;
    }

    void Shrinking()
    {
        var check = (scale.x > 0.1f) ? scale.x -= Time.deltaTime : scale.x = 0.01f;       
        transform.localScale = scale;
        expand = false;
    }
    void Expand(bool t)
    {
        var check = (scale.x < 1) ? scale.x += Time.deltaTime : scale.x = 1;        
        transform.localScale = scale;
    }
    void Floating()
    {
        transform.position = new Vector3(transform.position.x, orignalPos.y + Mathf.PingPong(Time.time * 0.2f, 0.2f), 0.0f);
    }
}
