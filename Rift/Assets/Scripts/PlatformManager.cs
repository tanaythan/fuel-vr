using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {
	public int[,] theGrid = new int[400,400];
	public GameObject platformPrefab;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 400; i++) {
			for(int g = 0; g < 400; g++) {
				theGrid[i, g] = 0;
			}		
		}
//		for (int i = 0; i < 200; i++) {
//			for (int g = 0; g < 200; g++) {
//				CreatePlatform (100 + i, 100 + g);
//			}		
//		}
		CreatePlatform (200, 200);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			TeleportPlayer();		
		}
	}

	void TeleportPlayer() {
		GameObject playa = GameObject.FindGameObjectWithTag("Player");
		iTween.MoveTo (playa, new Vector3 (transform.position.x, transform.position.y + 3f, transform.position.z), 10f);
	}

	public void CreatePlatform(int x, int y) {
		theGrid [x, y] = 1;
		Debug.Log (x.ToString ());
		GameObject platform = (GameObject)Instantiate (platformPrefab, new Vector3 ((-200 + x) * 1.5f + transform.position.x, transform.position.y - 3f, (-200 + y) * 1.5f + transform.position.z), Quaternion.identity);
		platform.gameObject.GetComponent<Platform> ().location = new Vector2 (x, y);
		iTween.MoveTo (platform, new Vector3 (platform.transform.position.x, transform.position.y, platform.transform.position.z), .35f);
	}
}
