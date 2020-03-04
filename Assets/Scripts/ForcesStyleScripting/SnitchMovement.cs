using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnitchMovement : MonoBehaviour
{
    private float XBoundry = 12.5f;
    private float ZBoundry = 22.5f;
    private float YMin = 5;
    private float YMax = 30f;
    public float Acceleration = 3f;
    public float MaxVelocity = 9f;
    public GameObject Rider;
    private Vector3 CenterSnitch = new Vector3(0, 5, 0);
    private Rigidbody rb;
    private ScoreKeeping sk;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sk = GetComponent<ScoreKeeping>();
    }


    void Update()
    {
        if (rb.velocity.magnitude > MaxVelocity) { rb.velocity = rb.velocity.normalized * MaxVelocity; }
        ClampBounds();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //pick a direction to travel in 
        float x = 0, y = 0, z = 0;

        var specialCoinFlip = Random.Range(0, 100);
        if (specialCoinFlip < 25)
        {
            if (specialCoinFlip < 33)
            {
                x = Random.Range(-XBoundry, XBoundry);
            }
            else if (specialCoinFlip < 66)
            {
                y = Random.Range(YMin, YMax);
            }
            else { z = Random.Range(-ZBoundry, ZBoundry); }
        }

        transform.LookAt(new Vector3(x, y, z));
        rb.AddRelativeForce(transform.forward * Acceleration, ForceMode.Impulse);

    }
    private void ClampBounds()
    {

        if (transform.position.x < -XBoundry || transform.position.x > XBoundry || transform.position.y < YMin || transform.position.y > YMax
        || transform.position.z > ZBoundry || transform.position.z < -ZBoundry)
        {
            var center = CenterSnitch - transform.position;
            rb.AddForce(center, ForceMode.Impulse);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Slytherin"))
        {
            //bool identefier for teams false = slyth
            sk.IncrementScore(false);
           
        }
        else if (collision.gameObject.tag.Equals("Gryffindor"))
        {
            sk.IncrementScore(true);
        }
        transform.position = new Vector3(Random.Range(-XBoundry, XBoundry), Random.Range(YMin, YMax), Random.Range(-ZBoundry, ZBoundry));


    }

}
