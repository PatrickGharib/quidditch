using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSnitch : MonoBehaviour
{
  
    private Rigidbody rb;
    public Transform snitch;
    public float chaseSpeed;
    public float acceleration;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
       
       rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //clamp the velocity of each flyer, did this here because of weird ordering of physics execution in fixedupdate 
        if (rb.velocity.magnitude > chaseSpeed) { rb.velocity = rb.velocity.normalized * chaseSpeed; }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //get direction and magnitude of attractive force to snitch
        var dist =   snitch.position - transform.position;
        //add force in direction of snitch
        rb.AddForce(dist * acceleration);
        //look at snitch
        transform.rotation = Quaternion.LookRotation(dist);
        
    }
}
