using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public float speed = 3; 
	public float jumpHeight = 5;
	public float startingHealth = 1000;
	public float healthChng = 2.5f;
	public float healthDegn = 0.33f;
	public Slider p1Health, p2Health;
	private int p1StanceVal = 0, p2StanceVal = 0;
	private bool p1Crouched = false;
	private bool p2Crouched = false;

	public static int p1Kills, p2Kills;

	public BoxCollider p1HitBx, p2HitBx;

	public Text p1Killnum, p2Killnum;

	public float crouchTimer = 0; //use deltatime to prevent gamespeed from taking over
	public float startTimer = 1.5f;

	// Dash variables 
	public float dashTimer = 0;
	public float dashDuration = 0.1f;
	public float dashDelay = 0.3f;

	private GameObject p1, p2;

	private bool jump = true;
	private bool dash = false;
	private bool playable = true;

	//BLEED OUT
	public float decomposeRate = 0;
	private float decomposeValue;

	// Use this for initialization
	void Start () {
		 p1 = GameObject.FindGameObjectWithTag ("Player1");
		 p2 = GameObject.FindGameObjectWithTag ("Player2");

		p1Health.value = startingHealth;
		p2Health.value = startingHealth;
		

		p1HitBx.enabled = false;
		p2HitBx.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		p1Killnum.text = p1Kills.ToString ();
		p2Killnum.text = p2Kills.ToString ();

		if (playable) {

			 p1 = GameObject.FindGameObjectWithTag ("Player1");
			 p2 = GameObject.FindGameObjectWithTag ("Player2");

			if(p1Health.value <= 0 || p2Health.value <= 0){
				roundOver ();
			}

		

			p1Movement ();
			p2Movement ();
			decomposition();

			Mathf.Clamp (dashDuration, 0, dashDelay);
		}

		if (!playable) {

			SceneManager.LoadScene ("scene1");
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
				p1.transform.position += new Vector3 (0f, jumpHeight * Time.deltaTime, 0f);
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
		
		if(Input.GetAxis("P2Horizontal") < 0){
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
		
		
		if(Input.GetAxis("P2Horizontal") > 0){
			
			p2Health.value += healthChng;
			
			if (p1Health.value <= startingHealth) {
				p1Health.value -= healthChng;//*healthDegn; 
			}
			
			p2.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}

		if(Input.GetAxis("P2Jump") > 0){
			if (jump) {
				p2.transform.position += new Vector3 (0f, jumpHeight * Time.deltaTime, 0f);
				jump = false;
			}  

			jump = true;
		}

		if(Input.GetAxis("P2RightDash") > 0){

			dashTimer += Time.deltaTime;

			if (dashTimer <= dashDuration) {
				//p2Health.value -= healthChng * 2;
				p2.transform.position += new Vector3 (speed * 2.5f * Time.deltaTime, 0f, 0f);

			} else if (dashTimer > dashDelay){
				dashTimer = 0;
			}
		}

		if(Input.GetAxis("P2LeftDash") > 0){
			dashTimer += Time.deltaTime;

			if (dashTimer <= dashDuration) {
				//p2Health.value -= healthChng * 2;
				p2.transform.position -= new Vector3 (speed * 2.5f * Time.deltaTime, 0f, 0f);

			} else if (dashTimer > dashDelay){
				dashTimer = 0;
			}



		}

		if (Input.GetAxis ("P2Attack") > 0) {
			attackC (p2HitBx);
		} else {
			p2HitBx.enabled = false;
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
