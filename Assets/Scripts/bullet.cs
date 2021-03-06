﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public GameObject explosion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
    if (!GameManager.bla)
    {
       GameManager.bla = true;
            GameManager.round++;
            Instantiate(explosion, transform.position, Quaternion.identity);
            if (collision.transform.CompareTag("Player"))
            {
                if (Mathf.RoundToInt(collision.relativeVelocity.x + collision.relativeVelocity.y) > 0)
                {
                    collision.transform.GetComponent<PlayerScript>().Health -= Mathf.RoundToInt(collision.relativeVelocity.x + collision.relativeVelocity.y) * 25;
                    GameManager.Player1.UpdateSlider();
                    GameManager.Player2.UpdateSlider();
                }
                else
                {
                    collision.transform.GetComponent<PlayerScript>().Health += Mathf.RoundToInt(collision.relativeVelocity.x + collision.relativeVelocity.y) * 25;
                    GameManager.Player1.UpdateSlider();
                    GameManager.Player2.UpdateSlider();
                }
            }
            else if (collision.transform.CompareTag("MapDestructable"))
            {
            
                Destroy(collision.gameObject);
            
            }
            if (GameManager.round % 2 == 0)
            {
                GameManager.Player1.roundIsOver = true;
                GameManager.Player2.NewRound();
                //  GameManager.Player2.roundIsOver = true;
                //  GameManager.Player1.NewRound();
                //  GameManager.windDirection = new Vector3(UnityEngine.Random.Range(-150f, 150f), Random.Range(-150f, 150f), 0f);
            }
            else
            {
                GameManager.Player2.roundIsOver = true;
                GameManager.Player1.NewRound();
                GameManager.windDirection = new Vector3(UnityEngine.Random.Range(-150f, 150f), Random.Range(-150f, 150f), 0f);
                //GameManager.Player1.roundIsOver = true;
                //GameManager.Player2.NewRound();

            }
            gameObject.SetActive(false);
        }
    }
}
