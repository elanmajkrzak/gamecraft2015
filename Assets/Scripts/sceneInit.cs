using UnityEngine;
using System.Collections;

public class sceneInit : MonoBehaviour {
	public float fadeTime = 15.0f;
	public bool fadeIn = true;
	// Use this for initialization
	void Start () {
		FadeMusic (fadeTime, fadeIn);
	}

	public void FadeIn(){
		FadeMusic (fadeTime, true);
	}
	
	public void FadeOut(){
		FadeMusic (fadeTime, false);
	}

	void FadeMusic(float fadeTime, bool fadeIn) {
		float start = 1.0f;
		float end = 0.0f;
		float step = 1.0f / fadeTime;

		if (fadeIn) {
			start = 0.0f;
			end = 1.0f;
		}

		for (float i = 0.0f; i < 1.0f;) {
			i += step * Time.deltaTime;
			GetComponent<AudioSource>().volume = Mathf.Lerp(start, end, i);
		}
	}
}
