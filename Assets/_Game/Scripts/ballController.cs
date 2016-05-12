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
			GetComponent<AudioSource>().Stop();
		}
	
	}
}
