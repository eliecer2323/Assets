using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour {

	public AudioClip[] fxs;
	AudioSource audioSour;

	void Start(){
		audioSour = GetComponent<AudioSource> ();
	}
	//0Choque  
	public void FXReproducirSonidoChoque(){
		audioSour.clip = fxs [0];
		audioSour.Play ();
	}

    public void FXReproducirSonidoReciclaje()
    {
        audioSour.clip = fxs[1];
        audioSour.Play();
    }

    public void FXReproducirMusica(){
		audioSour.clip = fxs [2];
		audioSour.Play ();
	}


}

