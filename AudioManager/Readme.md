## 🔈 AudioManager

### Overview

AudioManager creates a pool of AudioPlayers (each with their own AudioSource) for use in playing clips in 2D and 3D space.

### Usage

1. Drop AudioManager.cs and AudioPlayer.cs into your Assets/Scripts/ folder.
2. Add the AudioManager script to a GameObject in your scene.
3. When you want to play a clip call one of these functions: 

```csharp
// Play a clip in 2D (and a version to randomize the clip selection from an array)
AudioManager.i.PlayClip(AudioClip clip, float volume, float pitch)
AudioManager.i.PlayClip(AudioClip[] clip, float volume, float pitch)

// Play a clip in 3D (and a version to randomize the clip selection from an array)
AudioManager.i.PlayClipAtPosition(AudioClip clip, Vector3 position, float volume, float pitch)
AudioManager.i.PlayClipAtPosition(AudioClip[] clip, Vector3 position, float volume, float pitch)
```

These functions return an AudioPlayer which contain the full AudioSource if you want more control and options. 
