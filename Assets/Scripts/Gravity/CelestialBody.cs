using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : GravityObject {

    public float radius;
    public float surfaceGravity;
    public string bodyName = "Unnamed";
    //Transform meshHolder;
    
    public override void EmittingGravity (IGravityObject emittingBody, IGravityObject[] gravityObjects, float timeStep) {
        foreach (var otherBody in LocalBodies(gravityObjects)) {
            if (otherBody != emittingBody) {
                otherBody.CalculateAcceleration(emittingBody, timeStep);
            }
        }
    }

    // Selekcjonujemy ciała na które siła grawitacji od tego ciała wynosi powyżej pewnego progu
    private IGravityObject[] LocalBodies (IGravityObject[] gravityObjects) {
        return gravityObjects;
    }

    void OnValidate () {
        mass = surfaceGravity * radius * radius / Universe.gravitationalConstant;
        //meshHolder = transform.GetChild (0);
        //meshHolder.localScale = Vector3.one * radius;
        gameObject.name = bodyName;
    }
}
