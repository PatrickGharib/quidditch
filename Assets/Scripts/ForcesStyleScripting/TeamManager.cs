﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public float RiderMaxVelocity = 5;
    public float RiderMaxAcceleration = 3;
    public float AvoidanceRadius = 1;
    public float AvoidanceForce = 2;
    public float mass = 1;
    [Range(0,100)]
    public int TackleProbability;
    List<GameObject> Players = new List<GameObject>();
    private float SumCheck, NewSumCheck;
    
    // Start is called before the first frame update
    void Start()
    {

        if (tag.Equals("Slytherin")) TackleProbability = 25;
        if (tag.Equals("Gryffindor")) TackleProbability = 15;
        SumCheck = RiderMaxVelocity + RiderMaxAcceleration + AvoidanceForce + AvoidanceRadius + TackleProbability + mass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NewSumCheck = RiderMaxVelocity + RiderMaxAcceleration + AvoidanceForce + AvoidanceRadius + TackleProbability + mass;
        if (SumCheck != NewSumCheck)
        {
            //update characteristics of all players of that team
            foreach(Transform child in transform)
            {
                //change chasing characteristics 
                var followSnitch = child.GetComponent<FollowSnitch>();
                followSnitch.ChaseSpeed = RiderMaxVelocity;
                followSnitch.Acceleration = RiderMaxAcceleration;
                
                //change avoiding charactersitics
                var avoidOtherTeam = child.GetComponent<AvoidOtherTeam>();
                avoidOtherTeam.radius = AvoidanceRadius;
                avoidOtherTeam.avoidanceForce = AvoidanceForce;
                
                //change tackle Probabilities
                var tackleProbability = child.GetComponent<RespawnRider>();
                if (tackleProbability.tag.Equals("Slytherin")) tackleProbability.SlytherinTackleProb = TackleProbability;
                else tackleProbability.GryffindorTackleProb = TackleProbability;

                var rb = child.GetComponent<Rigidbody>();
                rb.mass = mass; 


            }
            SumCheck = RiderMaxVelocity + RiderMaxVelocity + AvoidanceForce + AvoidanceRadius + TackleProbability + mass;

        }
        
    }
}
