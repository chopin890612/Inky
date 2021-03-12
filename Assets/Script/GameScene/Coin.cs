using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Awake()
    {
        //Invoke("Delete", 10f);
        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<ParticleSystem>().Play();
            Invoke("Delete",0.2f);
        }
    }
    private void Delete()
    { 
        Destroy(gameObject);
        GameManager.data.coin += 1;
    }
}
