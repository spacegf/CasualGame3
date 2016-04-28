using UnityEngine;
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
	private int p1StanceVal = 0, p2StanceVal = 0;
	private bool p1Crouched = false;
	private bool p2Crouched = false;

	public float crouchTimer = 0; //use deltatime to prevent gamespeed from taking over
	public float startTimer = 1.5f;

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
		p1Movement();
		p2Movement();
		//check for stance value
		if(p1StanceVal <= -15){ p1.GetComponent<SpriteRenderer>().sprite = upperStance; }
		if(p1StanceVal > -15 && p1StanceVal < 15){ p1.GetComponent<SpriteRenderer>().sprite = defaultStance; }
		if(p1StanceVal >= 15){ p1.GetComponent<SpriteRenderer>().sprite = lowerStance; }
		if(p1Crouched){ p1.GetComponent<SpriteRenderer>().sprite = dodgeStance; }

		if(p2StanceVal <= -15){ p2.GetComponent<SpriteRenderer>().sprite = upperStance; }
		if(p2StanceVal > -15 && p2StanceVal < 15){ p2.GetComponent<SpriteRenderer>().sprite = defaultStance; }
		if(p2StanceVal >= 15){ p2.GetComponent<SpriteRenderer>().sprite = lowerStance; }
		if(p2Crouched){ p2.GetComponent<SpriteRenderer>().sprite = dodgeStance; }

	}

	void p1Movement(){
		// player 1 input 
		if(Input.GetKeyDown(KeyCode.W)){ 
			if(p1StanceVal > -15){
				p1StanceVal -= 15;
			}
		}
		
		if(Input.GetKey(KeyCode.A)){
			p1Health.value -= healthChng;
			
			if (p2Health.value < startingHealth) {
				p2Health.value += healthChng*healthDegn; 
			}
			
			p1.transform.position -= new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
		
		if(Input.GetKeyDown(KeyCode.S)){
			if(p1StanceVal <= 15){
				p1StanceVal += 15;
			}
		} 
		
		if (Input.GetKey (KeyCode.S)) {
			crouchTimer += Time.deltaTime;
			
			if(crouchTimer > startTimer){
				crouchTimer = 0;
				p1Crouched = true;
			}
		} else if (Input.GetKeyUp (KeyCode.S)) {
			crouchTimer = 0;
			p1Crouched = false;
		}
		
		
		if(Input.GetKey(KeyCode.D)){
			
			p1Health.value -= healthChng;
			
			if (p2Health.value < startingHealth) {
				p2Health.value += healthChng*healthDegn; 
			}
			
			p1.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
	}
	void p2Movement(){
		// player 1 input 
		if(Input.GetKeyDown(KeyCode.UpArrow)){ 
			if(p2StanceVal > -15){
				p2StanceVal -= 15;
			}
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			p2Health.value -= healthChng;
			
			if (p1Health.value < startingHealth) {
				p1Health.value += healthChng*healthDegn; 
			}
			
			p2.transform.position -= new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
		
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			if(p2StanceVal <= 15){
				p2StanceVal += 15;
			}
		} 
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			crouchTimer += Time.deltaTime;
			
			if(crouchTimer > startTimer){
				crouchTimer = 0;
				p2Crouched = true;
			}
		} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			crouchTimer = 0;
			p2Crouched = false;
		}
		
		
		if(Input.GetKey(KeyCode.RightArrow)){
			
			p2Health.value -= healthChng;
			
			if (p1Health.value < startingHealth) {
				p1Health.value += healthChng*healthDegn; 
			}
			
			p2.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
	}
}
