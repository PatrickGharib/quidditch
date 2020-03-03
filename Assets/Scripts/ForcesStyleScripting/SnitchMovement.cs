using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnitchMovement : MonoBehaviour
{
    private float xBoundry = 12.5f;
    private float zBoundry = 22.5f;
    private float yMin = 5;
    private float yMax = 30f;
    public float acceleration = 3f;
    public float maxVelocity = 9f;
    public GameObject rider;
    private Vector3 centerSnitch = new Vector3(0, 5, 0);
    private Rigidbody rb;
    private ScoreKeeping sk;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sk = GetComponent<ScoreKeeping>();
    }


    void Update()
    {
        if (rb.velocity.magnitude > maxVelocity) { rb.velocity = rb.velocity.normalized * maxVelocity; }
        ClampBounds();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float x = 0, y = 0, z = 0;

        var specialCoinFlip = Random.Range(0, 100);

        if (specialCoinFlip < 33)
        {
            x = Random.Range(-xBoundry, xBoundry);
        }
        else if (specialCoinFlip < 66)
        {
            y = Random.Range(yMin, yMax);
        }
        else { z = Random.Range(-zBoundry, zBoundry); }


        transform.LookAt(new Vector3(x, y, z));
        rb.AddRelativeForce(transform.forward * acceleration, ForceMode.Impulse);

    }
    private void ClampBounds()
    {

        if (transform.position.x < -xBoundry || transform.position.x > xBoundry || transform.position.y < yMin || transform.position.y > yMax
        || transform.position.z > zBoundry || transform.position.z < -zBoundry)
        {
            var center = centerSnitch - transform.position;
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
        transform.position = new Vector3(Random.Range(-xBoundry, xBoundry), Random.Range(yMin, yMax), Random.Range(-zBoundry, zBoundry));


    }

}
