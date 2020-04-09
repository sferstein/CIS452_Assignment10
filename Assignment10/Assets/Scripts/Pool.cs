using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * Pool.cs
 * Assignment 10
 * This is the pool that is being held by the object pooler.
 */

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int size;
}
