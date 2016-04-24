using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /* 
     
     
     float moveHorizontal = Mathf.Cos(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Vertical") - Mathf.Sin(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Horizontal");
     float moveVertical = Mathf.Sin(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Vertical") + Mathf.Cos(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Horizontal");
     Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);

     body.AddForce(movement * movementSpeed); // apply force
     
     
     
     */
}
