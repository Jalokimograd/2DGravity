using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : GravityBody
{

    public float radius;
    public float surfaceGravity;
    public string bodyName;
    //Transform meshHolder;

    public override void EmittingGravity(IGravityObject emittingBody, List<IGravityObject> gravityObjects, float timeStep)
    {
        foreach (var otherBody in LocalBodies(gravityObjects))
        {
            if (otherBody != emittingBody)
            {
                otherBody.CalculateGravityAcceleration(emittingBody, timeStep);
            }
        }
    }

    // Selekcjonujemy ciała na które siła grawitacji od tego ciała wynosi powyżej pewnego progu
    private List<IGravityObject> LocalBodies(List<IGravityObject> gravityObjects)
    {
        return gravityObjects;
    }

    void OnValidate()
    {
        mass = surfaceGravity * radius * radius / Universe.gravitationalConstant;
        //meshHolder = transform.GetChild (0);
        //meshHolder.localScale = Vector3.one * radius;
        gameObject.name = bodyName;
    }
}
