using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Rigidbody2D projectile;
    private float windForce;
    private Vector3 windDirection;
    public static GameObject bullet;

    private int round;

	// Use this for initialization
	void Start () {
        round = 1;

        windDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f) * 150, 0f, Random.Range(-1f, 1f) * 150);
        bullet = transform.GetChild(0).gameObject;
        projectile = bullet.GetComponent<Rigidbody2D>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D collider2D)
    {
        Debug.Log("value is" + windForce);
        Debug.Log(windDirection);
        projectile.AddForce(windDirection * Time.deltaTime);
    }
}
