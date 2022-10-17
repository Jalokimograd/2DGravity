using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualBody : IGravityObject {

    public Vector2 velocity { get; protected set; } 
    public Vector2 position { get; protected set; }
    public float mass { get; protected set; }

    private GravityObject coupledGravityObject;


    public VirtualBody (GravityObject coupledGravityObject) {
        this.velocity = coupledGravityObject.initialVelocity;
        this.position = coupledGravityObject.position;
        this.mass = coupledGravityObject.mass;
        this.coupledGravityObject = coupledGravityObject;
    }

    public void CalculateAcceleration (IGravityObject gravitySourceObject, float timeStep) {
        float sqrDst = (gravitySourceObject.position - this.position).sqrMagnitude;
        Vector2 forceDir = (gravitySourceObject.position - this.position).normalized;
        Vector2 acceleration = forceDir * Universe.gravitationalConstant * gravitySourceObject.mass / sqrDst;

        velocity += acceleration * timeStep;
    }

    public void UpdatePosition (float timeStep) {
        position = (position + velocity * timeStep);
    }

    public void EmittingGravity (IGravityObject[] gravityObjects, float timeStep) {
        coupledGravityObject.EmittingGravity(this, gravityObjects, timeStep);
    }

    public void EmittingGravity (IGravityObject emittingBody, IGravityObject[] gravityObjects, float timeStep) {
        coupledGravityObject.EmittingGravity(emittingBody, gravityObjects, timeStep);
    }

}
