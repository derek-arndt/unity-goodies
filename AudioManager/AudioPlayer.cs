using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour 
{	
	AudioSource audioSource;
	public AudioSource AudioSource
		{ get { return audioSource; } }
	
	void OnEnable()
	{
		if(audioSource)
			audioSource.enabled = true;
	}
	
	void OnDisable()
	{
		audioSource.clip = null;
		audioSource.enabled = false;
	}

	void Awake()
	{
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = null;
		audioSource.playOnAwake = false;
		audioSource.maxDistance = 100f;		
		audioSource.minDistance = 50f;
		audioSource.dopplerLevel = 0f;
	}
	
	void Update() 
	{
		// disable ourselves when the clip is finished
		if(audioSource.isPlaying == false)
			enabled = false;
	}
}
