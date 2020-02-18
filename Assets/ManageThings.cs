using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageThings : MonoBehaviour
{
    //create variables for prefabs 
    public GameObject snitch;
    public GameObject gryf;
    public GameObject Slyth;
    public ArrayList<GameObject> boids = new ArrayList<GameObject>;

    //control the number of players spawned for each team 
    public int numGryf;
    public int numSlyth;

    // spawn initial number of players and 1 snitch
    void Start()
    {
        GameObject.Instantiate(snitch);
        SpawnPlayers(gryf, numGryf);
        SpawnPlayers(gryf, numSlyth);
                      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnPlayers(GameObject team, int numPlayers)
    {
        for (int i = 0; i < numPlayers; i++)
        {
          GameObject.Instantiate(team).transform.SetParent(this.transform);
        }
    }
}
