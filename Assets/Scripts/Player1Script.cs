using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour {

    public Rigidbody2D rbPlayer1;

    public GameObject player1;

    public float speed;

    public float gas;

	void Start()
    {
        gas = 100f;

    }
	// Update is called once per frame
	void FixedUpdate () {
        bool inputKeyA = Input.GetKey("a");
        bool inputKeyD = Input.GetKey("d");


        if (inputKeyA && gas >= 0f)
        {
            gas -= gas * Time.deltaTime;

            transform.eulerAngles = new Vector3(0f, 180f, 0f);

            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector2(moveHorizontal, 0f);

            rbPlayer1.AddForce(movement * speed);
        }
        else if(inputKeyD)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);

            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector2(moveHorizontal, 0f);

            rbPlayer1.AddForce(movement * speed);
        }
        
	}
}
