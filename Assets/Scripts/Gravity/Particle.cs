using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {
    

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("collision enter");
    }

    private void OnCollisionExit2D(Collision2D other) {
        Debug.Log("collision exit");
    }
}
