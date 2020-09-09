## AudioManager & AudioPlayer

### Overview

AudioManager creates a pool of AudioPlayers (each with their own AudioSource) for use in playing clips in 2D and 3D space.

### Usage

Add the AudioManager script to a GameObject in the scene and refer to it when you'd like to play some audio. 

```
AudioManager.i.PlayClip(clip, volume, pitch)
AudioManager.i.PlayClipAtPosition(clip, position, volume, pitch)
```