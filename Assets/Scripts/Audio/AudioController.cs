using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AudioController 
{
	public AudioSource audioSource;
	private double[] volumes;
	private float stepsPerSecond;

	public AudioController(AudioSource audioSource)
	{
		this.audioSource = audioSource;
	}

	public void play(string audioPath, string volumesPath)
	{
		StreamReader reader = new StreamReader(volumesPath);
		string contents = reader.ReadToEnd();
		reader.Close ();

		this.volumes = Array.ConvertAll(contents.Split(','), Double.Parse);
		this.audioSource.clip = Resources.Load<AudioClip> (audioPath);
		this.stepsPerSecond = (float)this.volumes.Length / this.audioSource.clip.length;
		this.audioSource.Play ();
	}

	public float getCurrentVolume(float boost)
	{
		int i = (int)Mathf.Ceil(this.stepsPerSecond * this.audioSource.time);
		if (i >= 0 && i < this.volumes.Length) {
			return Mathf.Min((float)this.volumes [i] * boost, 1f);
		}
		return 0f;
	}
}
