using UnityEngine;
using System.Collections;

public class AddScore : MonoBehaviour {
	public void OnTriggerEnter2D( Collider2D collision ) {
		if ( collision.tag == "Player" ) {
			ScoreManager.instance.AddScore();
			gameObject.SetActive( false );
		}
	}
}
