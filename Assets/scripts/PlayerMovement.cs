using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Sprite defaultStance;
	public Sprite upperStance;
	public Sprite lowerStance;

	public float speed = 1; 
	public float startingHealth = 1000;
	public float healthChng = 2.5f;
	public float healthDegn = 0.33f;
	public Slider p1Health, p2Health;
	private int p1StanceVal = 2, p2StanceVal = 2;
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

		// player 1 input 
		if(Input.GetKey(KeyCode.W)){ 
			if(p1StanceVal > 0){
				p1StanceVal -= 1;
			}
		}

		if(Input.GetKey(KeyCode.A)){
			p1Health.value -= healthChng;

			if (p2Health.value < startingHealth) {
				p2Health.value += healthChng*healthDegn; 
			}

			p1.transform.position -= new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}

		if(Input.GetKey(KeyCode.S)){
			if(p1StanceVal < 4){
				p1StanceVal += 1;
			}
		}

		if(Input.GetKey(KeyCode.D)){
				
			p1Health.value -= healthChng;

			if (p2Health.value < startingHealth) {
				p2Health.value += healthChng*healthDegn; 
			}

			p1.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}


		//p2 input
		if(Input.GetKey(KeyCode.UpArrow)){
			if(p2StanceVal > 0){
				p2StanceVal -= 1;
			}
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			p2Health.value -= healthChng;

			if (p1Health.value < startingHealth) {
				p1Health.value += healthChng*healthDegn;
			}
			p2.transform.position -= new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}

		if(Input.GetKey(KeyCode.DownArrow)){
			if(p2StanceVal < 4){
				p2StanceVal += 1;
			}
		}

		if(Input.GetKey(KeyCode.RightArrow)){
				
			p2Health.value -= healthChng;

			if (p1Health.value < startingHealth) {
				p1Health.value += healthChng*healthDegn;
			}
			p2.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
		if(p1StanceVal == 1){ p1.GetComponent<SpriteRenderer>().sprite = upperStance; }
		if(p1StanceVal == 2){ p1.GetComponent<SpriteRenderer>().sprite = defaultStance; }
		if(p1StanceVal == 3){ p1.GetComponent<SpriteRenderer>().sprite = lowerStance; }

		if(p2StanceVal == 1){ p2.GetComponent<SpriteRenderer>().sprite = upperStance; }
		if(p2StanceVal == 2){ p2.GetComponent<SpriteRenderer>().sprite = defaultStance; }
		if(p2StanceVal == 3){ p2.GetComponent<SpriteRenderer>().sprite = lowerStance; }

	}
}
