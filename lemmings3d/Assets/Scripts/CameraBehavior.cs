using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraBehavior : MonoBehaviour
{
    public GameObject center;
    public InputAction cameraControl;

    private Vector3 moveDirection;
    private Vector3 currentDistance;
    public float maxZDistance = 25;
    public float minZDistance = 10;
    public float minYDistance = 3;
    public float maxYDistance = 20;

    void Update()
    {
        transform.LookAt(center.transform);

        moveDirection = cameraControl.ReadValue<Vector3>();

        currentDistance = this.transform.position - center.transform.position;

        Debug.Log(this.transform.position);
        Debug.Log("Current Z Dis =" + currentDistance.z);
        Debug.Log("Current Y Dis =" + currentDistance.y);
    }

    private void OnEnable()
    {
        cameraControl.Enable();   
    }

    private void OnDisable()
    {
        cameraControl.Disable();
    }

    private void FixedUpdate()
    {
        if (moveDirection.x != 0 && moveDirection.y == 0 && moveDirection.z == 0)
        {
            transform.Translate(new Vector3(moveDirection.x, 0, 0));
        }

        if (moveDirection.x == 0 && moveDirection.y != 0 && moveDirection.z == 0)
        {
            if (transform.position.y < minYDistance)
                if (moveDirection.y < 0) 
                return;

            if (transform.position.y > maxYDistance)
                if (moveDirection.y > 0)
                    return;

            transform.Translate(new Vector3(0, moveDirection.y, 0));
        }

        if (moveDirection.x == 0 && moveDirection.y == 0 && moveDirection.z != 0)
        {
            if (currentDistance.y > maxZDistance)
                if (moveDirection.z < 0)
                    return;

            if (currentDistance.y < minZDistance)
                if (moveDirection.z > 0)
                    return;

            transform.Translate(new Vector3(0, 0, moveDirection.z));
        }
    }
}
