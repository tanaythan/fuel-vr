using UnityEngine;
using System.Collections;

public class CreateFuel : MonoBehaviour {
	private string[] parameters;

	public GameObject[] screens;
	public GameObject[] row2;
	public GameObject topImage;
	public GameObject smokeScreen;
	private bool createdProgram = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire3")) {
			if(createdProgram) {
				DestroyScreens();
			} else {
			//ßß	StartCoroutine(CreateScreens());
			}

			createdProgram = !createdProgram;
		}
	}

	IEnumerator CreateScreens () {
		float originX = transform.position.x;
		float originZ = transform.position.z;
		float r = 55f;
		float incrementor = Mathf.PI * .25f;
		Instantiate (smokeScreen, transform.position, Quaternion.identity);
		for (int i = 0; i < 8; i++) {
			r = r * 10f;
			float theta = i * incrementor;
			float addX = r * Mathf.Cos(theta);
			float addZ = r * Mathf.Sin (theta);
			GameObject createdObj = (GameObject)Instantiate(screens[i], new Vector3(transform.position.x + addX, transform.position.y + 10f, transform.position.z + addZ), Quaternion.identity);
			createdObj.transform.LookAt(transform);
			r = r / 10f;
			addX = r * Mathf.Cos(theta);
			addZ = r * Mathf.Sin (theta);
			StartCoroutine(DelayedMoveScreen(createdObj, new Vector3(transform.position.x + addX, transform.position.y + 10f, transform.position.z + addZ), 3));
			yield return new WaitForSeconds(.5f);
		}
		r = 30f;
		incrementor = Mathf.PI * .5f;
		for (int i = 0; i < 4; i++) {
			r = r * 10f;
			float theta = i * incrementor;
			float addX = r * Mathf.Cos(theta);
			float addZ = r * Mathf.Sin (theta);
			GameObject createdObj = (GameObject)Instantiate(row2[i], new Vector3(transform.position.x + addX, transform.position.y + 37f, transform.position.z + addZ), Quaternion.identity);
			createdObj.transform.LookAt(transform);
			r = r / 10f;
			addX = r * Mathf.Cos(theta);
			addZ = r * Mathf.Sin (theta);
			StartCoroutine(DelayedMoveScreen(createdObj, new Vector3(transform.position.x + addX, transform.position.y + 37f, transform.position.z + addZ), 2f));
		}

		GameObject createdObj1 = (GameObject)Instantiate(topImage, new Vector3(transform.position.x, transform.position.y + 150f, transform.position.z), Quaternion.identity);
		StartCoroutine(DelayedMoveScreen(createdObj1, new Vector3(transform.position.x, transform.position.y + 50f, transform.position.z), 3));
	}

	IEnumerator DelayedMoveScreen(GameObject target, Vector3 position, float time) {
		yield return new WaitForSeconds (time);
		iTween.MoveTo(target, position, 5f);
		yield return new WaitForSeconds (5f);
		target.transform.LookAt (transform);
	}

	void DestroyScreens () {
		GameObject[] objsToDestroy = GameObject.FindGameObjectsWithTag("FuelProgram");
		for (int i = 0; i < objsToDestroy.Length; i++) {
			iTween.MoveTo(objsToDestroy[i], new Vector3(objsToDestroy[i].transform.position.x, -100f, objsToDestroy[i].transform.position.z), 4f);
			DelayedDeath(objsToDestroy[i], 5f);
		}
	}

	IEnumerator DelayedDeath(GameObject other, float timeTillDeath) {
		yield return new WaitForSeconds (timeTillDeath);
		Destroy (other);
	}
}
