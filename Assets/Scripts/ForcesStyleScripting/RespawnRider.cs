using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRider : MonoBehaviour
{
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Floor")){

            
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            if (tag.Equals("Slytherin"))
            {
                transform.position = new Vector3(0, 1, (float)22.5);
                
            }
            if(tag.Equals("Gryffindor")) 
            {
                transform.position = new Vector3(0, 1, -(float)22.5);
                 
            }
        }
    }

}
