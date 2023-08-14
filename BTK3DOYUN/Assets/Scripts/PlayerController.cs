using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 direction;
    public float forwardSpeed;
    public int desiredLane = 1; //0:sol,1:orta,2:sağ
    public float laneDistance = 4;
    public float jumpForce = 3;
    public float Gravity = -20;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
        direction.y += Gravity*Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            Jump();        
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            desiredLane++;
            if(desiredLane==3)
                desiredLane=2;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            desiredLane--;
            if(desiredLane==-1)
                desiredLane=0;
        }  
        Vector3 targetPosition = transform.position.z*transform.forward+transform.position.y*transform.up;      
        if(desiredLane==0){
            targetPosition += Vector3.left*laneDistance;
        }else if(desiredLane==2){
            targetPosition += Vector3.right*laneDistance;
        }

        transform.position = targetPosition;
        controller.center = controller.center;
    }

    void FixedUpdate(){
        controller.Move(direction*Time.fixedDeltaTime);
    }

    void Jump(){
        direction.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
     if(hit.transform.tag == "Engel")
        {
            PlayerManager.gameOver = true;
        }   
    }
   

}
