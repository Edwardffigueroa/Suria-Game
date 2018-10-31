using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

public float speed = 6f;

public Camera cam ;
Vector3 movement;
Rigidbody playerRigidbody;
 int floorMask;

float camRayLenght = 100f;

public Vector3 playerToMouse;
 void Awake() {
 playerRigidbody = GetComponent<Rigidbody>();
 floorMask = LayerMask.GetMask("Floor");
}

void FixedUpdate() {
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");
    
    move (h,  v);
    Turning();
    
}

void move (float h, float v){

    movement.Set(h ,0f, v);
    movement = movement.normalized*speed*Time.deltaTime;
    playerRigidbody.MovePosition(transform.position + movement);

}

void Turning(){
    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); //esta variable va a contener el rayo de la camara hasta la posición del mouse
    RaycastHit floorHit;//esa variable me devuelve la colisión
    if(Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask)){
         playerToMouse = floorHit.point -transform.position;
         playerToMouse.y = 0f;

        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
        playerRigidbody.MoveRotation(newRotation);

    }
    
}


}
