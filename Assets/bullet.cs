using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public GameObject explosion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        if (collision.transform.CompareTag("Player"))
        {
            if(Mathf.RoundToInt(collision.relativeVelocity.x + collision.relativeVelocity.y) > 0)
            {
                collision.transform.GetComponent<PlayerScript>().Health -= Mathf.RoundToInt(collision.relativeVelocity.x + collision.relativeVelocity.y)*25;
            }
            else
            {
                collision.transform.GetComponent<PlayerScript>().Health += Mathf.RoundToInt(collision.relativeVelocity.x + collision.relativeVelocity.y)*25;
            }
        }
        else if (collision.transform.CompareTag("MapDestructable"))
        {
            Destroy(collision.gameObject);
        }
        if (GameManager.round % 2 == 0)
        {
            GameManager.Player2.roundIsOver = true;
            GameManager.Player1.NewRound();
            GameManager.round++;
            GameManager.windDirection = new Vector3(UnityEngine.Random.Range(-150f, 150f), Random.Range(-150f, 150f), 0f);
        }
        else
        {
            GameManager.Player1.roundIsOver = true;
            GameManager.Player2.NewRound();
            GameManager.round++;

        }
        gameObject.SetActive(false);
    }
}
