using UnityEngine;
using System.Collections;

public class rotateSword : MonoBehaviour {

	private GameObject swordController;
	private GameObject p2SwordController;
	public float deadzone = 0.6f; //Adjust in scene

	private Vector2 inputControl;
	private Vector2 p2InputControl;
	//Assign input values to a Vector2 so that the magnitude can be used to calculate more functional dead zones

	private float angle;
	private float p2Angle;
	//Adjusts by angle without using a CharacterController

	void start(){

		swordController = GameObject.FindWithTag ("P1SwordController");
		p2SwordController = GameObject.FindWithTag ("P2SwordController");
	}
	
	void Update(){

		swordController = GameObject.FindWithTag ("P1SwordController");
		p2SwordController = GameObject.FindWithTag ("P2SwordController");

		float xRotate = Input.GetAxis ("RightAnalog_horizontal");
		float yRotate = Input.GetAxis ("RightAnalog_vertical");

		float p2XRotate = Input.GetAxis ("P2RightAnalog_horizontal");
		float p2YRotate = Input.GetAxis ("P2RightAnalog_vertical");

		inputControl = new Vector2(xRotate, yRotate); 
		p2InputControl = new Vector2(p2XRotate, p2YRotate);
		
		angle = Mathf.Atan2(xRotate, yRotate)*Mathf.Rad2Deg;
		p2Angle = Mathf.Atan2 (xRotate, yRotate)*Mathf.Rad2Deg;

		p1UpdateCheck();
		p2UpdateCheck();
	}

	void p1UpdateCheck(){
		if(inputControl.magnitude > deadzone){
			swordController.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		} else {
			inputControl = Vector2.zero;
		}
	}

	void p2UpdateCheck(){
		if(p2InputControl.magnitude > deadzone){
			p2SwordController.transform.rotation = Quaternion.Euler(new Vector3(0, 0, p2Angle));
		} else {
			p2InputControl = Vector2.zero;
		}
	}
}
