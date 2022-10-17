using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent (typeof (GravityObject))]
public class DrawVelocityVector : MonoBehaviour {

    GravityObject gravityObject;
    public float VectorScale = 1.0f;
    public float Velocity;
    public Vector2 vectorStart;
    public Vector2 vectorEnd;

    // Start is called before the first frame update
    void Awake() {
        gravityObject = GetComponent<GravityObject>();
        Debug.Log ("DrawVelocityVector Awake");
    }

    // Update is called once per frame
    void Update() {
        if (!Application.isPlaying) {
            vectorStart = this.transform.position;
            vectorEnd = (Vector2)this.transform.position + gravityObject.initialVelocity * VectorScale;
        }
        else {
            vectorStart = this.transform.position;
            vectorEnd = (Vector2)this.transform.position + gravityObject.velocity * VectorScale;
            Velocity = gravityObject.velocity.magnitude;
        }
        
        Debug.DrawLine(vectorStart, vectorEnd, Color.white);
    }
}
