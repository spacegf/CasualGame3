﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ignition : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			SceneManager.LoadScene ("scene1");
		}
	}
}
