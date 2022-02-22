using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : MonoBehaviour
{
    public int damage;
    
    public int minSpeed;
    public int maxSpeed;

    public GameObject hitEffect;
    public GameObject deathEffect;

    Player p;
    
    private int speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);

        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        this.transform.rotation = Quaternion.LookRotation(Vector3.forward,this.transform.position - p.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //reduce player health
            p.takeDamage(damage);
            Instantiate(hitEffect, new Vector3(transform.position.x, transform.position.y - 0.3f, -0.3f), Quaternion.identity);
            GameObject.Destroy(gameObject);
        }

        //destroy enemy if hits the ground
        if (collision.tag == "Ground")
        {
            Instantiate(deathEffect, new Vector3(transform.position.x, transform.position.y - 0.5f, -0.3f), Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
}
