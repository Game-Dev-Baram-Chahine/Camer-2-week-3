using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    float vertical, horizontal;
    Rigidbody2D rigidBody;
    public GameObject topRightLimitGameObject;
    public GameObject bottomLeftLimitGameObject;
    private Vector3 topRightLimit;
    private Vector3 bottomLeftLimit;
    private Vector3 input;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        bottomLeftLimit = bottomLeftLimitGameObject.transform.position;
        topRightLimit = topRightLimitGameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer(){
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if((rigidBody.position.x <= bottomLeftLimit.x)){
            input.x = 1;
        } 
        if((rigidBody.position.y <= bottomLeftLimit.y)){
            input.y = 1;
        } 
         if((rigidBody.position.x >= topRightLimit.x)){
            input.x = -1;
        } 
        if((rigidBody.position.y >= topRightLimit.y)){
            input.y = -1;
        } 
        rigidBody.velocity = new Vector2(input.x*moveSpeed ,input.y*moveSpeed);
          
    }
}
