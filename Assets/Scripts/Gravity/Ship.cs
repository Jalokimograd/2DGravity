using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : GravityBody {
    
    public float engineTrust = 0.0001f;
    public float rotationTrust = 0.1f;

    private Vector2 _acceleration = new Vector2(0, 0);
    private float _rotation = 0;

    private void Update() {  
        SpaceShipMovement();

        //rb.AddForce(_acceleration * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(0, 0, this._rotation);
    } 

    private void SpaceShipMovement() {
        if(Input.GetKey(KeyCode.W)) {
            _acceleration += (Vector2)this.transform.up * engineTrust;
        }
        if(Input.GetKey(KeyCode.S)) {
            _acceleration -= (Vector2)this.transform.up * engineTrust;
        }
        if(Input.GetKey(KeyCode.A)) {
            _rotation += rotationTrust;
        }
        if(Input.GetKey(KeyCode.D)) {
            _rotation -= rotationTrust;
        }
    }
}
