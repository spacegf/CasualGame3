using UnityEngine;
using System.Collections;

public class rotateExample : MonoBehaviour {

	public GameObject swordController;
	
	void Start()
	{

	}
	
	void Update()
	{
		float xRotate = Input.GetAxis ("RightAnalog_horizontal")*Time.deltaTime;
		float yRotate = Input.GetAxis ("RightAnalog_vertical")*Time.deltaTime;
		float angle = Mathf.Atan2 (xRotate, yRotate)*Mathf.Rad2Deg;

		swordController.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
