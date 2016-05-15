using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {
	public CraftMovement PlayerScript;

	// Use this for initialization
	void Start() {
		Time.timeScale = 0;
		PlayerScript.enabled = false;
	}

	// Update is called once per frame
	void Update() {
		if ( Input.GetKeyDown( KeyCode.Space ) || Input.GetMouseButtonDown( 0 ) ) {
			PlayerScript.enabled = true;
			gameObject.SetActive( false );
			Time.timeScale = 1;
		}
	}
}
