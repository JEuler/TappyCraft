using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdShower : MonoBehaviour {

	void Start() {
		ShowAd();
	}

	public void ShowAd() {
		if ( Advertisement.IsReady() ) {
			Advertisement.Show();
		}
	}
}
