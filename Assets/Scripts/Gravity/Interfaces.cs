using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGravityObject
{
    Vector2 Position { get; }
    Vector2 Velocity { get; }
    float Mass { get; }

    void CalculateGravityAcceleration(IGravityObject gravitySourceObject, float timeStep);
    void UpdatePosition(float timeStep);

    void EmittingGravity(List<IGravityObject> gravityObjects, float timeStep);
    void EmittingGravity(IGravityObject emittingBody, List<IGravityObject> gravityObjects, float timeStep);
}


public interface ITerrainElement
{
    float Mass { get; }
    float Temperature { get; set; }

}
