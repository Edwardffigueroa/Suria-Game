using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	// Use this for initialization

	Transform jugador;
	NavMeshAgent nav;
	GameObject enemigo;
	private Animator anim;
	public int vida=0;
	bool isDead;

	

	//matar variables

		PlayerHealth vidajugadol;

		public float tiempoEntreAtaque = 0.5f;
		public float timer;

		public int nivelPower = 0;

		bool jugadorAlavista = false;

	
	void Awake(){

		nivelPower = 10;
		vida = 100;
		anim = GetComponent<Animator>();
		jugador = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
		enemigo = GetComponent<GameObject>();

		vidajugadol = jugador.GetComponent<PlayerHealth>();

	}

	// Update is called once per frame
	void Update () {

		
		if(vida > 0){
			nav.SetDestination(jugador.position);
		} else {
			nav.enabled = false;
		}

		timer += Time.deltaTime;

		if(timer >= tiempoEntreAtaque && jugadorAlavista ){

			//Debug.Log("ATACANDO ANDO");

			atacar();

		}

		if(vidajugadol.currentLife<=0){

			//Aqui supongo que todo se detiene 

		}
		


	}

	public void quitarVida(int amount){
		if(isDead)
			return;
		vida -= amount;
		Debug.Log("se le quita la vida: "+ vida);

		if(vida<=0)
			Muerte();
	}

    void Muerte()
    {
        isDead = true;
		anim.SetTrigger("Muerte");
		Destroy(gameObject, 5f);
    }

	void OnTriggerEnter(Collider other) 
	{
		
		if(other.gameObject.CompareTag("Player")){

			jugadorAlavista =true;

		}
		
	}

	  void OnTriggerExit(Collider other) {

		if(other.gameObject.CompareTag("Player")){

			jugadorAlavista =false;

		}
	}

	public void atacar(){

		timer = 0f;

		if(vidajugadol.currentLife>0){

			vidajugadol.quitarVida(nivelPower);
			

		}

	}


}
