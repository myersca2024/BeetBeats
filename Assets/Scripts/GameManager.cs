using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public int missAmount = -1;
    public int tooEarlyAmount = 1;
    public int tooLateAmount = 1;
    public int perfectAmount = 2;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void Miss()
    {
        score += missAmount;
        Debug.Log("Miss");
        //Do UI stuff here
    }

    public void TooEarly()
    {
        score += tooEarlyAmount;
        //Do UI stuff here
        Debug.Log("Too Early");
    }

    public void TooLate()
    {
        score += tooLateAmount;
        //Do UI stuff
        Debug.Log("Too Late");
    }

    public void Perfect()
    {
        score += perfectAmount;
        //Do UI 
        Debug.Log("Perfect");
    }
}