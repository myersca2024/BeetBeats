using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.gamedeveloper.com/audio/coding-to-the-beat---under-the-hood-of-a-rhythm-game-in-unity
public class Composer : MonoBehaviour
{
    public GameManager gm;
    public float songBpm;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float dspSongTime;
    public AudioSource musicSource;
    public float firstBeatOffset;
    public float waitBeats;
    public bool hasStarted;
    public GameObject finish;

    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        gm.ComposerReady();
    }

    public void Init()
    {
        //Start the music
        musicSource.Play();

        hasStarted = true;
    }

    private void Update()
    {
        if (hasStarted)
        {
            //determine how many seconds since the song started
            songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

            //determine how many beats since the song started
            songPositionInBeats = songPosition / secPerBeat;

            if (!musicSource.isPlaying)
            {
                finish.SetActive(true);
            }
        }
    }
}
