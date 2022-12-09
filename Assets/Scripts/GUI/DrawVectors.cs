using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class DrawVectors : MonoBehaviour
{

    GravityBody[] bodies;
    public float VectorScale = 1.0f;

    public GravityBody centralBody;

    public bool _drawVelocityVector = true;
    public bool _drawAccelerationVector = true;

    // Start is called before the first frame update
    void Awake()
    {
        bodies = FindObjectsOfType<GravityBody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (centralBody)
        {
            for (int i = 0; i < bodies.Length; i++)
            {
                if (_drawVelocityVector == true)
                    DrawVelocityVector(bodies[i]);
                if (_drawAccelerationVector == true)
                    DrawAccelerationVector(bodies[i]);
            }
        }
    }

    void DrawVelocityVector(GravityBody body)
    {
        Vector2 vectorStart = body.Position;
        Vector2 vectorEnd = body.Position + (body.Velocity - centralBody.Velocity) * VectorScale;

        Debug.DrawLine(vectorStart, vectorEnd, Color.white);
    }

    void DrawAccelerationVector(GravityBody body)
    {
    }
}
