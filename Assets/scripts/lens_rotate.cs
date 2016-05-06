using UnityEngine;
using System.Collections;

public class lens_rotate : MonoBehaviour {
	public float speed = 0.5f;
	void Update () {
		transform.Rotate(0, speed * Time.deltaTime, 0);
	}
}
