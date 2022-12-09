using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour, IGravityObject
{

    public Vector2 initialVelocity;
    public float mass;

    protected Rigidbody2D rb;
    public Rigidbody2D Rigidbody { get { return rb; } }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.mass = mass;
        Velocity = initialVelocity;
    }

    // Aktualizujemy siłę działającą na obiekt pochodządzą od innego ciała
    public void CalculateGravityAcceleration(IGravityObject gravitySourceObject, float timeStep)
    {
        float sqrDst = (gravitySourceObject.Position - this.Position).sqrMagnitude;
        Vector2 forceDir = (gravitySourceObject.Position - this.Position).normalized;
        Vector2 acceleration = forceDir * Universe.gravitationalConstant * gravitySourceObject.Mass / sqrDst; //E = G*M/r^2

        rb.AddForce(acceleration * timeStep * mass * 100);    // F = E*m
    }

    public void UpdatePosition(float timeStep)
    {
        //RBvelocity = rb.velocity;
        //rb.MovePosition (Position + Velocity * timeStep);
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

    public Vector2 Velocity
    {
        get
        {
            if (rb)
                return rb.velocity;
            else
                return initialVelocity;
        }
        set { rb.velocity = value; }
    }

    public Vector2 Position
    {
        get
        {
            if (rb)
                return rb.position;
            else
                return transform.position;
        }
    }

    public float Mass
    {
        get
        {
            if (rb)
                return rb.mass;
            else
                return mass;
        }
    }
}
