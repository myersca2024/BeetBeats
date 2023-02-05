using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public Sprite pickupSprite;
    public Transform backpackTarget;
    public float speed;
    public float toBackpackSpeed;
    public bool isMoving = false;

    private SpriteRenderer sr;
    private bool toBackpack;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (toBackpack && backpackTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, backpackTarget.position, toBackpackSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, backpackTarget.position) <= 0.1f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void HitNote()
    {
        if (backpackTarget == null) { gameObject.SetActive(false); }
        sr.sprite = pickupSprite;
        isMoving = false;
        toBackpack = true;
    }
}
