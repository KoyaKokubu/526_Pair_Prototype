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
        
    }

    void Update()
    {
        flyInput = Input.GetAxis("Vertical");
				horizontalInput = Input.GetAxis("Horizontal");

				transform.Rotate(Vector3.left * flySpeed * flyInput * Time.deltaTime);
				transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
				transform.Translate(Vector3.forward * const_accel * Time.deltaTime);
    }

		private void OnCollisionEnter(Collision collision) {
				// Destroy(gameObject);
				const_accel = 0;
				flySpeed = 0;
				turnSpeed = 0;
				
				GameObject.Find("/Player/Cube").GetComponent<Renderer>().material.color = Color.red;
				// if (collision.gameObject.name == "Plane") {
				// 		GetComponent<Renderer>().material.color = Color.black;
				// }
		}
}
