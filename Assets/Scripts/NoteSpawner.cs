using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public Composer composer;
    public MapReader map;
    public Transform lane1;
    public Transform lane2;
    public Transform lane3;
    public NoteBehavior quarterNote;
    public NoteBehavior eighthNote;
    public NoteBehavior sixteenthNote;

    private int keyframeIndex = 0;
    private float beatSetter = 0f;
    private List<NoteBehavior> notes = new List<NoteBehavior>();

    private void Awake()
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
        Vector3 offset = new Vector3(5 * beatSetter, 0f, 0f);

        switch (lane)
        {
            case 0:
                notes.Add(Instantiate(note, lane1.position + offset, lane1.rotation));
                break;
            case 1:
                notes.Add(Instantiate(note, lane2.position + offset, lane2.rotation));
                break;
            case 2:
                notes.Add(Instantiate(note, lane3.position + offset, lane3.rotation));
                break;
        }
    }
}
