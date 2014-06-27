using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	public Vector2 location;
	private PlatformManager platformManager;

	// Use this for initialization
	void Start () {
		platformManager = GameObject.Find ("PlatformManager").GetComponent<PlatformManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TriggerCreation(int xDir, int yDir) {
		if (platformManager.theGrid [(int)location.x + xDir, (int)location.y + yDir] == 0) {
			platformManager.CreatePlatform((int)location.x + xDir, (int)location.y + yDir);
		}	
	}
}
