using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public Composer composer;
    public GameObject[] popUps;

    private float timer;
    private bool countdownStarted;
    private bool countdownFinished;
    private float beat0;
    private float beat1;
    private float beat2;
    private float beat3;
    private float lastBeat;
    private bool beat0Played;
    private bool beat1Played;
    private bool beat2Played;
    private bool beat3Played;

    private void Update()
    {
        if (countdownStarted && !countdownFinished)
        {
            timer += Time.deltaTime;

            if (!beat0Played && timer >= beat0)
            {
                beat0Played = true;
                DisplayOnBeat(0);
            }
            else if (!beat1Played && timer >= beat1)
            {
                beat1Played = true;
                DisplayOnBeat(1);
            }
            else if (!beat2Played && timer >= beat2)
            {
                beat2Played = true;
                DisplayOnBeat(2);
            }
            else if (!beat3Played && timer >= beat3)
            {
                beat3Played = true;
                DisplayOnBeat(3);
            }
            else if (beat0Played && beat1Played && beat2Played && beat3Played && timer >= lastBeat)
            {
                ClearPopUps();
                composer.Init();
                countdownFinished = true;
            }
        }
    }

    private void DisplayOnBeat(int beat)
    {
        ClearPopUps();
        popUps[beat].SetActive(true);
    }

    private void ClearPopUps()
    {
        foreach (GameObject popUp in popUps)
        {
            popUp.SetActive(false);
        }
    }

    public void StartCountdown()
    {
        beat0 = 4f * composer.secPerBeat;
        beat1 = 5f * composer.secPerBeat;
        beat2 = 6f * composer.secPerBeat;
        beat3 = 7f * composer.secPerBeat;
        lastBeat = beat3 + 0.5f;
        countdownStarted = true;
    }
}
