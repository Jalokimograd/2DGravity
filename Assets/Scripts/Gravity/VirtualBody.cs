using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualBody : IGravityObject
{

    private Vector2 velocity;
    private Vector2 position;
    private float mass;

    public Vector2 Velocity { get { return velocity; } }
    public Vector2 Position { get { return position; } }
    public float Mass { get { return mass; } }

    private GravityBody coupledGravityObject;


    public VirtualBody(GravityBody coupledGravityObject)
    {
        this.velocity = coupledGravityObject.initialVelocity;
        this.position = coupledGravityObject.Position;
        this.mass = coupledGravityObject.Mass;
        this.coupledGravityObject = coupledGravityObject;
    }

    public void CalculateGravityAcceleration(IGravityObject gravitySourceObject, float timeStep)
    {
        float sqrDst = (gravitySourceObject.Position - this.Position).sqrMagnitude;
        Vector2 forceDir = (gravitySourceObject.Position - this.Position).normalized;
        Vector2 acceleration = forceDir * Universe.gravitationalConstant * gravitySourceObject.Mass / sqrDst;

        velocity += acceleration * timeStep;
    }

    public void UpdatePosition(float timeStep)
    {
        position = (Position + Velocity * timeStep);
    }

    public void EmittingGravity(List<IGravityObject> gravityObjects, float timeStep)
    {
        coupledGravityObject.EmittingGravity(this, gravityObjects, timeStep);
    }

    public void EmittingGravity(IGravityObject emittingBody, List<IGravityObject> gravityObjects, float timeStep)
    {
        coupledGravityObject.EmittingGravity(emittingBody, gravityObjects, timeStep);
    }
}
