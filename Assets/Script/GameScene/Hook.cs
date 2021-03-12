using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float distanceRange = 3f;
    public float forceMax = 1.5f;
    public float forceMin = 1f;
    public bool isME = false;
    GameObject player;
    float distance;
    float force;
    private void Start()
    {
        force = Random.Range(forceMin, forceMax);
        distance = Random.Range(1f, distanceRange);
        InvokeRepeating("Hookup", distance, 0.1f);
    }
    private void Update()
    {
        if(isME)
            player.transform.position = gameObject.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            if (player.GetComponent<Player>().inked)
            {
                collision.enabled = false;
                GameController.gaming = false;
                isME = true;
                force = 3f;
            }
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Destroy(gameObject);
            if(isME)
            {
                GameController.gameOver = true;
            }
        }
    }
    void Hookup()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force * 50f));
    }
}
