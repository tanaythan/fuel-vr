using UnityEngine;
using System.Collections;

public class AnimatePlayer : MonoBehaviour {
	public CharacterController playerController;
	private float oldX;
	private float oldZ;

	// Use this for initialization
	void Start () {
		animation ["loop_run_funny"].speed = 2.3f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(Input.GetAxis("Horizontal")) > .1f || Mathf.Abs(Input.GetAxis("Vertical")) > .1f) {
			animation.Play ("loop_run_funny");
			Debug.Log (Input.GetAxis("Horizontal").ToString());
		} else {
				
			animation.Stop ();
		}

		oldX = transform.position.x;
		oldZ = transform.position.z;
	}
}
