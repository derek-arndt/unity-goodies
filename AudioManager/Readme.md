## AudioManager

### Overview

AudioManager creates a pool of AudioPlayers (each with their own AudioSource) for use in playing clips in 2D and 3D space.

### Usage

1. Add the AudioManager script to a GameObject in your scene.
2. When you want to play a clip call one of these functions: 

```csharp
// 2D clip
AudioManager.i.PlayClip(AudioClip clip, float volume, float pitch)
// 2D clip randomly selected from array
AudioManager.i.PlayClip(AudioClip[] clip, float volume, float pitch)

// 3D clip
AudioManager.i.PlayClipAtPosition(AudioClip clip, Vector3 position, float volume, float pitch)
// 3D clip randomly selected from array
AudioManager.i.PlayClipAtPosition(AudioClip[] clip, Vector3 position, float volume, float pitch)
```

These functions return an AudioPlayer which contain the full AudioSource if you want more control and options. 
