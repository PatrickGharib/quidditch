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
        //get all the colliders in surrounding area(sphere)
        Collider[] neighbours = Physics.OverlapSphere(transform.position, radius);
        Vector3 dist = Vector3.zero;
        foreach(Collider neighbour in neighbours)
        {
            //find where everyone is around you 
            dist += (transform.position - neighbour.transform.position).normalized;
        }
        dist = dist / neighbours.Length;
        //avoid them, negative avoidance will make you seek out other players instead 
        rb.AddForce(dist * avoidanceForce);
    }
}
