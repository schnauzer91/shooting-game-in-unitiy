﻿using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject PlayerExplosion;

	GameObject GameController;

	void Start () {

		GameController = GameObject.Find ("GameController");

	}

	void OnTriggerEnter(Collider other) {
	
		if (other.gameObject.tag == "Enemy") {
			return;
		}

		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);
		}	
		if (other.tag == "Player") {

			Instantiate (explosion, other.transform.position, other.transform.rotation);
			GameController.GetComponent<GameController> ().GameOver();			 
		}

		GameController.GetComponent<GameController> ().AddScore (10);		

		Destroy (gameObject);
		Destroy (other.gameObject);


	}

}
