using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotNoteSpawner : MonoBehaviour, INoteSpawner
{
    public GameManager gm;
    public Composer composer;
    public MapReader mapReader;
    public Transform center;
    public NoteBehavior note;
    public float radius;
    public float measuresPerRevolution;

    private NoteBehavior[][] notesByMeasure;
    private int numMeasures;
    private int currentActiveMeasure;

    void Start()
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
        // Does nothing
    }

    public void SpawnNotes()
    {
        float approxMeasures = (mapReader.keyframes[mapReader.keyframes.Length - 1].beat + 1) / 4;
        int numMeasures = Mathf.Floor(approxMeasures) == approxMeasures ? Mathf.FloorToInt(approxMeasures) : Mathf.FloorToInt(approxMeasures) + 1;
        this.numMeasures = numMeasures;
        notesByMeasure = new NoteBehavior[numMeasures][];
        for (int i = 0; i < numMeasures; i++)
        {
            notesByMeasure[i] = new NoteBehavior[11];
        }

        int lastRecordedMeasure = 0;
        int measureIndex = 0;
        foreach (BeetKeyframe keyframe in mapReader.keyframes)
        {
            int index = Mathf.FloorToInt(keyframe.beat / 4);
            if (lastRecordedMeasure != index) { measureIndex = 0; }
            lastRecordedMeasure = index;
            //float angle = index % 2 == 0 ? keyframe.beat / 4 * 180 : 180 + (keyframe.beat / 4 * 180);
            float angle = keyframe.beat / 4 * 180;
            NoteBehavior newNote = Instantiate(note, center.transform.position + new Vector3(0, radius, 0), center.transform.rotation);
            newNote.transform.position = Quaternion.Euler(new Vector3(0, 0, angle)) * (newNote.transform.position - center.transform.position) + center.transform.position;
            notesByMeasure[index][measureIndex] = newNote;
            newNote.gameObject.SetActive(false);
            measureIndex++;
        }
    }

    public void SpawnNextMeasure()
    {
        if (currentActiveMeasure < numMeasures - 1)
        {
            foreach (NoteBehavior note in notesByMeasure[currentActiveMeasure])
            {
                if (note != null) { note.gameObject.SetActive(true); }
            }

            if (currentActiveMeasure - 2 >= 0)
            {
                foreach (NoteBehavior note in notesByMeasure[currentActiveMeasure - 2])
                {
                    if (note != null) { note.gameObject.SetActive(false); }
                }
            }
            currentActiveMeasure = Mathf.Clamp(currentActiveMeasure + 1, 0, numMeasures - 1);
        }
    }
}
