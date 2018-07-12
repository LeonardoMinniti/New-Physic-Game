using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public int Health;
    public Rigidbody2D rbPlayer;
    public Slider sliderPower;
    public GameObject shooter;
    public GameObject playerGas;
    public GameObject playerAngle;
    private Rigidbody2D shotsRb2d;
    private bool checkPowerSlider;
    private bool maxOrminValue;
    private float shotPower; // power value
    public bool isMoving;
    private bool hasShot = true;
    public bool roundIsOver = true;
    public bool isPlayer1;

    public Slider playerHealthSlider;
    public Slider playerGasSlider;

    public float speed;
    public float gas;
    private float angle;
    float moveSpeedHorizontal;


    private void Awake()
    {
    }
    void FixedUpdate () {


        if (isMoving)
        {
            gas -= 30 * Time.deltaTime;


            if (gas >= 0)
            {
                playerGas.transform.localScale = new Vector2(gas / 100f, 0.1f);

                Vector2 movement = new Vector2(moveSpeedHorizontal, 0f);

                rbPlayer.AddForce(movement * speed);

                UpdateSlider();

            }

            isMoving = false;
        }
        
	}
    private void Update()
    {
        if (!roundIsOver)
        {
            if(GameManager.timer <= 0)
            {
                roundIsOver = true;
                if (isPlayer1)
                {
                    GameManager.Player2.NewRound();
                }
                else
                {
                    GameManager.Player1.NewRound();
                }
            }

            PlayerMovement();
        }


    }

    private void PlayerMovement()
    {
        moveSpeedHorizontal = Input.GetAxis("Horizontal");

        if (moveSpeedHorizontal != 0)
        {
            isMoving = true;
        }

        if (Input.GetKeyDown("d"))
        {
            transform.eulerAngles = new Vector3(0f, 0, 0f);
        }
        else if (Input.GetKeyDown("a"))
        {
            transform.eulerAngles = new Vector3(0f, 180, 0f);
        }
        if (!hasShot)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //checkAction = false;
                sliderPower.value = 0;
                checkPowerSlider = true;


            }

            if (Input.GetButtonUp("Jump"))
            {
                // checkAction = true;
                checkPowerSlider = false;
                Shoot();
                hasShot = true;
            }
        }
        if (Input.GetKey("w") && !isMoving)
        {
            angle += Time.deltaTime * 20;
            playerAngle.transform.eulerAngles = new Vector3(playerAngle.transform.eulerAngles.x, playerAngle.transform.eulerAngles.y, angle);
        }

        if (Input.GetKey("s") && !isMoving)
        {
            angle -= Time.deltaTime * 20;
            playerAngle.transform.eulerAngles = new Vector3(playerAngle.transform.eulerAngles.x, playerAngle.transform.eulerAngles.y, angle);

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

    public void UpdateSlider()
    {
        playerHealthSlider.value = Health;
        playerGasSlider.value = gas;
    }

    public void NewRound()
    {
        GameManager.timer = 30;
        gas = 100f;
        maxOrminValue = true;
        playerGas.transform.localScale = new Vector2(1f, 0.1f);
        hasShot = false;
        roundIsOver = false;
    }
}
