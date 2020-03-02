using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSnitch : MonoBehaviour
{
  
    private Rigidbody rb;
    public Transform snitch;
    public float chaseSpeed;
    public float acceleration;
    // Start is called before the first frame update
    void Start()
    {
       
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //look at snitch
        transform.LookAt(snitch);
        //add force in direction of snitch
        rb.AddRelativeForce(Vector3.forward*acceleration);
        //clamp the velocity of each flyer
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, chaseSpeed);
    }
}
