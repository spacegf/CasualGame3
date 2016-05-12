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


	public BoxCollider p1HitBx, p2HitBx;

	public float crouchTimer = 0; //use deltatime to prevent gamespeed from taking over
	public float startTimer = 1.5f;

	// Dash variables 
	public float dashTimer = 0;
	public float dashDuration = 0.1f;
	public float dashDelay = 0.3f;

	public GameObject p1, p2;

	private bool jump = true;
	private bool dash = false;
	private bool playable = true;

	//BLEED OUT
	public float decomposeRate = 0;
	private float decomposeValue;

	// Use this for initialization
	void Start () {

		p1Health.value = startingHealth;
		p2Health.value = startingHealth;
		p1.GetComponent<SpriteRenderer>().sprite = defaultStance;
		p2.GetComponent<SpriteRenderer>().sprite = defaultStance;

		

		p1HitBx.enabled = false;
		p2HitBx.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (playable) {

			if(p1Health.value <= 0 || p2Health.value <= 0){
				roundOver ();
			}

			p1Movement ();
			p2Movement ();
			decomposition();

			//check for stance value
			if (p1StanceVal <= -15) {
				p1.GetComponent<SpriteRenderer> ().sprite = upperStance;
			}
			if (p1StanceVal > -15 && p1StanceVal < 15) {
				p1.GetComponent<SpriteRenderer> ().sprite = defaultStance;
			}
			if (p1StanceVal >= 15) {
				p1.GetComponent<SpriteRenderer> ().sprite = lowerStance;
			}
			if (p1Crouched) {
				p1.GetComponent<SpriteRenderer> ().sprite = dodgeStance;
			}

			if (p2StanceVal <= -15) {
				p2.GetComponent<SpriteRenderer> ().sprite = upperStance;
			}
			if (p2StanceVal > -15 && p2StanceVal < 15) {
				p2.GetComponent<SpriteRenderer> ().sprite = defaultStance;
			}
			if (p2StanceVal >= 15) {
				p2.GetComponent<SpriteRenderer> ().sprite = lowerStance;
			}
			if (p2Crouched) {
				p2.GetComponent<SpriteRenderer> ().sprite = dodgeStance;
			}

			Mathf.Clamp (dashDuration, 0, dashDelay);
		}

	}

	void p1Movement(){
		// player 1 input 
		if(Input.GetKeyDown(KeyCode.W)){ 
			if(p1StanceVal > -15){
				p1StanceVal -= 15;
			}
		}
		
		if(Input.GetAxis("Horizontal") < 0){
			p1Health.value += healthChng;
			
			if (p2Health.value <= startingHealth) {
				p2Health.value -= healthChng;//*healthDegn; 
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
		
		
		if(Input.GetAxis("Horizontal") > 0){
			
			p1Health.value += healthChng;
			
			if (p2Health.value <= startingHealth) {
				p2Health.value -= healthChng;//*healthDegn; 
			}
			
			p1.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}

		if (Input.GetAxis("Jump") > 0) {
			
			if (jump) {
				p1.transform.position += new Vector3 (0f, speed * Time.deltaTime, 0f);
				jump = false; 
			}  jump = true; 
		}

		if(Input.GetAxis("RightDash") > 0){

			dashTimer += Time.deltaTime;

			if (dashTimer <= dashDuration) {
				//p1Health.value += healthChng * 2;
				p1.transform.position += new Vector3 (speed * 2.5f * Time.deltaTime, 0f, 0f);

			} else if (dashTimer > dashDelay){
				dashTimer = 0;
			}
		}

		if(Input.GetAxis("LeftDash") > 0){
			dashTimer += Time.deltaTime;

			if (dashTimer <= dashDuration) {
			//	p1Health.value -= healthChng * 2;
				p1.transform.position -= new Vector3 (speed * 2.5f * Time.deltaTime, 0f, 0f);

			} else if (dashTimer > dashDelay){
				dashTimer = 0;
			}
			
				
		}


		if (Input.GetAxis ("Attack") > 0) {
			attackC (p1HitBx);
		} else {
			p1HitBx.enabled = false;
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
			p2Health.value += healthChng;
			
			if (p1Health.value <= startingHealth) {
				p1Health.value -= healthChng;//*healthDegn; 
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
			
			p2Health.value += healthChng;
			
			if (p1Health.value <= startingHealth) {
				p1Health.value -= healthChng;//*healthDegn; 
			}
			
			p2.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}

		if(Input.GetKey(KeyCode.L)){
			if (jump) {
				p2.transform.position += new Vector3 (0f, speed * Time.deltaTime, 0f);
				jump = false;
			}  

			jump = true;
		}

		if(Input.GetKey(KeyCode.Semicolon) && Input.GetKey(KeyCode.RightArrow)){

			dashTimer += Time.deltaTime;

			if (dashTimer <= dashDuration) {
				//p2Health.value -= healthChng * 2;
				p2.transform.position += new Vector3 (speed * 2.5f * Time.deltaTime, 0f, 0f);

			} else if (dashTimer > dashDelay){
				dashTimer = 0;
			}
		}

		if(Input.GetKey(KeyCode.Semicolon) && Input.GetKey(KeyCode.LeftArrow)){
			dashTimer += Time.deltaTime;

			if (dashTimer <= dashDuration) {
				//p2Health.value -= healthChng * 2;
				p2.transform.position -= new Vector3 (speed * 2.5f * Time.deltaTime, 0f, 0f);

			} else if (dashTimer > dashDelay){
				dashTimer = 0;
			}



		}

		if(Input.GetKey(KeyCode.K)){
			attackC (p2HitBx);
		}
	}

	void roundOver(){
		playable = false;
	}


	void attackC(BoxCollider hitBx){
		hitBx.enabled = true;
	}

	void decomposition(){
		decomposeValue = decomposeRate*Time.deltaTime;
		
		p1Health.value -= decomposeValue;
		p2Health.value -= decomposeValue;

	}

}
