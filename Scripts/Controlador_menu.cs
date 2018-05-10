using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador_menu : MonoBehaviour {

	public void LoadScene(string NombreScena)
	{
		SceneManager.LoadScene (NombreScena);

	}
}
