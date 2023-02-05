using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Composer composer;
    public INoteSpawner noteSpawner;
    public Countdown countdown;
    public int score = 0;
    public int missAmount = -1;
    public int tooEarlyAmount = 1;
    public int tooLateAmount = 1;
    public int perfectAmount = 2;
    public bool gameStarted;

    private bool mapIsReady;
    private bool composerIsReady;
    private bool noteSpawnerIsReady;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

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
        //Do UI stuff here
    }

    public void TooEarly()
    {
        score += tooEarlyAmount;
        //Do UI stuff here
        Debug.Log("Too Early");
    }

    public void TooLate()
    {
        score += tooLateAmount;
        //Do UI stuff
        Debug.Log("Too Late");
    }

    public void Perfect()
    {
        score += perfectAmount;
        //Do UI 
        Debug.Log("Perfect");
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
