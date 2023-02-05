using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBeetmanAnimation : MonoBehaviour
{
    public GameManager gm;
    public Composer composer;
    public Sprite[] sprites;

    private SpriteRenderer sr;
    private int curIndex = 0;
    private float timer = 0f;

    void Start()
    {
        timer = composer.firstBeatOffset + 0.1f;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (gm.gameStarted)
        {
            timer += Time.deltaTime;
            if (timer >= 60f / composer.songBpm)
            {
                curIndex = (curIndex + 1) % 4;
                sr.sprite = sprites[curIndex];
                timer = 0;
            }
        }
    }
}
