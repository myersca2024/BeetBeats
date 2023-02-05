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
    private bool targetIsTop;

    private void Start()
    {
        float beatsPerSecond = composer.songBpm / 60f;
        float speedPerMeasure = 360 / beatsPerSecond;
        speed = speedPerMeasure / pns.measuresPerRevolution;
        float beatOffset = 360 / 4 / pns.measuresPerRevolution / 2;
        transform.position = Quaternion.Euler(new Vector3(0, 0, -beatOffset)) *
                (transform.position - potCenter.transform.position) + potCenter.transform.position;
    }

    private void Update()
    {
        if (gm.gameStarted)
        {
            transform.position = Quaternion.Euler(new Vector3(0, 0, speed * Time.deltaTime)) *
                (transform.position - potCenter.transform.position) + potCenter.transform.position;

            if (targetIsTop && transform.position.y > 3.9f)
            {
                targetIsTop = false;
                pns.SpawnNextMeasure();
            }
            else if (!targetIsTop && transform.position.y < -3.9f)
            {
                targetIsTop = true;
                pns.SpawnNextMeasure();
            }
        }
    }
}
