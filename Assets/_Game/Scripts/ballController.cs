using UnityEngine;
using System.Collections;

public class ballController : MonoBehaviour {

	public AudioClip rollSound;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponent<Rigidbody>().velocity.x > 0) {
			if(!audio.isPlaying) {
				audio.PlayOneShot(rollSound, 0.1f);
			}
		}
		else
		{
//			float av = audio.volume - 0.5f * Time.deltaTime;
//			if (av < 0.0) av = 0;
//			audio.volume = av;
			GetComponent<AudioSource>().Stop();
		}
	
	}
}
