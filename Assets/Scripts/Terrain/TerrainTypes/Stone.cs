using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour, ITerrainElement
{
    private float mass = 1000.0f;
    private float temperature = 0.0f;

    public float Mass { get { return mass; } }
    public float Temperature { get { return temperature; } set { temperature = value; } }

}
