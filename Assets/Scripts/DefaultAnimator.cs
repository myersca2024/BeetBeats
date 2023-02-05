using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAnimator : MonoBehaviour
{
    public Sprite[] sprites;
    public float animTime;

    private SpriteRenderer sr;
    private int curIndex = 0;
    private float timer = 0f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= animTime)
        {
            curIndex = (curIndex + 1) % sprites.Length;
            sr.sprite = sprites[curIndex];
            timer = 0;
        }
    }
}
