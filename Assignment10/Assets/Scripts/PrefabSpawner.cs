using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * PrefabSpawner.cs
 * Assignment 10
 * This spawns the object pool of prefabs.
 */

public class PrefabSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    private Vector3 mousePosition;
    private GameManager gameManager;
    public float moveSpeed = 0.1f;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        objectPooler = ObjectPooler.instance;
    }

    void FixedUpdate()
    {
        if(gameManager.isGameActive == true)
        {
            transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            objectPooler.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
        }
    }
}
