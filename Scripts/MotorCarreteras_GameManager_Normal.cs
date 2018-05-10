using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras_GameManager_Normal : MonoBehaviour {

	int contadorCalles = 0;
	int numeroSelectorCalles;

	public float velocidad;
	public float tamañoCalle;
	public bool inicioJuego;
	public bool juegoTerminado;
	public bool salioDePantalla;

	public GameObject contenedorCallesGO;
	public GameObject[] contenedorCallesArray;

	public GameObject calleAnterior;
	public GameObject calleNueva;
	public GameObject mCamGo;
	public GameObject carroGO;
	public GameObject audioFXGO;
	public GameObject bgFinalGO;

	public Camera mCamComp;
	public AudioFX audioFXScript;

	public Vector3 medidaLimitePantalla;

	[Header("---PRUEBA ALEATORIO")]
	public GameObject hazard;//Asteroides (Peligro)
	public Vector3 spawnValues;
	public int hazardCount;//numero Asteroides
	public float spawnWait;// espera Asteroides
	public float startWait;//espera inicial
	public float waveWait;//espera siguiente ola de asteroides


	// Use this for initialization
	void Start () {
		InicioJuego ();
	}
	void InicioJuego(){

		contenedorCallesGO = GameObject.Find ("ContenedorCalles");
		mCamGo = GameObject.Find ("MainCamera");
		mCamComp = mCamGo.GetComponent<Camera> ();

		bgFinalGO = GameObject.Find ("PanelGameOver");
		bgFinalGO.SetActive (false);

		audioFXGO = GameObject.Find ("AudioFX");
		audioFXScript = audioFXGO.GetComponent<AudioFX> ();

		carroGO = GameObject.FindObjectOfType<Carro> ().gameObject;

		VelocidadMotorCarretera ();
		MedirPantalla ();
		BuscarCalles ();
	}

	public void TerminarJuego(){
		carroGO.GetComponent<AudioSource> ().Stop ();
		audioFXScript.FXReproducirMusica ();
		bgFinalGO.SetActive (true);

	}



	void VelocidadMotorCarretera(){
		velocidad = 12;
	}

	void BuscarCalles(){
		contenedorCallesArray = GameObject.FindGameObjectsWithTag ("Calle");
		for (int i = 0; i < contenedorCallesArray.Length; i++) {
			contenedorCallesArray [i].gameObject.transform.parent = contenedorCallesGO.transform;
			contenedorCallesArray [i].gameObject.SetActive (false);
			contenedorCallesArray [i].gameObject.name = "CalleOFF_" + i;
		}
		CrearCalles ();

	}

	void CrearCalles(){
		contadorCalles ++;
		numeroSelectorCalles = Random.Range (0, contenedorCallesArray.Length);
		GameObject Calle = Instantiate (contenedorCallesArray [numeroSelectorCalles]);
		Calle.SetActive (true);
		Calle.name = "Calle" + contadorCalles;
		Calle.transform.parent = gameObject.transform;
		PosicionarCalles ();
	}

	void PosicionarCalles(){
		calleAnterior = GameObject.Find ("Calle" + (contadorCalles - 1));  
		calleNueva = GameObject.Find ("Calle" + contadorCalles);
		MedirCalle ();
		calleNueva.transform.position = new Vector3 (calleAnterior.transform.position.x, calleAnterior.transform.position.y + tamañoCalle, 0);
		StartCoroutine (SpawnWaves());
		salioDePantalla = false;
	}
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Instantiate (hazard, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	void MedirCalle(){
		for (int i = 0; i < calleAnterior.transform.childCount; i++) {
			
			if(calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null) {
				float tamañoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
				tamañoCalle = tamañoCalle + tamañoPieza;
			}
		}
	}

	void MedirPantalla(){
		medidaLimitePantalla = new Vector3 (0,mCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f,0);
	
	}
	// Update is called once per frame
	void Update () {
		if (inicioJuego == true && juegoTerminado == false) {
			transform.Translate (Vector3.down * velocidad * Time.deltaTime);

			if (calleAnterior.transform.position.y + tamañoCalle < medidaLimitePantalla.y && salioDePantalla == false) {
				salioDePantalla = true;
				DestruirCalles ();

			}
		}
	}

	void DestruirCalles(){
		Destroy (calleAnterior);
		tamañoCalle = 0;
		calleAnterior = null;
		CrearCalles ();
	}


	  

}
