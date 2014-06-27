using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour {
	private bool canBounce = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player") && canBounce) {
			StartCoroutine(Cooldown());
			StartCoroutine(BounceIt(other.gameObject));
		}
	}

	IEnumerator BounceIt(GameObject player) {
		Hashtable h = new Hashtable();
		h.Add("easetype", iTween.EaseType.linear);
		h.Add("time", 12f);
		h.Add ("y", gameObject.transform.position.y + 100f);
		iTween.MoveTo(player, h);
		yield return new WaitForSeconds (20f);
		Hashtable h1 = new Hashtable();
		h1.Add("easetype", iTween.EaseType.easeInQuad);
		h1.Add("time", 6f);
		h1.Add ("y", gameObject.transform.position.y + 1f);
		iTween.MoveTo(player, h1);

	}
	
	IEnumerator Cooldown() {
		canBounce = false;
		yield return new WaitForSeconds (30f);
		canBounce = true;
	}
}
