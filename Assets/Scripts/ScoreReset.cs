using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReset : MonoBehaviour
{
    void Start()
    {
        GameManager.score = 0;
    }
}
