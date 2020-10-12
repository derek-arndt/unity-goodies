using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

// AudioManager
// Creates a pool of AudioPlayers for us in playing clips in 2D and 3D space

public class AudioManager : MonoBehaviour
{
	public int poolSize = 20;

	private static AudioManager instance;
	public static AudioManager i 
		{ get { return GetInstance(); } }

	List<AudioPlayer> audioObjects = new List<AudioPlayer>();
	
	// Looks for the instance in the scene
	static private AudioManager GetInstance()
	{
		if(instance != null)
			return instance;
		
		AudioManager[] instances = FindObjectsOfType<AudioManager>();
		if(instances.Length > 1)
		{
			Debug.LogWarning("More than one " + typeof(AudioManager) + " is in the scene!");					
			return null;
		}
		else if(instances.Length == 0)
		{
			Debug.LogWarning("There is no " + typeof(AudioManager) + " in this scene!");				
			return null;
		}
				
		instance = instances[0];
		return instance;
	}

	void Awake()
	{
		for(int i=0; i < poolSize; i++)
		{
			AudioPlayer player = CreateAudioPlayer("AudioPlayer " + (i+1));
			audioObjects.Add(player);
		}
	}
	
	AudioPlayer CreateAudioPlayer(string playerName)
	{
		GameObject newObj = new GameObject(playerName);
		
		AudioPlayer player = newObj.AddComponent<AudioPlayer>();
		
		newObj.transform.SetParent(transform);
		player.enabled = false;
		
		return player;
	}
	
	// Plays a 2D clip
	public AudioPlayer PlayClip(AudioClip clip, float volume, float pitch)
	{
		AudioPlayer player = NextAvailableAudioPlayer();

		if(player == null)
			return null;

		AudioSource audioSource = player.AudioSource;
			
		player.enabled = true;
		player.pitchShift = false;
		audioSource.spatialBlend = 0f;
		audioSource.loop = false;

		audioSource.clip = clip;
		audioSource.volume = volume;
		audioSource.pitch = pitch;
		
		audioSource.Play();
		
		return player;
	}

	// Takes in an array for easy clip randomization
	public AudioPlayer PlayClip(AudioClip[] clips, float volume, float pitch)
	{
		AudioClip clip = clips[Random.Range(0, clips.Length)];
		return PlayClip(clip, volume, pitch);
	}

	// Plays a clip in 3D space at position
	public AudioPlayer PlayClipAtPosition(AudioClip clip, Vector3 position, float volume, float pitch)
	{
		AudioPlayer player = NextAvailableAudioPlayer();

		if(player == null)
			return null;
		
		AudioSource audioSource = player.AudioSource;
			
		player.enabled = true;
		player.pitchShift = false;
		audioSource.spatialBlend = 1f;
		audioSource.loop = false;

		audioSource.clip = clip;
		player.transform.position = position;
		audioSource.volume = volume;
		audioSource.pitch = pitch;
		
		audioSource.Play();
		
		return player;
	}
	
	// Takes in an array for easy clip randomization
	public AudioPlayer PlayClipAtPosition(AudioClip[] clips, Vector3 position, float volume, float pitch)
	{
		AudioClip clip = clips[Random.Range(0, clips.Length)];
		return PlayClipAtPosition(clip, position, volume, pitch);
	}

	AudioPlayer NextAvailableAudioPlayer()
	{
		for(int i=0; i < poolSize; i++)
		{
			if(audioObjects[i].enabled == false)
				return audioObjects[i];
		}
		
		Debug.Log("No available AudioClip objects!");
		
		// Creating GameObjects during gameplay is expensive
		// If emergency audio players are created either increase the pool size or ignore the audio
		return CreateAudioPlayer("AudioPlayer (Emergency)");
	}
}
