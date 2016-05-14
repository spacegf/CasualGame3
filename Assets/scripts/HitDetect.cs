using UnityEngine;
using System.Collections;

public class HitDetect : MonoBehaviour {

	public GameObject player;


	void OnTriggerEnter(Collider col){

		switch (col.gameObject.name) {

		case "Player1":
			Destroy (col.gameObject);
		
			StartCoroutine ("respawnP1");
			break;

		case "Player2":
			Destroy (col.gameObject);
			StartCoroutine ("respawnP2");
			break;

		case "Player1(Clone)":
			StartCoroutine ("respawnP1");
			break;

		case "Player2(Clone)":
			Destroy (col.gameObject);
			StartCoroutine ("respawnP2");
			break;

		case "p1Hit":
			break;
		case "p2Hit":
			break;
		}
	}


	IEnumerator respawnP2(){
		yield return new WaitForSeconds (2f);
		GameObject newPlayer2 = (GameObject)Instantiate (player, new Vector3(14.9f,-2.02f,0f), Quaternion.identity);

	}


	IEnumerator respawnP1(){
		yield return new WaitForSeconds (2f);
		GameObject newPlayer1 = (GameObject)Instantiate (player, new Vector3(-14.5f,-2.02f,0f), Quaternion.identity);

	}
}
