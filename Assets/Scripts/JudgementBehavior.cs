using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementBehavior : MonoBehaviour
{

    public float perfectThreshold = .1f;
    public KeyCode laneInput;
    public GameManager gm;

    private bool noteInZone = false;
    public bool holdNoteStartInZone = false;
    private bool holdNoteEndInZone = false;
    private GameObject currNote;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            noteInZone = true;
            currNote = collision.gameObject;
        }
        else if (collision.CompareTag("HoldNoteStart"))
        {
            holdNoteStartInZone = true;
            currNote = collision.gameObject;
        }
        else if (collision.CompareTag("HoldNoteEnd"))
        {
            holdNoteEndInZone = true;
            currNote = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            noteInZone = false;
            currNote = null;
        }
        else if (collision.CompareTag("HoldNoteStart"))
        {
            holdNoteStartInZone = false;
            currNote = null;
        }
        else if (collision.CompareTag("HoldNoteEnd"))
        {
            holdNoteEndInZone = false;
            currNote = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(laneInput))
        {
            if (noteInZone || holdNoteStartInZone)
            {
                float distance = this.transform.position.x - currNote.transform.position.x;
                if (Mathf.Abs(distance) <= perfectThreshold)
                {
                    gm.Perfect();
                }
                else if(distance < perfectThreshold)
                {
                    gm.TooEarly();
                }
                else if(distance > perfectThreshold)
                {
                    gm.TooLate();
                }
                currNote.GetComponent<NoteBehavior>().HitNote();
            }
            else
            {
                gm.Miss();
            }
        }
        if (Input.GetKeyUp(laneInput) && holdNoteEndInZone)
        {
            float distance = this.transform.position.x - currNote.transform.position.x;
            if (Mathf.Abs(distance) <= perfectThreshold)
            {
                gm.Perfect();
            }
            else if (distance < perfectThreshold)
            {
                gm.TooEarly();
            }
            else if (distance > perfectThreshold)
            {
                gm.TooLate();
            }
            currNote.GetComponent<NoteBehavior>().HitNote();
        }
    }
}
