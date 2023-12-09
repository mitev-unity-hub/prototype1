using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropellerX : MonoBehaviour
{

    private float rotateSpeed = 100.0f;
    private Vector3 propellerRotation = new Vector3 (0, 0, 1);
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
        // the same as the above
        //transform.Rotate(propellerRotation * Time.deltaTime * rotateSpeed);
    }
}
