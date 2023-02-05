using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingField : MonoBehaviour
{
    public FarmNoteSpawner fms;
    public GameObject[] bgs;
    public float loopThreshold = -15.41f;

    private float dist;
    private int currentBack = 2;

    void Start()
    {
        dist = Mathf.Abs(bgs[0].transform.position.x - bgs[1].transform.position.x);
    }

    void Update()
    {
        for (int i = 0; i < bgs.Length; i++)
        {
            bgs[i].transform.position += new Vector3(-fms.noteSpeed * Time.deltaTime, 0, 0);
            if (bgs[i].transform.position.x <= loopThreshold)
            {
                bgs[i].transform.position = bgs[currentBack].transform.position + new Vector3(dist, 0, 0);
                currentBack = i;
            }
        }
    }
}
