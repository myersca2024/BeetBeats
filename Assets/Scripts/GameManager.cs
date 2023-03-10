using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Composer composer;
    public INoteSpawner noteSpawner;
    public Countdown countdown;
    public static int score = 0;
    public int missAmount = -1;
    public int tooEarlyAmount = 1;
    public int tooLateAmount = 1;
    public int perfectAmount = 2;
    public bool gameStarted;

    public GameObject ratingSpawner;
    public GameObject perfectUI;
    public GameObject lateUI;
    public GameObject earlyUI;
    public GameObject missUI;

    private bool mapIsReady;
    private bool composerIsReady;
    private bool noteSpawnerIsReady;


    // Start is called before the first frame update

    private void Update()
    {
        if (!gameStarted && mapIsReady && composerIsReady && noteSpawnerIsReady)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        countdown.StartCountdown();
        noteSpawner.MoveNotes();
        gameStarted = true;
    }

    public void Miss()
    {
        score += missAmount;
        Debug.Log("Miss");
        Instantiate(missUI, ratingSpawner.transform);
    }

    public void TooEarly()
    {
        score += tooEarlyAmount;
        //Do UI stuff here
        Instantiate(earlyUI, ratingSpawner.transform);
    }

    public void TooLate()
    {
        score += tooLateAmount;
        //Do UI stuff
        Instantiate(lateUI, ratingSpawner.transform);
    }

    public void Perfect()
    {
        score += perfectAmount;
        //Do UI 
        Instantiate(perfectUI, ratingSpawner.transform);
    }

    public void ComposerReady()
    {
        composerIsReady = true;
    }

    public void MapReady()
    {
        mapIsReady = true;
    }

    public void NotesReady()
    {
        noteSpawnerIsReady = true;
    }
}
