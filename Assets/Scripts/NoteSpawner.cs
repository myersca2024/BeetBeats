using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
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
    public List<NoteBehavior> notes = new List<NoteBehavior>();

    private int keyframeIndex = 0;
    private float beatSetter = 0f;

    private void Start()
    {
        SpawnNotes();
    }
    
    private void SpawnNotes()
    {
        foreach (BeetKeyframe keyframe in map.keyframes)
        {
            float dec = keyframe.beat - Mathf.Floor(keyframe.beat);
            beatSetter = keyframe.beat;
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
            }
        }
    }

    private void SpawnNoteInLane(NoteBehavior note, int lane)
    {
        float offset = beatSetter * noteSpeed;
        NoteBehavior nb;
        Vector3 newPos;

        switch (lane)
        {
            case 0:
                newPos = new Vector3(judgmentBar.position.x + offset, lane1.position.y);
                nb = Instantiate(note, newPos, lane1.rotation);
                nb.speed = noteSpeed;
                notes.Add(nb);
                break;
            case 1:
                newPos = new Vector3(judgmentBar.position.x + offset, lane2.position.y);
                nb = Instantiate(note, newPos, lane2.rotation);
                nb.speed = noteSpeed;
                notes.Add(nb);
                break;
            case 2:
                newPos = new Vector3(judgmentBar.position.x + offset, lane3.position.y);
                nb = Instantiate(note, newPos, lane3.rotation);
                nb.speed = noteSpeed;
                notes.Add(nb);
                break;
        }
    }
}
