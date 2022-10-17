using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGravityObject {
    Vector2 position { get; }
    float mass { get; }

    void CalculateAcceleration (IGravityObject gravitySourceObject, float timeStep); 
    void UpdatePosition (float timeStep);
    
    void EmittingGravity (IGravityObject[] gravityObjects, float timeStep);
    void EmittingGravity (IGravityObject emittingBody, IGravityObject[] gravityObjects, float timeStep);
}
