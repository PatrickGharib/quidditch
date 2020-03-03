using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidOtherTeam : MonoBehaviour
{
    public float radius;
    public float avoidanceForce;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] neighbours = Physics.OverlapSphere(transform.position, radius);
        Vector3 dist = Vector3.zero;
        foreach(Collider neighbour in neighbours)
        {
            if (!tag.Equals(neighbour.tag))
            {
               
                dist += (transform.position - neighbour.transform.position).normalized;
               
             
            }
        }
        dist = dist / neighbours.Length;
        rb.AddForce(-dist * avoidanceForce);
    }
}
