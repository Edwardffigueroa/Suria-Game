using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

	// Use this for initialization
	public Transform camera;

	public Camera miCamara;
	int  shooteableMask;
	float targetTime = 5.0f;//time of gracia for add a combo 
	bool StartTemp=false;
	bool shootear = false;
	private Animator anim;
	public GameObject effect;


	private KeyCombo falconKick= new KeyCombo(new KeyCode[] {KeyCode.E, KeyCode.D, KeyCode.W}, 10);
	private KeyCombo defensa= new KeyCombo(new KeyCode[] {KeyCode.A, KeyCode.R, KeyCode.D}, 15);
	private KeyCombo defensaDos= new KeyCombo(new KeyCode[] {KeyCode.A, KeyCode.N, KeyCode.D}, 30);
	
	// private bool ataqueUno= false;
	// private bool ataqueDos= false;
	// private bool ataqueTres= false;

	//-------------UI------------

	public Slider timerShoot;

	public Slider currentLifeEnemy;

	public Image key1;
	public Image key2;
	public Image key3;

	List<KeyCombo> combos = new List<KeyCombo>();
    List<KeyCombo> termsList = new List<KeyCombo>();
	void Start () {

		currentLifeEnemy.gameObject.SetActive(false);
		effect.SetActive(false);
		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
       // Cursor.lockState = CursorLockMode.None; 
		//effect.SetActive(false);
		shooteableMask = LayerMask.GetMask("Shooteable");
		
		timerShoot.gameObject.SetActive(false);
		anim = GetComponent<Animator>();
		anim.SetBool("Shoot", false);
		Debug.Log("Los Combos son: EDW , ARD, AND");
	
	}
	
	// Update is called once per frame
	void Update () {
		
	//	Cursor.lockState = CursorLockMode.Locked;
      //  Cursor.lockState = CursorLockMode.None; 

		

		//lo de guille
		Ray ray = miCamara.ViewportPointToRay(new Vector3(0.5f,0.5f,0.0f));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit) && hit.transform.tag != "Player")
			{
				// Se dirige el cañon al punto en que colisiona el rayo
				effect.transform.LookAt(hit.point);
				
			}else			
			{
				// Si se mira al vacio y no hay colision, se dirige a la mirada de la camara
				effect.transform.LookAt(ray.GetPoint(500));
				Debug.DrawRay(ray.GetPoint(100), ray.direction * 100, Color.black);
			}
//fin de lo de guille
         
		 	//-------- if some keyCombo is true, activate and add in List

			//ataque uno

	foreach (var item in combos)
	{
		if(item.CheckKey()){
			addKeyCombotoArray(item);	
		}
	}


	/*	if(falconKick.CheckKey()){
			addKeyCombotoArray(falconKick);
		}

			//ataque dos

		if(defensa.CheckKey()){
			
			addKeyCombotoArray(defensa);

		}*/



			if(termsList.Count>0){ // if there was a check of combo

					StartTemp =true;  //begins the timer for insert other Keycombo
					
			}else{

				StartTemp =false;
				anim.SetBool("Shoot", false);
			

			}

			if(StartTemp){

				if(timer ()==false){

				 timerShoot.gameObject.SetActive(true);

				// Debug.Log("TIEMPO PROGRESO...");

				//si el tiempo no ha finalizado entonces puedes agregar combos si lo deseas...

				// y además si el arreglo el numero del arreglo es igual a 2 entonces dispare...

				if(termsList.Count==2){
					shootear=true;	
				}

				}else{
			
				timerShoot.gameObject.SetActive(false);

				//   Debug.Log("TIEMPO PARADO");

				  //si el tiempo finaliza, entonces dispare lo que haya en el arreglo

				// timerShoot.gameObject.SetActive(false);
				  StartTemp =false;
				  shootear=true;

				}

			}

			if(shootear){
				
			 	// Debug.Log("Shoteado papu");
				shoot(tipoRayo());
				shootear =false;
				targetTime = 5.0f;
				termsList.Clear();
				timerShoot.gameObject.SetActive(false);

			}
	}

	bool timer (){

	
				Debug.Log("empezó temporizador");
				targetTime -= Time.deltaTime;

 				if (targetTime < 0.0f)
 				{

    				Debug.Log("terminó temporizador");	

					return true;
					//disparar

 				}else {
					
					timerShoot.value = targetTime;
					 // Debug.Log("current time: "+ targetTime);
					 return false;
					//permite agregar los otros

			 }		
	}

	void addKeyCombotoArray(KeyCombo i){

		if(termsList.Count<3){

				termsList.Add(i); 

		}

	}

	int tipoRayo (){

	//if the timer has ended.

	//if array.size of KeyCombos is less that 2 , return the number of the object.
		
		if(termsList.Count<2){

			return termsList[0].power;

		}else{

	//if array.size of KeyCombos is grater that 1, return the plus number of the objects in the array.

		int comboUno = termsList[0].power;
		int comboDos = termsList[1].power; 

		return  comboUno + comboDos;

		}

	}

	IEnumerator HiloocultarSliderEnemy(){
		yield return new WaitForSeconds(2);
		ocultarSliderEnemy();
	}

	void ocultarSliderEnemy(){

		currentLifeEnemy.gameObject.SetActive(false);

	}

	void shoot(int powers){

		effect.SetActive(true);
		anim.SetBool("Shoot", true);

		Ray rayS = new Ray(camera.position, camera.forward);
		//Ray rayS = Camera.main.ScreenPointToRay(camera.transform.forward);

		Debug.DrawRay(rayS.origin, rayS.direction, Color.blue);

		RaycastHit targetHit;

		if(Physics.Raycast(rayS, out targetHit, Mathf.Infinity ,shooteableMask)){

			Enemy enemyHealth = targetHit.collider.GetComponent <Enemy>();

			if(enemyHealth!=null){

				enemyHealth.quitarVida(powers);
				currentLifeEnemy.gameObject.SetActive(true);
				currentLifeEnemy.value= enemyHealth.vida;
				StopCoroutine("HiloocultarSliderEnemy");
				StartCoroutine("HiloocultarSliderEnemy");

			}else{

				ocultarSliderEnemy();
			}

			Debug.DrawRay(rayS.origin, targetHit.collider.transform.position, Color.blue );
			
			//Debug.Log("hay un hit: "+targetHit.collider.name);

		}else{
			
		}

	}

	void OnTriggerEnter(Collider other) {

		if(other.gameObject.CompareTag("collectableKey")){

			other.gameObject.SetActive(false);

			if(other.gameObject.name=="KeyUno"){	
				
				key1.gameObject.SetActive(true);
					 combos.Add(falconKick);
			}
			if(other.gameObject.name=="KeyDos"){
				
				key2.gameObject.SetActive(true);
				combos.Add(defensa);
			}
			if(other.gameObject.name=="KeyTres"){
				
				key3.gameObject.SetActive(true);
					combos.Add(defensaDos);
			}

		}
	}

}
