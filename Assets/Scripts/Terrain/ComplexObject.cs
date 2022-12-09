using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ComplexObject : MonoBehaviour, IGravityObject
{
    public GameObject ComplexElementPrefab;
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
            return transform.position;
        }
    }
    public Vector2 CenterOfMass
    {
        get
        {
            return rb.centerOfMass;
        }

        protected set
        {
            Vector3 shift = value;
            rb.position += value;

            foreach (Transform child in Children_Components)
            {
                child.transform.localPosition -= shift;
            }

            rb.centerOfMass = Vector2.zero;
        }
    }
    public float Mass
    {
        get
        {
            return rb.mass;
        }

        protected set
        {
            rb.mass = value;
        }
    }
    public Vector2 initialVelocity;
    public List<Transform> Children_Components;// { get; protected set; }
    protected Rigidbody2D rb;
    public Rigidbody2D Rigidbody { get { return rb; } }

    void Awake()
    {
        Children_Components = GetChildren(transform);

        rb = GetComponent<Rigidbody2D>();

        Velocity = initialVelocity;
        Mass = initMass(Children_Components);
        CenterOfMass = initCenterOfMass(Children_Components);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Position, 0.06f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(rb.position, 0.04f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(CenterOfMass, 0.02f);

    }

    public void CalculateGravityAcceleration(IGravityObject gravitySourceObject, float timeStep)
    {
        float sqrDst = (gravitySourceObject.Position - this.Position).sqrMagnitude;
        Vector2 forceDir = (gravitySourceObject.Position - this.Position).normalized;
        Vector2 acceleration = forceDir * Universe.gravitationalConstant * gravitySourceObject.Mass / sqrDst; //E = G*M/r^2

        rb.AddForce(acceleration * timeStep * Mass * 100);    // F = E*m
    }

    private void connection(ComplexObject otherComplexObject)
    {

        // aktualizacja środka masy
        Vector2 distance = otherComplexObject.Position - this.Position;
        Vector2 centerOfMassChange = distance * otherComplexObject.Mass / (this.Mass + otherComplexObject.Mass);
        this.CenterOfMass = centerOfMassChange;  // ustawienie CenterOfMass to tak na prawdę przesunięcie względem aktualnego

        // aktualizacja masy
        this.Mass = this.Mass + otherComplexObject.Mass;

        // aktualizacja elementów składowych
        Children_Components.AddRange(otherComplexObject.Children_Components);

        foreach (Transform child in otherComplexObject.Children_Components)
        {
            child.SetParent(this.transform);
        }

        // zniszczenie drugiego obiektu odbywa się na poziomie GameObject a nie klasy ComplexObject
        NBodySimulation.Bodies.Remove(otherComplexObject);
        Destroy(otherComplexObject.gameObject);
    }

    private void separation(Transform children_Component)
    {
        GameObject new_terrain_object = GameObject.Instantiate(ComplexElementPrefab);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        ComplexObject otherComplexObject = collision.gameObject.GetComponent<ComplexObject>();

        // Podczas kolizji następuję połączenie obiektów. Mamy tutaj jednoznaczne rozróżnienie obiektów
        if (this.gameObject.GetInstanceID() > otherComplexObject.gameObject.GetInstanceID())
        {
            Debug.Log(gameObject.name);
            //this.connection(otherComplexObject);
        }
    }

    // Selekcjonujemy ciała na które siła grawitacji od tego ciała wynosi powyżej pewnego progu
    private List<IGravityObject> LocalBodies(List<IGravityObject> gravityObjects)
    {
        return gravityObjects;
    }

    public void EmittingGravity(IGravityObject emittingBody, List<IGravityObject> gravityObjects, float timeStep)
    {
        foreach (var otherBody in LocalBodies(gravityObjects))
        {
            if (otherBody != emittingBody)
            {
                otherBody.CalculateGravityAcceleration(emittingBody, timeStep);
            }
        }
    }

    public virtual void EmittingGravity(float timeStep)
    {
        this.EmittingGravity(NBodySimulation.Bodies, timeStep);
    }

    public virtual void EmittingGravity(List<IGravityObject> gravityObjects, float timeStep)
    {
        this.EmittingGravity(this, gravityObjects, timeStep);
    }

    public void UpdatePosition(float timeStep)
    {
        //RBvelocity = rb.velocity;
        //rb.MovePosition (Position + Velocity * timeStep);
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in parent)
        {
            children.Add(child);
        }
        return children;
    }


    private float initMass(List<Transform> children)
    {
        float complexMass = 0.0f;

        foreach (Transform child in children)
        {
            complexMass += child.GetComponent<ITerrainElement>().Mass;
            Debug.Log("childe mass: " + child.GetComponent<ITerrainElement>().Mass);
        }
        Debug.Log(complexMass);
        return complexMass;
    }

    private Vector2 initCenterOfMass(List<Transform> children)
    {
        Vector3 centerOfMass = Vector3.zero;
        float complexMass = 0.0f;

        foreach (Transform child in children)
        {
            Vector2 distance = child.transform.localPosition - centerOfMass;

            float nextElementMass = child.GetComponent<ITerrainElement>().Mass;
            Vector3 shift = distance * nextElementMass / (complexMass + nextElementMass);
            centerOfMass += shift;
            complexMass += nextElementMass;
            Debug.Log(centerOfMass);
        }

        //Debug.Log(centerOfMass);
        return centerOfMass;
    }
}
