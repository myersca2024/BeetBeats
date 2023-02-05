using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotBarMovement : MonoBehaviour
{
    public GameManager gm;
    public PotNoteSpawner pns;
    public Composer composer;
    public Transform potCenter;

    private float speed;

    private void Start()
    {
        float beatsPerSecond = composer.songBpm / 60f;
        float speedPerMeasure = 360 / beatsPerSecond;
        speed = speedPerMeasure / pns.measuresPerRevolution;
    }

    private void Update()
    {
        if (gm.gameStarted)
        {
            transform.position = Quaternion.Euler(new Vector3(0, 0, speed * Time.deltaTime)) *
                (transform.position - potCenter.transform.position) + potCenter.transform.position;
        }
    }
}
