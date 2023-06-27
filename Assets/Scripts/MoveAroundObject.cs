using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundObject : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 3f;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceFromTarget = 3f;
    [SerializeField] private float smoothTime = 0.2f;

    private float rotationY; 
    private float rotationX; 
    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;
    private bool isMiddleMouseButtonPressed = false;


    private void Update() {
        if (Input.GetMouseButtonDown(2))
        {
            isMiddleMouseButtonPressed = true;
        }
        else if (Input.GetMouseButtonUp(2))
        {
            isMiddleMouseButtonPressed = false;
        }

        if(isMiddleMouseButtonPressed){
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;


            rotationY += mouseX;
            rotationX += mouseY;



            rotationX = Mathf.Clamp(rotationX, -40, 40);

            Vector3 nextRotation = new Vector3(rotationX, rotationY);
            currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);

            // Debug.Log(currentRotation);

            transform.localEulerAngles = currentRotation;


            transform.position = target.position - transform.forward * distanceFromTarget;


        }
        
    }
}
