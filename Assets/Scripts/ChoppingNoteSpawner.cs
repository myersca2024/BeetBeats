using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingNoteSpawner : MonoBehaviour, INoteSpawner
{
    public GameManager gm;
    public Composer composer;
    public MapReader map;
    public float noteSpeed;
    public Transform lane1;
    public Transform lane2;
    public Transform judgmentBar;
    public NoteBehavior chopNote;
    public NoteBehavior peelBeginNote;
    public NoteBehavior peelEndNote;
    public List<NoteBehavior> notes = new List<NoteBehavior>();

    private float beatSetter = 0f;

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
            //lane 0 -> cutting
            //lane 1 -> peeling
            beatSetter = keyframe.beat + composer.waitBeats;
            switch (keyframe.val)
            {
                case 0: //carrot
                    SpawnNoteInLane(chopNote, 0); //quarter note
                    beatSetter = keyframe.beat + 1 + composer.waitBeats;
                    SpawnNoteInLane(peelBeginNote, 1); //dotted half
                    beatSetter = keyframe.beat + 3f + composer.waitBeats;
                    SpawnNoteInLane(peelEndNote, 1);
                    beatSetter = keyframe.beat + 4 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //quarter
                    beatSetter = keyframe.beat + 5 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //eighth
                    beatSetter = keyframe.beat + 5.5f + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //eighth
                    beatSetter = keyframe.beat + 6 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //quarter
                    beatSetter = keyframe.beat + 7 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //eighth
                    beatSetter = keyframe.beat + 7.5f + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //eighth
                    break;
                case 1: //daikon
                    SpawnNoteInLane(chopNote, 0); //quarter
                    beatSetter = keyframe.beat + 1 + composer.waitBeats;
                    SpawnNoteInLane(peelBeginNote, 1); //dotted half
                    beatSetter = keyframe.beat + 3 + composer.waitBeats;
                    SpawnNoteInLane(peelEndNote, 1);
                    beatSetter = keyframe.beat + 4 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); // Half
                    beatSetter = keyframe.beat + 6 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); // Half
                    break;
                case 2: //onion
                    SpawnNoteInLane(peelBeginNote, 1); // Whole
                    beatSetter = keyframe.beat + 3 + composer.waitBeats;
                    SpawnNoteInLane(peelEndNote, 1);
                    beatSetter = keyframe.beat + 4 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //triplet
                    beatSetter = keyframe.beat + 4.33333f + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //triplet
                    beatSetter = keyframe.beat + 4.66666f + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //triplet
                    beatSetter = keyframe.beat + 5 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //quarter
                    beatSetter = keyframe.beat + 6 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //triplet
                    beatSetter = keyframe.beat + 6.33333f + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //triplet
                    beatSetter = keyframe.beat + 6.66666f + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //triplet
                    beatSetter = keyframe.beat + 7 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); //quarter
                    break;
                case 3: //taro
                    SpawnNoteInLane(peelBeginNote, 1); // Whole
                    beatSetter = keyframe.beat + 3 + composer.waitBeats;
                    SpawnNoteInLane(peelEndNote, 1);
                    beatSetter = keyframe.beat + 4 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); // Quarter
                    beatSetter = keyframe.beat + 5 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); // Quarter
                    beatSetter = keyframe.beat + 6 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); // Quarter
                    beatSetter = keyframe.beat + 7 + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); // Eighth
                    beatSetter = keyframe.beat + 7.5f + composer.waitBeats;
                    SpawnNoteInLane(chopNote, 0); // Eighth
                    break;

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AssignSpawner();
        SpawnNotes();
        gm.NotesReady();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnNoteInLane(NoteBehavior note, int lane)
    {
        float offset = beatSetter * noteSpeed * (60 / composer.songBpm) + composer.firstBeatOffset * noteSpeed;
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
        }
    }
}
