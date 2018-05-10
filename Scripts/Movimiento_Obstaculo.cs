using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Obstaculo : MonoBehaviour {

	private Rigidbody2D rig;

	public float speed;

	void Awake(){
		rig = GetComponent<Rigidbody2D> ();
	}

	void start(){
		rig.velocity = transform.forward * speed;
	}
}
