using UnityEngine;
using System.Collections;

public class PlatformTrigger : MonoBehaviour {
	public Vector2 direction;
	private Platform platform;
	// Use this for initialization
	void Start () {
		platform = transform.parent.gameObject.GetComponent<Platform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine(TriggerTiles());
		}
	}

	IEnumerator TriggerTiles() {
		platform.TriggerCreation((int)direction.x, (int)direction.y);
		platform.TriggerCreation((int)direction.x * -1, (int)direction.y * -1);	
		platform.TriggerCreation((int)direction.x, (int)direction.y * -1);	
		platform.TriggerCreation((int)direction.x * -1, (int)direction.y);
		
		platform.TriggerCreation((int)direction.x * 2, (int)direction.y * 2);
		yield return new WaitForSeconds (.05f);
		platform.TriggerCreation((int)direction.x * 2, (int)direction.y * 2 + 1);
		platform.TriggerCreation((int)direction.x * 2 + 1, (int)direction.y * 2);
		
		platform.TriggerCreation((int)direction.x * 2, (int)direction.y * 2 - 1);
		platform.TriggerCreation((int)direction.x * 2 - 1, (int)direction.y * 2);
		yield return new WaitForSeconds (.05f);
		platform.TriggerCreation((int)direction.x * 3, (int)direction.y * 3);
	}
}
