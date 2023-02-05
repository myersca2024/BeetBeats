using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmNoteSpawner : MonoBehaviour, INoteSpawner
{
    public GameManager gm;
    public Composer composer;
    public MapReader map;
    public float noteSpeed;
    public Transform lane1;
    public Transform lane2;
    public Transform lane3;
    public Transform judgmentBar;
    public NoteBehavior quarterNote;
    public NoteBehavior eighthNote;
    public NoteBehavior sixteenthNote;
    public NoteBehavior otherNote;
    public Transform backpackTarget;
    public List<NoteBehavior> notes = new List<NoteBehavior>();

    private float beatSetter = 0f;

    private void Start()
    {
        AssignSpawner();
        SpawnNotes();
        gm.NotesReady();
    }

    public void AssignSpawner()
    {
        gm.noteSpawner = this;
    }

    public void MoveNotes()
    {
        foreach (NoteBehavior note in notes)
        {
            note.isMoving = true;
        }
    }
    
    public void SpawnNotes()
    {
        foreach (BeetKeyframe keyframe in map.keyframes)
        {
            float dec = keyframe.beat - Mathf.Floor(keyframe.beat);
            beatSetter = keyframe.beat + composer.waitBeats;
            switch (dec)
            {
                case 0f:
                    SpawnNoteInLane(quarterNote, keyframe.val);
                    break;
                case 0.5f:
                    SpawnNoteInLane(eighthNote, keyframe.val);
                    break;
                case 0.25f:
                    SpawnNoteInLane(sixteenthNote, keyframe.val);
                    break;
                default:
                    SpawnNoteInLane(otherNote, keyframe.val);
                    break;
            }
        }
    }

    private void SpawnNoteInLane(NoteBehavior note, int lane)
    {
        float offset = beatSetter * noteSpeed * (60 / composer.songBpm) - composer.firstBeatOffset * noteSpeed;
        NoteBehavior nb;
        Vector3 newPos;

        switch (lane)
        {
            case 0:
                newPos = new Vector3(judgmentBar.position.x + offset, lane1.position.y);
                nb = Instantiate(note, newPos, lane1.rotation);
                nb.speed = noteSpeed;
                nb.backpackTarget = backpackTarget;
                notes.Add(nb);
                break;
            case 1:
                newPos = new Vector3(judgmentBar.position.x + offset, lane2.position.y);
                nb = Instantiate(note, newPos, lane2.rotation);
                nb.speed = noteSpeed;
                nb.backpackTarget = backpackTarget;
                notes.Add(nb);
                break;
            case 2:
                newPos = new Vector3(judgmentBar.position.x + offset, lane3.position.y);
                nb = Instantiate(note, newPos, lane3.rotation);
                nb.speed = noteSpeed;
                nb.backpackTarget = backpackTarget;
                notes.Add(nb);
                break;
        }
    }
}
