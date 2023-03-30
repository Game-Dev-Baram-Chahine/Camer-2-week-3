using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrows : MonoBehaviour
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
        horizontal = 0;
        vertical = 0;
        bottomLeftLimit = bottomLeftLimitGameObject.transform.position;
        topRightLimit = topRightLimitGameObject.transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        rigidBody.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vertical = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            vertical = -1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            horizontal = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            horizontal = 1;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            vertical = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            horizontal = 0;
        }
        if ((rigidBody.position.x <= bottomLeftLimit.x))
        {
            horizontal = 1;
        }
        if ((rigidBody.position.y <= bottomLeftLimit.y))
        {
            vertical = 1;
        }
        if ((rigidBody.position.x >= topRightLimit.x))
        {
            horizontal = -1;
        }
        if ((rigidBody.position.y >= topRightLimit.y))
        {
            vertical = -1;
        }
    }
}
