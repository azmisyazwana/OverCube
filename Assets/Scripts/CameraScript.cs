using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;
    float minFov = 20f;
    float maxFov = 100f;
    float sensitivity = 17f;

    private void Update() {
        // if(Input.GetKey(KeyCode.Mouse0)){
        //     transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse X") * speed);
        //     transform.RotateAround(target.transform.position, transform.right, Input.GetAxis("Mouse Y") * -speed);
        // }

        // Zoom

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
