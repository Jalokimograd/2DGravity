using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float speed = 0.1f;
    public Camera Cam;

    private float _zoom = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _zoom -= Input.mouseScrollDelta.y * speed;
        if(_zoom >= 0.5) {
            Cam.orthographicSize = _zoom;
        }      
        else {
            _zoom = 0.5f;
        }
    }
}
