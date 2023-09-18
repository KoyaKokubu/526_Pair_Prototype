using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelControl : MonoBehaviour
{
    private bool tunnelCRInput;  // Clockwise Rotation for tunnel
    private bool tunnelCCRInput; // Counterclockwise Rotation for tunnel
    public float RotateSpeed = 90;

    void Start()
    {

    }

    void Update()
    {
        tunnelCRInput = Input.GetKey(KeyCode.RightShift);
        tunnelCCRInput = Input.GetKey(KeyCode.Space);

        float clockwise = -1.0f;
        float counterclockwise = 1.0f;

        if (tunnelCRInput)
        {
            transform.Rotate(Vector3.forward * clockwise * RotateSpeed * Time.deltaTime);
        }
        else if (tunnelCCRInput)
        {
            transform.Rotate(Vector3.forward * counterclockwise * RotateSpeed * Time.deltaTime);
        }
    }
}
