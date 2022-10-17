using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (Rigidbody2D))]
public class GravityObject : MonoBehaviour, IGravityObject {

    public Vector2 initialVelocity;
    public Vector2 velocity { get; protected set; } 
    public Vector2 position { get {return rb.position;} }
    public float mass { get; protected set; }
    Rigidbody2D rb;

    void Awake () {
        rb = GetComponent<Rigidbody2D> ();
        rb.mass = mass;
        velocity = initialVelocity;
    }

    // Aktualizujemy siłę działającą na obiekt pochodządzą od innego ciała
    public void CalculateAcceleration (IGravityObject gravitySourceObject, float timeStep) {
        float sqrDst = (gravitySourceObject.position - this.position).sqrMagnitude;
        Vector2 forceDir = (gravitySourceObject.position - this.position).normalized;
        Vector2 acceleration = forceDir * Universe.gravitationalConstant * gravitySourceObject.mass / sqrDst;

        velocity += acceleration * timeStep;
    }

    public void UpdatePosition (float timeStep) {
        rb.MovePosition (position + velocity * timeStep);
    }

    public virtual void EmittingGravity (IGravityObject emittingBody, IGravityObject[] gravityObjects, float timeStep) {}

    public virtual void EmittingGravity (float timeStep) {
        this.EmittingGravity(NBodySimulation.Bodies, timeStep);
    }

    public virtual void EmittingGravity (IGravityObject[] gravityObjects, float timeStep) {
        this.EmittingGravity(this, gravityObjects, timeStep);
    }

    public Rigidbody2D Rigidbody {
        get {
            return rb;
        }
    }

    public Vector2 Position {
        get {
            return rb.position;
        }
    }

}
