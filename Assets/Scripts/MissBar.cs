using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissBar : MonoBehaviour
{
    public GameManager gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note") || collision.CompareTag("HoldNoteStart") || collision.CompareTag("HoldNoteEnd"))
        {
            if (!collision.gameObject.GetComponent<NoteBehavior>().toBackpack)
            {
                gm.Miss();
                collision.gameObject.SetActive(false);
            }
        }
    }
}
