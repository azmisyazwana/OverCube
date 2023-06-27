using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotatable : MonoBehaviour
{
    [SerializeField] private InputAction pressed, axis;
    [SerializeField] private float speed = 1f;
    [SerializeField] private bool isInverted;

    private Vector2 rotation;
    private bool rotateAllowed;
    private Transform cam;
    private float rotationSpeed = 100;

    private void Awake()
    {
        cam = Camera.main.transform;

        pressed.Enable();
        axis.Enable();

        pressed.started += _ => { if (gameObject.activeSelf) StartCoroutine(Rotate()); };
        pressed.canceled += _ => { rotateAllowed = false; };
        axis.performed += context => { rotation = context.ReadValue<Vector2>(); };
    }

    private void Update()
    {
        if (!gameObject.activeSelf)
            return;

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime, Space.Self);
        }
    }

    private IEnumerator Rotate()
    {
        rotateAllowed = true;
        while (rotateAllowed)
        {
            rotation *= speed;
            transform.Rotate(Vector3.up * (isInverted ? 1 : -1), rotation.x, Space.World);
            transform.Rotate(cam.right * (isInverted ? -1 : 1), rotation.y, Space.World);
            yield return null;
        }
    }
}
