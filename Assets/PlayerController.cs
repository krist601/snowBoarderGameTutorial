using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector;
    [SerializeField] float torqueAmount = 0.5f;
    [SerializeField] float boostSpeed = 25.0f;
    [SerializeField] float baseSpeed = 15.0f;
    public bool canMove = true;

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update(){
        Debug.Log(canMove);
        if(canMove){
            rotatePlayer(); 
            boostPlayer();
        }
    }
    void rotatePlayer(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb2d.AddTorque(torqueAmount);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            rb2d.AddTorque(-torqueAmount);
        }
    }
    void boostPlayer(){
        if(Input.GetKey(KeyCode.UpArrow)){
            surfaceEffector.speed = boostSpeed;
        } else {
            surfaceEffector.speed = baseSpeed;
        }
    }
    public void disableControls(){
        canMove = false;
    }
}
