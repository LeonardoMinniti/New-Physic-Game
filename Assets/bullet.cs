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
            //take health
        } else if (collision.transform.CompareTag("MapDestructable"))
        {
            Destroy(collision.gameObject);
        }
        gameObject.SetActive(false);
    }
}
