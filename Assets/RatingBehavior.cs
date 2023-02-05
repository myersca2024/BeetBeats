using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingBehavior : MonoBehaviour
{
    public float speed = 0.5f;
    public float lifetime = 1f;

    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

    private void Update()
    {
        Vector3 up = new Vector3(0f, speed, 0f);
        this.GetComponent<RectTransform>().position += up;
    }
}
