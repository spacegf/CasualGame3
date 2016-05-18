using UnityEngine;
using System.Collections;

public class HitDetect : MonoBehaviour {

	public GameObject player;

	private bool startRe = false;

	void Start(){		
		
	}



	void OnTriggerEnter(Collider col){

		switch (col.gameObject.name) {

		case "Player1":
			Destroy (col.gameObject);
			startRe = true;

			if (startRe == true) {
				StartCoroutine ("respawnP1");
			}
			PlayerMovement.p2Kills += 1;

			Debug.Log (PlayerMovement.p2Kills);
		
			break;

		case "Player2":
			Destroy (col.gameObject);
			startRe = true;

			if (startRe == true) {
				StartCoroutine ("respawnP2");
			}
			PlayerMovement.p1Kills += 1;

			Debug.Log (PlayerMovement.p1Kills);
			break;

		case "Player1(Clone)":

			Destroy (col.gameObject);
			PlayerMovement.p2Kills += 1;
			startRe = true;

			if (startRe == true) {
				StartCoroutine ("respawnP1");
			}
			Debug.Log (PlayerMovement.p2Kills);
			break;

		case "Player2(Clone)":
			Destroy (col.gameObject);
			startRe = true;

			if (startRe == true) {
				StartCoroutine ("respawnP2");
			}

			Debug.Log (PlayerMovement.p1Kills);
			PlayerMovement.p1Kills += 1;
			break;

		case "ATTACK CUBE":
			break;
		}
	}


	IEnumerator respawnP2(){
		yield return new WaitForSeconds (2f);
		GameObject newPlayer2 = (GameObject)Instantiate (player, new Vector3(14.9f,-2.02f,0f), Quaternion.identity);
		startRe = false;

	}


	IEnumerator respawnP1(){
		yield return new WaitForSeconds (2f);
		GameObject newPlayer1 = (GameObject)Instantiate (player, new Vector3(-14.5f,-2.02f,0f), Quaternion.identity);
		startRe = false;

	}
}
