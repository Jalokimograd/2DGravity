using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBodySimulation : MonoBehaviour
{
    GravityObject[] bodies;
    static NBodySimulation instance;

    // Start is called before the first frame update
    void Awake() {
        bodies = FindObjectsOfType<GravityObject> ();
        Time.fixedDeltaTime = Universe.physicsTimeStep;
        Debug.Log ("Setting fixedDeltaTime to: " + Universe.physicsTimeStep);
    }

    void FixedUpdate () {
        for (int i = 0; i < bodies.Length; i++) {
            bodies[i].EmittingGravity(Universe.physicsTimeStep);
        }

        for (int i = 0; i < bodies.Length; i++) {
            bodies[i].UpdatePosition (Universe.physicsTimeStep);
        }
    }

    public static GravityObject[] Bodies {
        get {
            return Instance.bodies;
        }
    }

    static NBodySimulation Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<NBodySimulation> ();
            }
            return instance;
        }
    }
}
