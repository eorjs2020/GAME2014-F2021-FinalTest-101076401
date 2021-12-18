//  Daekeone Lee 101076401
//  ShrinkingPlatformController.cs
//  Last Update 2021-12-18
//  Player is collliding with this platform will be shrinink and colliding end it we be expand until orinial scale

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatformController : MonoBehaviour
{
    public bool isActive;
    public float platformTimer;    
    private Vector3 orignalPos;
    private Vector3 scale;
    private bool expand;
    public float waitingTime;
    public AudioSource audio;
    public AudioClip[] clip;
    private bool isShrinking = false;
    private void Start()
    {

        scale = transform.localScale;
        orignalPos = transform.position;
        Invoke("Floating", 1f);
        expand = false;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (scale.x <= 0)
        {
            platformTimer += Time.deltaTime;
            if (platformTimer > waitingTime)
            {
                isActive = false;
                platformTimer = 0;
            }
            
        }
        if(isActive)
        {
            Shrinking();           
        }
        else
        {
            if (expand)
                Expand();
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
        audio.clip = clip[0];
        var check = (scale.x > 0f) ? scale.x -= Time.deltaTime : scale.x = 0;       
        transform.localScale = scale;
        expand = false;

        if (!audio.isPlaying && !isShrinking)
        {
            audio.Play();
            isShrinking = true;
        }
    }
    void Expand()
    {
        audio.clip = clip[1];
        var check = (scale.x < 1) ? scale.x += Time.deltaTime : scale.x = 1;        
        transform.localScale = scale;
        isShrinking = false;
        if (!audio.isPlaying && scale.x != 1)
        {
            audio.Play();
        }
    }
    void Floating()
    {
        transform.position = new Vector3(transform.position.x, orignalPos.y + Mathf.PingPong(Time.time * 0.2f, 0.2f), 0.0f);
    }
}
