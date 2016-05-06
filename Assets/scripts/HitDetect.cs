using UnityEngine;
using System.Collections;

public class HitDetect : MonoBehaviour {



	void OnTriggerEnter(Collider col){

		switch (col.gameObject.name) {

		case "Player1":
			Destroy (col.gameObject);
			break;

		case "Player2":
			Destroy (col.gameObject);
			break;
		case "p1Hit":
			break;
		case "p2Hit":
			break;
		}
	}

}
