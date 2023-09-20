using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
		public float const_accel = 5.0f;
		public float flySpeed = 25.0f;
		public float turnSpeed = 25.0f;
		private float flyInput;
		private float horizontalInput;
		
    void Start()
    {
        //GameObject tunnelCube = GameObject.Find("/Tunnel/Cube");
        //transform.position = tunnelCube.position + new Vector3(0.0f, 0.2f, 0.0f);
    }

    void Update()
    {
        // flyInput = Input.GetAxis("Vertical");
		// horizontalInput = Input.GetAxis("Horizontal");

		// transform.Rotate(Vector3.left * flySpeed * flyInput * Time.deltaTime);
		// transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
		transform.Translate(Vector3.forward * const_accel * Time.deltaTime);


        // Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        // rb.MovePosition(rb.position + Vector3.forward * const_accel * Time.deltaTime);
        int min_y = int.MaxValue, min_index = 0;
        GameObject tunnelObj = GameObject.Find("/Tunnel");
        int childCount = tunnelObj.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform childTransform = tunnelObj.transform.GetChild(i);
            if (min_y < childTransform.position.y)
            {
                min_index = i;
            }
        }
        Transform minChild = tunnelObj.transform.GetChild(min_index);
        float distance = Vector3.Dot(-minChild.up, (transform.position - minChild.up));
        if (distance > 0)
        {
            GameObject tunnelCube = GameObject.Find("/Tunnel/Cube");
            tunnelCube.GetComponent<Renderer>().material.color = Color.red;

            transform.position += 3 * (1 + distance) * minChild.up;
        }
    }

	//void LateUpdate()
	//{
	//}

	//private void OnCollisionEnter(Collision collision)
	//{
	//	// Destroy(gameObject);
	//	const_accel = 0;
	//	flySpeed = 0;
	//	turnSpeed = 0;

	//	GameObject.Find("/Player/Cube").GetComponent<Renderer>().material.color = Color.red;
	//	// if (collision.gameObject.name == "Plane") {
	//	// 		GetComponent<Renderer>().material.color = Color.black;
	//	// }
	//}
}
