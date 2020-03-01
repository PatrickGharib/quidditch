using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Flyer))]
public class FollowSnitch : MonoBehaviour
{
    private Flyer wizard;
    public Transform snitch;
    public float chaseSpeed;
    // Start is called before the first frame update
    void Start()
    {
       wizard = GetComponent<Flyer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var snitchDistance = snitch.position - transform.position;
        wizard.velocity += snitchDistance * chaseSpeed; 
    }
}
