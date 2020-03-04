using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRiders : MonoBehaviour
{
    public GameObject Rider;
    [Range(5, 10)]
    public int NumPlayersTeam = 5;
    // Start is called before the first frame update
    void Start()
    {
        //spawn riders at their respective sides of the field 
        for (int i = 0; i < NumPlayersTeam*2; i++)
        {
            GameObject player = Instantiate(Rider);
            if (i % 2 == 0)
            {
                player.transform.position = transform.position = new Vector3(0, 1, (float)22.5);
                player.tag = "Slytherin";
                //change color of slytherin to green(Only change here since prefab is orange)
                Material material = player.GetComponent<Renderer>().material;
                material.color = Color.green;
            }
            else
            {
                player.transform.position = transform.position = new Vector3(0, 1, -(float)22.5);
                player.tag = "Gryffindor";
            }
        }
    }

   
}
