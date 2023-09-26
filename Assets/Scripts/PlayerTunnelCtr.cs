using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTunnelCtr : MonoBehaviour
{
    public float const_accel = 5.0f;
    private bool tunnelCRInput;  // Clockwise Rotation for tunnel
    private bool tunnelCCRInput; // Counterclockwise Rotation for tunnel
    public float RotateSpeed = 30;
    public float RotateInstant = 90;
    private float horizontalInput;
		private float bonusTime = 0;

    public GameObject popupPanel;

    public GameObject popupPanel2;

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
						transform.Translate(Vector3.right * const_accel * Time.deltaTime);
        }
        else if (tunnelCCRInput)
        {
            tunnelObj.transform.Rotate(Vector3.forward * counterclockwise * RotateInstant);
						transform.Translate(Vector3.left * const_accel * Time.deltaTime);
        }
        //

				if (bonusTime > 0) {
						Debug.Log(bonusTime);
						bonusTime -= 1;
						if (bonusTime == 0) {
								GameObject playerCube = GameObject.Find("/Player/Cube");
								playerCube.transform.localScale = new Vector3(2, 2, 2);
								bonusTime = 0;
						}
				}


        // int childCount = tunnelObj.transform.childCount;
        // for (int i = 0; i < 4; i++)
        // {
        //     Transform childTransform = tunnelObj.transform.GetChild(i);
        //     if (min_y > childTransform.position.y)
        //     {
        //         min_index = i;
        //         min_y = childTransform.position.y;
        //     }
        // }
        // GameObject minChildObj = tunnelObj.transform.GetChild(min_index).gameObject;
        // //minChildObj.GetComponent<Renderer>().material.color = Color.green;
        // Transform minChild = tunnelObj.transform.GetChild(min_index);
        // float distance = Vector3.Dot(-minChild.up, (transform.position - minChild.position));
        // if (distance > 0)
        // {
        //     //minChildObj.GetComponent<Renderer>().material.color = Color.red;

        //     transform.position += 3 * (1 + distance) * minChild.up;
        // }
    }

		
  // Cube Collision
  private void OnCollisionEnter(Collision collision)
	{

      if (collision.gameObject.name == "EndWall"){
        const_accel = 0;
        ShowPopup();
        Invoke("LoadBackScene", 1.0f);
      }

			// Debug.Log(collision.gameObject.name);
		  if (collision.gameObject.name == "Cube"
					||  collision.gameObject.name == "Capsule"
					||  collision.gameObject.name == "Cylinder"
			) {
					const_accel = 0;
					GameObject playerCube = GameObject.Find("/Player/Cube");
					playerCube.GetComponent<Renderer>().material.color = Color.red;
          ShowPopup2();
          Invoke("LoadBackScene", 5.0f);

			}
			if (collision.gameObject.name == "Coin") {
					GameObject playerCube = GameObject.Find("/Player/Cube");
					playerCube.transform.localScale = new Vector3(1, 1, 1);
					bonusTime = 5 / Time.deltaTime;
					Destroy(collision.gameObject);
			}
	}

  public void LoadBackScene()
  {
      SceneManager.LoadScene("StartPage"); //the index of the seconf scene
  }

  public void ShowPopup()
    {
        popupPanel.SetActive(true);
    }

  public void ShowPopup2()
    {
        popupPanel2.SetActive(true);
    }

    public void HidePopup()
    {
        popupPanel.SetActive(false);
    }

 
	// private void OnCollisionEnter(Collision collision)
	// {
 	// // Destroy(gameObject);
	// 	const_accel = 0;

	// 	GameObject.Find("/Player/Cube").GetComponent<Renderer>().material.color = Color.red;
	// 	// if (collision.gameObject.name == "Plane") {
	// 	// 		GetComponent<Renderer>().material.color = Color.black;
	// 	// }
	// }
}
