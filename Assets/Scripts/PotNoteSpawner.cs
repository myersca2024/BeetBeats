using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotNoteSpawner : MonoBehaviour, INoteSpawner
{
    public GameManager gm;
    public Composer composer;
    public MapReader mapReader;
    public Transform center;
    public float radius;

    void Start()
    {
        AssignSpawner();
    }

    void Update()
    {
        
    }

    public void AssignSpawner()
    {
        gm.noteSpawner = this;
    }

    public void MoveNotes()
    {
        throw new System.NotImplementedException();
    }

    public void SpawnNotes()
    {
        foreach (BeetKeyframe keyframe in mapReader.keyframes) {
            
        }
    }
}
