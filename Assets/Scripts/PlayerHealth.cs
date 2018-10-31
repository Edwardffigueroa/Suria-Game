using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	// Use this for initialization
	public Slider vida;
	public int maxlife = 100;
	public int currentLife;

	public Canvas canvas;

	public Color MaxHealthColor = Color.green;
     public Color MinHealthColor = Color.red;

	 public Image fill;
	 bool feedbackDamage = false;
	 public Image FeedDamage;
	 public Color flashColor = new Color (1f, 0f, 0f, 0.8f);

	 //códigos de defensa

	private KeyDefensa defUno= new KeyDefensa(new KeyCode[] {KeyCode.F, KeyCode.E, KeyCode.R}, 10);
	private KeyDefensa defDos= new KeyDefensa(new KeyCode[] {KeyCode.J, KeyCode.U, KeyCode.L}, 20);
	private KeyDefensa defTres= new KeyDefensa(new KeyCode[] {KeyCode.I, KeyCode.V, KeyCode.A}, 30);

	public Image key1;
	public Image key2;
	public Image key3;

	float targetTime = 5.0f;//tiempo de duración de la defensa

	int niveldefensa=0;

	bool StartTemp = false;


	List<KeyDefensa> defensas = new List<KeyDefensa>();

	List<KeyDefensa> termsList = new List<KeyDefensa>();

	public GameObject escudo;

	void Start () {

		Debug.Log("Las Defensas son: FER , JUL, IVA");
		

		currentLife = maxlife;
		escudo.gameObject.SetActive(false);
	}

	
	// Update is called once per frame
	void Update () {
	//feedback damage
		if(feedbackDamage){

			FeedDamage.color = flashColor;

		}else{

			FeedDamage.color = Color.Lerp (FeedDamage.color, Color.clear, 5f * Time.deltaTime);
		}

		feedbackDamage =false;

		//----------TODO LO QUE TIENE QUE VER CON LA DEFENSA
	foreach (var item in defensas)
	{
		if(item.CheckKey()){

			addKeyCombotoArray(item);

		}

	}

			if(termsList.Count>0){ 

					StartTemp =true; 
					escudo.gameObject.SetActive(true);// se activa la defensa
					
			}else{

				StartTemp =false;

			}

					if(StartTemp){

				if(timer ()==false){

				

				niveldefensa = calcularnivelDef();

				}else{
			
				  //se quita el escudo y se reinicia todo
				 StartTemp =false;
				escudo.gameObject.SetActive(false);
				 termsList.Clear();
				 targetTime= 5.0f;
				 niveldefensa = 0;


				}

			}

		

		//----------TERMINA TODO LO QUE TIENE QUE VER CON LA DEFENSA


	}

	int calcularnivelDef (){
		if(termsList.Count>0){
			return termsList[0].defensa;
		}else{
			return 0;
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
					
			   		//	timerShoot.value = targetTime;
					//  Debug.Log("current time: "+ targetTime);

					 return false;
					//permite agregar los otros

			 }		
	}

		void addKeyCombotoArray(KeyDefensa i){

		if(termsList.Count<2){

				termsList.Add(i); 

		}

	}

	public void quitarVida(int damage){

		//si el valor del escudo es mayor a el daño que hace el enemigo
		//osea si el valor es negativo entonces el currentlife se queda tal cual

		//si es menor o igual en tonces si se resta


		if(damage>=niveldefensa){

		int def = damage - niveldefensa ;

		currentLife -= def;

		}

		vida.value = currentLife;

		//Debug.Log("le está quitando vida al jugador:"+currentLife);

		//feedBack

		feedbackDamage =true;

		 fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)currentLife / maxlife);
		 

		if(currentLife<=0){

			vida.gameObject.SetActive(false);

			Muerte(); //aqui se muere cuando está debajo de 0 
		}
	}


    void Muerte()

    {
		
    // aqui va la animación de que se murió :v

	Debug.Log("C MURIÓ");
	canvas.gameObject.SetActive(true);
		//Cursor.visible = true;
		//Cursor.lockState = CursorLockMode.None;
       // Cursor.lockState = CursorLockMode.None; 

    }

		void OnTriggerEnter(Collider other) {

		if(other.gameObject.CompareTag("collectableKey")){

			other.gameObject.SetActive(false);

			if(other.gameObject.name=="KeyDefUno"){	
				
				key1.gameObject.SetActive(true);
					 defensas.Add(defUno);
			}
			if(other.gameObject.name=="KeyDefDos"){
				
				key2.gameObject.SetActive(true);
				defensas.Add(defDos);

			}
			if(other.gameObject.name=="KeyDefTres"){
				
				key3.gameObject.SetActive(true);
				defensas.Add(defTres);

			}
		}
	}




}
