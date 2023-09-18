using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private Variables
    public float const_accel = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        // Get the rigidbody components and update them as per the player input
        rb.AddForce(0, 0, const_accel, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Road" || collision.gameObject.name == "Road (1)" || collision.gameObject.name == "Road (2)" || collision.gameObject.name == "Road (3)")
        {
            // GetComponent<Renderer>().material.color = Color.black;
        }else{
            const_accel = 0;
            GameObject.Find("/Vehicle").GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
