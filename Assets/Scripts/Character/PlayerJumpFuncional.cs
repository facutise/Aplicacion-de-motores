using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Santiago Andres Sanchez Barrio

public class PlayerJumpFuncional : MonoBehaviour
{
    private Rigidbody myRig;
    private float _jumpForce = 5f;
    public bool onFloor = true;
    private Charview view;

    public float JumpForce
    {
        get { return _jumpForce; }
        set { _jumpForce = value; }
    }

    private void Awake()
    {
        myRig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            AnimRealJump();
            onFloor = false;
        }
    }

    private void AnimRealJump()
    {
        Vector3 jumpDirection = Vector3.up * JumpForce;
        myRig.velocity += jumpDirection;
        onFloor = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }
    }
}

