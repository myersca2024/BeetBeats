using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public float speed;
    public bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
    }
}
