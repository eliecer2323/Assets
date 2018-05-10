using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusObstaculo_Normal : MonoBehaviour {

	public GameObject cronometroGO;
	public Cronometro cronometroScript;


	public GameObject cronometroGO1;
	public Cronometro_Normal cronometroScript1;

	public GameObject audioFXGO;
	public AudioFX audioFXScript;

	void Start(){
		cronometroGO = GameObject.FindObjectOfType<Cronometro> ().gameObject;
		cronometroScript = cronometroGO.GetComponent<Cronometro> ();

		cronometroGO1 = GameObject.FindObjectOfType<Cronometro_Normal> ().gameObject;
		cronometroScript1 = cronometroGO1.GetComponent<Cronometro_Normal> ();

		audioFXGO = GameObject.FindObjectOfType<AudioFX> ().gameObject;
		audioFXScript = audioFXGO.GetComponent<AudioFX> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.GetComponent<Carro>() != null){
			Debug.Log("Antesss");
			if (this.gameObject.CompareTag ("Malo")) {
                audioFXScript.FXReproducirSonidoChoque();
                Debug.Log("Llegooo Malo");
				//cronometroScript.tiempo = cronometroScript.tiempo - 20;
				cronometroScript1.tiempo = cronometroScript1.tiempo - 20;

			} 
			if (this.gameObject.CompareTag ("Bueno")) {
                audioFXScript.FXReproducirSonidoReciclaje();
                //cronometroScript.tiempo = cronometroScript.tiempo + 10;
                cronometroScript1.tiempo = cronometroScript1.tiempo + 10;
			
			}
			Debug.Log("Despuesss");

			Destroy (this.gameObject);
		}
	}


} 
