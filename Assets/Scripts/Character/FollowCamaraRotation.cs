using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamaraRotation : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform target;

    private void Update()
    {
        Quaternion camRotation = mainCamera.transform.rotation;
        target.rotation = camRotation;
    }
}
