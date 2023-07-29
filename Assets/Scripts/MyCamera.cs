using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Lucas Torres

public class MyCamera : MonoBehaviour
{
    public Vector3 offset;
    private Transform target;
    [Range(0, 1)] public float lerpValue;
    public float sensibility;

    public bool canMoveCamera;

    void Start()
    {
        canMoveCamera = true;
        Cursor.lockState = CursorLockMode.Locked;
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        if (canMoveCamera == false)
        {

        }
        else if (canMoveCamera == true)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibility, Vector3.up) * offset;
            transform.LookAt(target);
        }
    }
}

