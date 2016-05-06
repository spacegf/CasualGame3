using UnityEngine;
using System.Collections;

public class ObjectJitter : MonoBehaviour {

	public float multX, multY;

	//ADJUSTABLE PARAMETERS
	public float xMaxDistance, yMaxDistance, xCycleMultiplyer, yCycleMultiplyer, xAddRumble, yAddRumble;

	//xMaxDistance & yMaxDistance control the total possible amount of drift across an axis
	//DEFAULTS: xMaxDistance = 2.5f; yMaxDistance = 20.0f;

	//xCycleMultiplyer & yCycleMultiplyer adjust the total length of time it takes for the object to perform its drift
	//DEFAULTS: xCycleMultiplyer = 20; yCycleMultiplyer = 5;

	//xAddRumble & yAddRumble adjust the additional rumble based on a percentage of the screen space that it takes up
	//DEFAULTS: xAddRumble = 1000.0f; yAddRumble = 800.0f;

	private float initX = Screen.width / 2;
	private float initY = Screen.height / 2;

	private float posX, posY, dt;


	//public GameObject title;

	void Start () {

	}

	void Update () {
		Rumble();
		StartCoroutine(frameDelay());
	}

	IEnumerator frameDelay() {
		yield return 0; //WAIT ONE FRAME
	}

	void Rumble() {
		transform.position = new Vector3(initX, initY, 0.0f);
		dt = Time.time;
		posX = (Mathf.Cos (dt*Mathf.Sin (dt/xCycleMultiplyer))*xMaxDistance) - Random.Range(0.0f, Screen.width/xAddRumble);
		posY = (Mathf.Sin (dt/yCycleMultiplyer)*yMaxDistance - Random.Range(0.0f, Screen.height/yAddRumble));
		transform.position += new Vector3(posX*multX, posY*multY, 0.0f);
	}
}
