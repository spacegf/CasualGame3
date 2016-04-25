using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1; 
	public float startingHealth = 100;
	public float healthChng = 0.5f;
	public Slider p1Health, p2Health;
	public GameObject p1, p2;

	// Use this for initialization
	void Start () {

		p1Health.value = startingHealth;
		p2Health.value = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

		// player 1 input 
		if(Input.GetKey(KeyCode.W)){}
		if(Input.GetKey(KeyCode.A)){
			p1Health.value -= healthChng;

			if (p2Health.value < startingHealth) {
				p2Health.value += healthChng; 
				}

			p1.transform.position -= new Vector3 (speed * Time.deltaTime, 0f, 0f);
			}
		if(Input.GetKey(KeyCode.S)){}
		if(Input.GetKey(KeyCode.D)){
				
			p1Health.value -= healthChng;

			if (p2Health.value < startingHealth) {
				p2Health.value += healthChng; 
				}

			p1.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}


		//p2 input
			if(Input.GetKey(KeyCode.UpArrow)){}
			if(Input.GetKey(KeyCode.LeftArrow)){
			p2Health.value -= healthChng;

			if (p1Health.value < startingHealth) {
				p1Health.value += healthChng;
				}
				p2.transform.position -= new Vector3 (speed * Time.deltaTime, 0f, 0f);
			}
			if(Input.GetKey(KeyCode.DownArrow)){}
			if(Input.GetKey(KeyCode.RightArrow)){
				
			p2Health.value -= healthChng;

			if (p1Health.value < startingHealth) {
				p1Health.value += healthChng;
				}
				p2.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
			}

		
	}
}
