using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelControl : MonoBehaviour
{
	//private bool tunnelCRInput;  // Clockwise Rotation for tunnel
	//private bool tunnelCCRInput; // Counterclockwise Rotation for tunnel
	//public float RotateSpeed = 180;

	void Start()
    {
        
    }

    void Update()
    {
	}

	//void LateUpdate()
 //   {
 //       tunnelCRInput = Input.GetKey(KeyCode.RightShift);
 //       tunnelCCRInput = Input.GetKey(KeyCode.Space);

 //       float clockwise = -1.0f;
 //       float counterclockwise = 1.0f;

 //       //Rigidbody rb = gameObject.GetComponent<Rigidbody>();

 //       //if (tunnelCCRInput)
 //       if (tunnelCRInput)
 //       {
 //           //rb.MoveRotation(Quaternion.AngleAxis(180.0f, Vector3.forward));
 //           transform.Rotate(Vector3.forward * clockwise * RotateSpeed);
 //       }
 //       else if (tunnelCCRInput)
 //       {
 //           //rb.MoveRotation(Quaternion.AngleAxis(-180.0f, Vector3.forward));
 //           transform.Rotate(Vector3.forward * counterclockwise * RotateSpeed);
 //       }
 //   }
	// void FixedUpdate() {
	// }
}
