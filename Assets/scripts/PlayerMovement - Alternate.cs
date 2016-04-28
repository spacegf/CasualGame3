/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Sprite defaultStance;
	public Sprite upperStance;
	public Sprite lowerStance;
	public Sprite dodgeStance;

	public float speed = 1; 
	public float startingHealth = 1000;
	public float healthChng = 2.5f;
	public float healthDegn = 0.33f;
	public Slider p1Health, p2Health;

	public float switchTimer = 2.0f;
	public float crouchTimer = 0; 
	//using timers to check to see that the key is held down for a certain amount of
	//time before switching to prevent the framerate from making it unmanageably fast

	private bool p1UpperPos = false;
	private bool p1DefaultPos = true;
	private bool p1LowerPos = false;
	private bool p1DodgePos = false;

	private bool p2UpperPos = false;
	private bool p2DefaultPos = true;
	private bool p2LowerPos = false;
	private bool p2DodgePos = false;

	public GameObject p1, p2;

	// Use this for initialization
	void Start () {

		p1Health.value = startingHealth;
		p2Health.value = startingHealth;
		p1.GetComponent<SpriteRenderer>().sprite = defaultStance;
		p2.GetComponent<SpriteRenderer>().sprite = defaultStance;
	}
	
	// Update is called once per frame
	void Update () {

		p1Input();
		//p2Input();

		checkStance();

	}
	void p1Input(){
		// player 1 input 
		if(Input.GetKeyDown(KeyCode.W)){ 
			if(p1DefaultPos && !p1UpperPos){
				p1UpperPos = true;
				p1DefaultPos = false;
			} else if(p1LowerPos && !p1DefaultPos) {
				p1DefaultPos = true;
				p1LowerPos = false;
			}
			Debug.Log("Upper:" + p1UpperPos + ", " + "Default:" + p1DefaultPos + ", " + "Lower:" + p1LowerPos);
		}
		
		if(Input.GetKey(KeyCode.A)){
			p1Health.value -= healthChng;
			
			if (p2Health.value < startingHealth) {
				p2Health.value += healthChng*healthDegn; 
			}
			
			p1.transform.position -= new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
		
		if(Input.GetKeyDown(KeyCode.S)){
			if(p1DefaultPos && !p1LowerPos){
				p1LowerPos = true;
				p1DefaultPos = false;
			} else if(p1UpperPos && !p1DefaultPos){
				p1DefaultPos = true;
				p1UpperPos = false;
			}
			Debug.Log("Upper:" + p1UpperPos + ", " + "Default:" + p1DefaultPos + ", " + "Lower:" + p1LowerPos);
		} else if (Input.GetKey (KeyCode.S)) {
			crouchTimer += Time.deltaTime;
			
			if(p1LowerPos && crouchTimer > switchTimer){
				crouchTimer = 0;
				p1DodgePos = true;
				p1LowerPos = false;
			}
		} else if (Input.GetKeyUp (KeyCode.S)) {
			p1DodgePos = false;
			p1LowerPos = true;
		}
		
		if(Input.GetKey(KeyCode.D)){
			
			p1Health.value -= healthChng;
			
			if (p2Health.value < startingHealth) {
				p2Health.value += healthChng*healthDegn; 
			}
			
			p1.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
	}

	void p2Input(){

	}

	void checkStance(){
		//check for stance value
		if(p1UpperPos){ p1.GetComponent<SpriteRenderer>().sprite = upperStance; }
		if(p1DefaultPos){ p1.GetComponent<SpriteRenderer>().sprite = defaultStance; }
		if(p1LowerPos){ p1.GetComponent<SpriteRenderer>().sprite = lowerStance; }
		if(p1DodgePos){ p1.GetComponent<SpriteRenderer>().sprite = dodgeStance; }
		
		if(p2UpperPos){ p2.GetComponent<SpriteRenderer>().sprite = upperStance; }
		if(p2DefaultPos){ p2.GetComponent<SpriteRenderer>().sprite = defaultStance; }
		if(p2LowerPos){ p2.GetComponent<SpriteRenderer>().sprite = lowerStance; }
		if(p2DodgePos){ p2.GetComponent<SpriteRenderer>().sprite = dodgeStance; }
	}
}*/
