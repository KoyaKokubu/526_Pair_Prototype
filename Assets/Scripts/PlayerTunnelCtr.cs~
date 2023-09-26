using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTunnelCtr : MonoBehaviour
{
    public float const_accel = 5.0f;
    private bool tunnelCRInput;  // Clockwise Rotation for tunnel
    private bool tunnelCCRInput; // Counterclockwise Rotation for tunnel
    public float RotateSpeed = 30;
    public float RotateInstant = 90;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float min_y = float.MaxValue;
        int min_index = 0;
        GameObject tunnelObj = GameObject.Find("/Tunnel");
        transform.Translate(Vector3.forward * const_accel * Time.deltaTime);

        //
        horizontalInput = -Input.GetAxis("Horizontal");
        tunnelCRInput = Input.GetKeyDown(KeyCode.RightShift);
        tunnelCCRInput = Input.GetKeyDown(KeyCode.Space);

        float clockwise = -1.0f;
        float counterclockwise = 1.0f;

        tunnelObj.transform.Rotate(Vector3.forward * horizontalInput * RotateSpeed * Time.deltaTime);

        if (tunnelCRInput)
        {
            tunnelObj.transform.Rotate(Vector3.forward * clockwise * RotateInstant);
        }
        else if (tunnelCCRInput)
        {
            tunnelObj.transform.Rotate(Vector3.forward * counterclockwise * RotateInstant);
        }
        //

        int childCount = tunnelObj.transform.childCount;
        for (int i = 0; i < 4; i++)
        {
            Transform childTransform = tunnelObj.transform.GetChild(i);
            if (min_y > childTransform.position.y)
            {
                min_index = i;
                min_y = childTransform.position.y;
            }
        }
        GameObject minChildObj = tunnelObj.transform.GetChild(min_index).gameObject;
        //minChildObj.GetComponent<Renderer>().material.color = Color.green;
        Transform minChild = tunnelObj.transform.GetChild(min_index);
        float distance = Vector3.Dot(-minChild.up, (transform.position - minChild.up));
        if (distance > 0)
        {
            //minChildObj.GetComponent<Renderer>().material.color = Color.red;

            transform.position += 3 * (1 + distance) * minChild.up;
        }
    }
}
