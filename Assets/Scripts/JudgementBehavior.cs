using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementBehavior : MonoBehaviour
{

    public float perfectThreshold = .1f;
    public KeyCode laneInput;
    public GameManager gameManager;

    public bool noteInZone = false;
    private GameObject currNote;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            noteInZone = true;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(laneInput))
        {
            if (noteInZone)
            {
                float distance = this.transform.position.x - currNote.transform.position.x;
                if (Mathf.Abs(distance) <= perfectThreshold)
                {
                    gameManager.Perfect();
                }
                else if(distance < perfectThreshold)
                {
                    gameManager.TooEarly();
                }
                else if(distance > perfectThreshold)
                {
                    gameManager.TooLate();
                }
                currNote.SetActive(false);
            }
            else
            {
                gameManager.Miss();
            }
        }
    }
}
