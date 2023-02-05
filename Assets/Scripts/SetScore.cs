using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScore : MonoBehaviour
{
    public TMP_Text text;


    void Update()
    {
        text.text = GameManager.score.ToString();
    }
}
