using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPLayer : MonoBehaviour {

	// Use this for initialization

	public Transform  target;
	//public Transform targetGun;

	private Transform m_Cam;    
 	private Transform m_Pivot;                // the point at which the camera pivots around
	

	public float smoothing = 5f;
	Vector3 offset;

	void Start () {
		offset = transform.position - target.position;
		m_Cam = GetComponentInChildren<Camera>().transform;
        m_Pivot = m_Cam.parent;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 targetCamPos = target.position;

		   if (Input.GetKey("r")){

			   m_Pivot.position = Vector3.Lerp(m_Pivot.position, targetCamPos, 18*Time.deltaTime); 

		   }
            
		


	//	Vector3 targetCamPos = target.position + offset;

	//Vector3 targetCamPos = m_Pivot.position;

	
	//	transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);


//-.--------- pruebas suculentas


//		Quaternion newRotation = target.transform.rotation;
//		Debug.Log(target.rotation.eulerAngles.y);
//		transform.eulerAngles = new Vector3(19, target.rotation.eulerAngles.y,0f);


//---------- funciona ------

		//rotationY = target.transform.rotation.y;
		
		

		  //float smooth = 2.0F;
		  //Quaternion targetK = Quaternion.Euler(target.transform.rotation.x, 0, target.transform.rotation.z);
		  
		  //Quaternion newRotation = Camera.main.transform.rotation;

		  //newRotation.y = Camera.main.transform.rotation.y;

		  //newRotation.y = target.rotation.y;*/

		   //transform.rotation = Quaternion.Slerp(transform.rotation, targetK, Time.deltaTime );



		//transform.rotation.y = target.transform.rotation.y; //no funca

		//transform.LookAt(target); //funca pero con problemas

		 //float xx =5f * Input.GetAxis("Mouse X");
		 //float yy =5f * Input.GetAxis("Mouse Y");

		//transform.eulerAngles = new Vector3(yy, xx,0f);
		


	}
}
