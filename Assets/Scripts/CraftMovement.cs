using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CraftMovement : MonoBehaviour {
	public float flapSpeed = 15f;
	public float forwardSpeed = 1f;

	private bool didFlap = false;
	private new Rigidbody2D rigidbody2D;

	private bool dead = false;
	public bool GodMode = false;

	// setup then for the die animation
	private Animator animator;

	private AudioSource FlyAudio;
	private AudioSource DieAudio;
	private bool oneTime = false;

	// Use this for initialization
	void Start() {
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();

		var audio = GetComponents<AudioSource>();

		FlyAudio = audio[1];
		DieAudio = audio[0];
	}

	// Update is called once per frame
	void Update() {
		if ( Input.GetKeyDown( KeyCode.Space ) || Input.GetMouseButtonDown( 0 ) ) {
			didFlap = true;
			FlyAudio.Play();
		}
	}

	public void FixedUpdate() {
		if ( dead ) {
			return;
		}
		rigidbody2D.AddForce( Vector2.right * forwardSpeed );
		if ( didFlap ) {
			rigidbody2D.AddForce( Vector2.up * flapSpeed, ForceMode2D.Impulse );
			didFlap = false;
		}
		float angle = 0f;
		if ( rigidbody2D.velocity.y < 0 ) {
			angle = Mathf.Lerp( 0, -60, -rigidbody2D.velocity.y / flapSpeed );
		}
		else if ( rigidbody2D.velocity.y > 0 ) {
			angle = Mathf.Lerp( 0, 60, rigidbody2D.velocity.y / flapSpeed );
		}
		transform.rotation = Quaternion.Euler( 0, 0, angle );
	}

	public void OnCollisionEnter2D( Collision2D collision ) {
		if ( GodMode ) {
			return;
		}
		die();
	}

	private void die() {
		animator.SetTrigger( "Dead" );
		dead = true;
		PlayDieOnce();
		StartCoroutine( "Restart" );
	}

	private void PlayDieOnce() {
		if (!oneTime) {
			DieAudio.Play();
			oneTime = true;
		}
	}

	IEnumerator Restart() {
		yield return new WaitForSeconds( 1.5f );
		SceneManager.LoadScene( 0 );
	}
}
