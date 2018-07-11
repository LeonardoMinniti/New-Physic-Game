using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player1Script : MonoBehaviour {

    public Rigidbody2D rbPlayer1;
    public Slider sliderPower;
    public GameObject shooter;
    public GameObject player1;
    public GameObject playerGas;
    public GameObject playerAngle;
    private Rigidbody2D shotsRb2d;
    private bool checkPowerSlider;
    private bool maxOrminValue;
    private float shotPower; // power value
    private bool checkAction;

    public float speed;
    public float gas;
    private float angle;

	void Start()
    {
        
        gas = 100f;
        maxOrminValue = true;
        playerGas.transform.localScale = new Vector2(1f, 0.1f);

    }
	// Update is called once per frame
	void FixedUpdate () {
        if(Input.GetKey("d")|| Input.GetKey("a"))
        {
            checkAction = true;
        }

        if (checkAction && Input.GetKey("a"))
        {
            gas -= 30 * Time.deltaTime;

            

            transform.eulerAngles = new Vector3(0f, 180f, 0f);

            if (gas >= 0)
            {
                playerGas.transform.localScale = new Vector2(gas / 100f, 0.1f);

                float moveHorizontal = Input.GetAxis("Horizontal");

                Vector2 movement = new Vector2(moveHorizontal, 0f);

                rbPlayer1.AddForce(movement * speed);
            }
            checkAction = false;

        }
        else if(Input.GetKey("d") && checkAction)
        {
            gas -= 30 * Time.deltaTime;

            

            transform.eulerAngles = new Vector3(0f, 0f, 0f);

            if(gas >= 0)
            {
                playerGas.transform.localScale = new Vector2(gas / 100f, 0.1f);

                float moveHorizontal = Input.GetAxis("Horizontal");

                Vector2 movement = new Vector2(moveHorizontal, 0f);

                rbPlayer1.AddForce(movement * speed);
            }
            checkAction = false;


        }
       
        
	}
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            checkAction = false;
            sliderPower.value = 0;
            checkPowerSlider = true;


        }

        if (Input.GetButtonUp("Jump"))
        {
            checkAction = true;
            checkPowerSlider = false;
            Shoot();
        }
        if (Input.GetKey("w")&& !checkAction)
        {
            angle += Time.deltaTime*20;
            playerAngle.transform.eulerAngles = new Vector3(0f,0f,angle);
        }

        if (Input.GetKey("s") && !checkAction)
        {
            angle -= Time.deltaTime * 20;
            playerAngle.transform.eulerAngles = new Vector3(0f, 0f, angle);

        }

        if (checkPowerSlider)
        {
            if (maxOrminValue)
            {
                sliderPower.value += Time.deltaTime * 60;

                if (sliderPower.value == sliderPower.maxValue)
                {
                    maxOrminValue = false;
                }

            }
            else
            {
                sliderPower.value -= Time.deltaTime * 60;

                if (sliderPower.value == sliderPower.minValue)
                {
                    maxOrminValue = true;
                }
            }
        }
    }
    void Shoot()
    {
        shotPower = sliderPower.value * 10;
        GameManager.bullet.transform.position = shooter.transform.position;
        GameManager.bullet.SetActive(true);
        shotsRb2d = GameManager.bullet.GetComponent<Rigidbody2D>();
        shotsRb2d.AddForce((playerAngle.transform.GetChild(0).position - transform.position) *shotPower);
        
        
    }
}
