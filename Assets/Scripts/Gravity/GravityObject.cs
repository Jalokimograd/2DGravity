using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody2D))]
public class GravityObject : MonoBehaviour, IGravityObject
{

    public Vector2 initialVelocity;
    public Vector2 Velocity { get; protected set; }
    public Vector2 RBvelocity;
    public Vector2 Position { get { return rb.position; } }
    public float mass;
    public float Mass { get; protected set; }

    private bool isRigidbody;
    Rigidbody2D rb;

    void Awake()
    {
        if (isRigidbody = TryGetComponent<Rigidbody2D>(out rb))
        {
            rb.mass = mass;
        }

        Velocity = initialVelocity;
    }

    // Aktualizujemy siłę działającą na obiekt pochodządzą od innego ciała
    public void CalculateGravityAcceleration(IGravityObject gravitySourceObject, float timeStep)
    {
        float sqrDst = (gravitySourceObject.Position - this.Position).sqrMagnitude;
        Vector2 forceDir = (gravitySourceObject.Position - this.Position).normalized;
        Vector2 acceleration = forceDir * Universe.gravitationalConstant * gravitySourceObject.Mass / sqrDst;

        Velocity += acceleration * timeStep;
    }

    public void UpdatePosition(float timeStep)
    {
        RBvelocity = rb.velocity;
        rb.MovePosition(Position + Velocity * timeStep);
    }

    public virtual void EmittingGravity(IGravityObject emittingBody, List<IGravityObject> gravityObjects, float timeStep) { }

    public virtual void EmittingGravity(float timeStep)
    {
        this.EmittingGravity(NBodySimulation.Bodies, timeStep);
    }

    public virtual void EmittingGravity(List<IGravityObject> gravityObjects, float timeStep)
    {
        this.EmittingGravity(this, gravityObjects, timeStep);
    }

    public Rigidbody2D Rigidbody
    {
        get
        {
            return rb;
        }
    }

}
