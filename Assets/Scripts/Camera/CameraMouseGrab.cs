using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseGrab : MonoBehaviour {

    public Vector3 grabPointMousePosition;
    public Vector3 actualRelativePosition;
    public Camera Cam;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            grabPointMousePosition = Input.mousePosition;
            actualRelativePosition = transform.position;
        }
        if (Input.GetMouseButton(0)) {
            Vector3 movement = (grabPointMousePosition - Input.mousePosition)/(700 / Cam.orthographicSize);
            transform.position = actualRelativePosition + movement;
        }
        
    }
}
