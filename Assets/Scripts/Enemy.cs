using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    private float speed;

    
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

            p.takeDamage(1);
            Destroy(this.gameObject);
        }
        if(collision.tag == "Ground")
        {
            Debug.Log("TEST1");
            Destroy(this.gameObject);
            Debug.Log("TEST2");
        }


    }
}
