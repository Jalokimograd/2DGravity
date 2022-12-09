using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBodySimulation : MonoBehaviour
{
    List<IGravityObject> bodies;
    static NBodySimulation instance;

    public bool displayCenterOfMass = false;

    // Start is called before the first frame update
    void Awake()
    {
        bodies = new List<IGravityObject>(FindObjectsOfType<ComplexObject>());
        Time.fixedDeltaTime = Universe.physicsTimeStep;
        Debug.Log("Setting fixedDeltaTime to: " + Universe.physicsTimeStep);
    }

    void FixedUpdate()
    {
        foreach (ComplexObject body in bodies)
        {
            body.EmittingGravity(Universe.physicsTimeStep);
        }

        foreach (ComplexObject body in bodies)
        {
            body.UpdatePosition(Universe.physicsTimeStep);
        }
    }

    public static List<IGravityObject> Bodies
    {
        get
        {
            return Instance.bodies;
        }
    }

    static NBodySimulation Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<NBodySimulation>();
            }
            return instance;
        }
    }
}
