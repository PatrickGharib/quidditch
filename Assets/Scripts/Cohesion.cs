using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Flyer))]
public class Cohesion : MonoBehaviour
{
    private Flyer flyer;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        flyer = GetComponent<Flyer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get local neighbourhood
        Collider[] neighbours = Physics.OverlapSphere(transform.position, radius);
        //percieved local middle position of flyer
        Vector3 midpointAverage = Vector3.zero;
        int numNeighbours = neighbours.Length;

        foreach(var neighbour in neighbours)
        {
            var distance =  neighbour.transform.position - transform.position ;
            midpointAverage += distance;
        }

        Debug.Log(flyer + ","+ numNeighbours);
        if (numNeighbours > 0)
        {
            midpointAverage = midpointAverage / numNeighbours;
            //Lerp is (a-b)*t where t is interpolant, t is bounded [0,1]
            flyer.velocity += Vector3.Lerp(Vector3.zero, midpointAverage, midpointAverage.magnitude / radius); 
        }
       
    }
}
