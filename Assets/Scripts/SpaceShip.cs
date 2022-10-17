using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float engineTrust = 0.0001f;
    public float rotationTrust = 0.1f;
    public float velocity;

    private Vector3 _velocityVector = new Vector3(0, 0, 0);
    private float _shipRotation = 0;

    // Start is called before the first frame update
    private void Start() {
    }

    // Update is called once per frame
    private void Update() {
        SpaceShipMovement();
        this.transform.rotation = Quaternion.Euler(0, 0, this._shipRotation);
        this.transform.position += (this._velocityVector);   //Translate(Vector3 translation, Space relativeTo = Space.Self);     np. Space.World
        this.velocity = this._velocityVector.magnitude;

        if(this._velocityVector.magnitude < 0.001) {
            this._velocityVector = this._velocityVector * 0.99f;
        }

    } 

    private void SpaceShipMovement() {
        if(Input.GetKey(KeyCode.W)) {
            this._velocityVector += this.transform.up * engineTrust;
        }
        if(Input.GetKey(KeyCode.S)) {
            this._velocityVector -= this.transform.up * engineTrust;
        }
        if(Input.GetKey(KeyCode.A)) {
            this._shipRotation += rotationTrust;
        }
        if(Input.GetKey(KeyCode.D)) {
            this._shipRotation -= rotationTrust;
        }
        if(Input.GetKey(KeyCode.E)) {
            this._velocityVector += this.transform.right * engineTrust;
        }
        if(Input.GetKey(KeyCode.Q)) {
            this._velocityVector -= this.transform.right * engineTrust;
        }
    }
}
