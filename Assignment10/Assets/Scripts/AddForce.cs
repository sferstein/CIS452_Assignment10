using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * GameManager.cs
 * Assignment 10
 * This adds a force to the object pool to destroy the cubes.
 */

[RequireComponent(typeof(Rigidbody))]
public class AddForce : MonoBehaviour
{
    public float forwardForce = 1;
    public float sideForce = .1f;

    private void Start()
    {
        float zForce = Random.Range(forwardForce / 2, forwardForce);

        Vector3 force = new Vector3(0, 0, zForce);
        
        GetComponent<Rigidbody>().velocity = force;
    }

    private void Update()
    {
        if(transform.position.z >= 0)
        {
            GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(0, 0, 255);
        }
    }
}
