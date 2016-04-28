using UnityEngine;
using System.Collections;

public class FrameCap : MonoBehaviour {

	float dTime = 0.0f;

	void Awake(){
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 120;
	}
	void Update(){
		dTime += (Time.deltaTime - dTime) * 0.1f;
	}
	void OnGUI(){
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(0, 0, w, h*2/100);
		style.alignment = TextAnchor.UpperRight;
		style.fontSize = h*2/100;
		style.normal.textColor = new Color (0.8f, 0.8f, 0.0f, 1.0f);
		float msec = dTime * 1000.0f;
		float fps = 1.0f / dTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		GUI.Label(rect, text, style);
	}
}
