using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Rigidbody2D projectile;
    public static Vector3 windDirection;
    public static GameObject bullet;
    public static float timer;
    public static Text timertext;
    public static PlayerScript Player1;
    public static PlayerScript Player2;
    public Image windArrow;
    public Text windStrength;
    public Image gameOverScreen;
    public Text gameOverText;

    public Text roundText;


    public static int round;

	// Use this for initialization
	void Start () {
        round = 1;
        windDirection = new Vector3(UnityEngine.Random.Range(-150f, 150f), Random.Range(-150f, 150f), 0f);
        bullet = transform.GetChild(0).gameObject;
        projectile = bullet.GetComponent<Rigidbody2D>();

        timertext = GameObject.Find("Timer").GetComponent<Text>();
        Player1 = GameObject.Find("Player 1").GetComponent<PlayerScript>();
        Player2 = GameObject.Find("Player 2").GetComponent<PlayerScript>();
        Player1.NewRound();
        Player1.UpdateSlider();
        Player2.UpdateSlider();



        
	}
	
	// Update is called once per frame
	void Update () {

        UpdateTimer();
        UpdateRound();
        UpdateWind();

        if (Player1.Health <= 0)
        {
            Player1.gameObject.SetActive(false);
            GameOver();
            gameOverText.text = ("Congratulations Player 2 Wins!");
        }
        else if(Player2.Health <= 0)
        {
            Player2.gameObject.SetActive(false);
            GameOver();
            gameOverText.text = ("Congratulations Player 1 Wins!");
        }
    }

    void UpdateWind()
    {
        Debug.Log(windDirection.normalized);
        float angle = Vector3.Angle(windDirection.normalized, Vector3.right);
        Debug.Log("angle: " + angle);
        windArrow.transform.rotation = Quaternion.Euler(0f, 0f, -90f + angle);
        windStrength.text = ("Wind Strength is :" + Mathf.Floor(Mathf.Abs((windDirection.normalized.x + windDirection.normalized.y) / 2) * 100));
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        Debug.Log(windDirection);
        projectile.AddForce(windDirection * Time.deltaTime);
    }

    private void UpdateTimer()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timertext.text = "Timer : 0";
        }
        else
        {
            timertext.text = "Timer : " + Mathf.Round(timer);
        }
    }

    private void UpdateRound()
    {
        roundText.text = "round : " + round;
    }
    private void GameOver()
    {

        gameOverScreen.gameObject.SetActive(true);

    }
}
