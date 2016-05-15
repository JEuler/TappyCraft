using UnityEngine;
using System.Collections;

public class LooperScript : MonoBehaviour {
	private int numBGPanels = 3;

	private float bookMaxHeight = 1.2f;
	private float bookMinHeight = -7.71f;

	public void Start() {
		GameObject[] books = GameObject.FindGameObjectsWithTag( "Book" );

		foreach ( var book in books ) {
			Vector3 pos = book.transform.position;
			pos.y = Random.Range( bookMinHeight, bookMaxHeight );
			book.transform.position = pos;
		}
	}

	public void OnTriggerEnter2D( Collider2D collision ) {
		float widthOfBGObj = ( ( BoxCollider2D ) collision ).size.x;
		Vector3 pos = collision.transform.position;

		pos.x += widthOfBGObj * numBGPanels;
		if ( collision.tag == "Book" ) {
			pos.y = Random.Range( bookMinHeight, bookMaxHeight );
			collision.transform.FindChild( "ScoreBox" ).gameObject.SetActive( true );
		}
		collision.transform.position = pos;
	}
}
