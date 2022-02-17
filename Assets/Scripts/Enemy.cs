using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    private float speed;

    public int damage;

    //death Particle Effect
    public GameObject deathEffect;
    public GameObject hitEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        //Random value between min and max speed
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") {
            Player p = collision.gameObject.GetComponent<Player>();

            p.takeDamage(damage);
            Instantiate(hitEffect, new Vector3(transform.position.x, transform.position.y - 0.3f, -0.3f), Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
        
        if(collision.tag == "Ground")
        {
            Instantiate(deathEffect, new Vector3(transform.position.x, transform.position.y - 0.5f, -0.3f), Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
}
