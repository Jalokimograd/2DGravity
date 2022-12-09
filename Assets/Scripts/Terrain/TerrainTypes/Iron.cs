using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : MonoBehaviour, ITerrainElement
{
    private float mass = 5000.0f;
    private float temperature = 0.0f;

    public float Mass { get { return mass; } }
    public float Temperature { get { return temperature; } set { temperature = value; } }

}
