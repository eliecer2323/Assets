using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras_Normal : MonoBehaviour {

	public GameObject motorCarreteraGO;
	public MotorCarreteras_GameManager_Normal motorCarreteraScript;
	public Sprite[] numeros;

	public GameObject contadorNumerosGO;
	public SpriteRenderer contadorNumerosComp;

	public GameObject controladorCarroGO;
	public GameObject carroGO;


	// Use this for initialization
	void Start () {
		InicioComponentes ();
	}

	void InicioComponentes(){

		motorCarreteraGO = GameObject.Find ("MotorCarretera");
		motorCarreteraScript = motorCarreteraGO.GetComponent<MotorCarreteras_GameManager_Normal> ();

		contadorNumerosGO = GameObject.Find ("ContadorNumeros");
		contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer> ();

		carroGO = GameObject.Find ("Carro");
		controladorCarroGO = GameObject.Find("ControladorCarro");

		IniciarCuentaAtras ();
	}


	void IniciarCuentaAtras(){
		StartCoroutine (Contando());
	}

	IEnumerator Contando(){
		controladorCarroGO.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (2);

		contadorNumerosComp.sprite = numeros [1];
		this.gameObject.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (1);

		contadorNumerosComp.sprite = numeros [2];
		this.gameObject.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (1);

		contadorNumerosComp.sprite = numeros[3];
		motorCarreteraScript.inicioJuego = true;
		contadorNumerosGO.GetComponent<AudioSource> ().Play ();
		carroGO.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (2);

		contadorNumerosGO.SetActive (false);

	}



	// Update is called once per frame
	void Update () {
		
	}
}
