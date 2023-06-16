using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamaraRotation : MonoBehaviour
{
    public Camera mainCamera;
    public Transform target;

    public void Update()
    {
        Quaternion camRotation = mainCamera.transform.rotation;
        target.rotation = camRotation;
    }
}
