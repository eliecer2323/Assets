using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro_Normal : MonoBehaviour {


	public GameObject motorCarreterasGO;
	public MotorCarreteras_GameManager_Normal motorCarreteraScript;

	public float tiempo;
	public float distancia;
	public Text txtTiempo;
	public Text txtDistancia;
	public Text txtDistanciaFinal;
	     

	// Use this for initialization
	void Start () {
		motorCarreterasGO = GameObject.Find ("MotorCarretera");
		motorCarreteraScript = motorCarreterasGO.GetComponent<MotorCarreteras_GameManager_Normal> ();

		txtTiempo.text = "2:00";
		txtDistancia.text = "0";

		tiempo = 120;
	}
	
	// Update is called once per frame
	void Update () {

		if (motorCarreteraScript.inicioJuego == true && motorCarreteraScript.juegoTerminado == false) {
			CalcularTiempoDistancia ();
		}
		if(tiempo <= 0 && motorCarreteraScript.juegoTerminado ==  false){
			motorCarreteraScript.juegoTerminado = true;
			motorCarreteraScript.TerminarJuego ();
			txtDistanciaFinal.text = ((int)distancia).ToString() + " M";
			txtTiempo.text = "00:00";
		}
	}

	void CalcularTiempoDistancia(){
		distancia += Time.deltaTime * motorCarreteraScript.velocidad;
		txtDistancia.text = ((int)distancia).ToString();

		tiempo -= Time.deltaTime;
		int minutos = (int)tiempo / 60;
		int segundos = (int)tiempo % 60;

		txtTiempo.text = minutos.ToString () + ":" + segundos.ToString ().PadLeft (2, '0');
	}
}
