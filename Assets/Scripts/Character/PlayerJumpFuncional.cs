using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpFuncional : MonoBehaviour
{
    //public ParticleSystem dustJump;

    Rigidbody myRig;
    private PlayerJump jumpy;
    public float jumpForce = 5;
    public bool onFloor = true;

    void Awake()
    {
        myRig = GetComponent<Rigidbody>();
        jumpy = GetComponent<PlayerJump>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AnimRealJump();
        }
    }
    public void AnimRealJump()
    {
        Vector3 jumpDirection = transform.forward * myRig.velocity.magnitude;
        jumpDirection.y = jumpForce;

        myRig.velocity = jumpDirection;
        onFloor = false;

        //dustJump.Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
            //dustJump.Play();
        }
    }
}
