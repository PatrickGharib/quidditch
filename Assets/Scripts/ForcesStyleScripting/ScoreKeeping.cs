using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeping : MonoBehaviour
{
    public int slythScore { private set; get; } = 0;
    public  int gryffScore { private set; get; } = 0;
  
    //team == true then gryffScores, team == false then slythScores
    public  void IncrementScore(bool team)
    {
        //increment score
        if (team) gryffScore++;
        else slythScore++;
        Debug.Log("Gryffindor: " + gryffScore + ", " + "Slytherin: " + slythScore);
    }

}
