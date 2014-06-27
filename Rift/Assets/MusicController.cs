using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	public Material matToChange;
	public Material matToChange2;
	public Material matToChange3;
	public Material matToChange4;
	public FFTWindow fftMethod;
	private float[] samples = new float[64];
	private float currentEnergy = 0f;
	private float beatEnergy = 0f;
	private GameObject[] buildings;
	// Use this for initialization
	void Start () {
		buildings = GameObject.FindGameObjectsWithTag("Building");
	}
	
	// Update is called once per frame
	void Update () {
		audio.GetSpectrumData (samples, 0, fftMethod);
		float tempBeatEnergy = 0f;
		float tempAdd = 0f;

		for (int i = 0; i < 64; i++) {
			tempAdd = Mathf.Pow (samples[i], 1.8f);
			currentEnergy += tempAdd;
			tempBeatEnergy += tempAdd;
		}

		if (tempBeatEnergy > beatEnergy + .4f) {
			Beat ();
			beatEnergy = tempBeatEnergy * 1.2f + .3f;
		}


		if (currentEnergy > .9f) currentEnergy = .9f;
		SetColor ();
		currentEnergy = currentEnergy * .85f;
		currentEnergy = currentEnergy - .05f;

		beatEnergy = beatEnergy * .9f;
		beatEnergy = beatEnergy - .02f;
		if (currentEnergy < 0) currentEnergy = 0;
	}

	void Beat() {
		for (int i = 0; i < buildings.Length; i++) {
			buildings[i].particleSystem.Play();		
		}
	}

	void SetColor() {
		matToChange.color = new Color (0f, .1f + currentEnergy, .1f + currentEnergy);
		// matToChange4.color = new Color (0f, .1f + currentEnergy, .1f + currentEnergy);
		matToChange2.color = new Color (currentEnergy /2f , currentEnergy /2f ,  currentEnergy / 2f);
		matToChange3.color = new Color (.1f + currentEnergy, .5f - currentEnergy, .1f + currentEnergy);
	}
}
