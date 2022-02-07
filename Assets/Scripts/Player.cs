using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed;
    private float input;
    public int maxHealth;
    private int health;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void Reset()
    {
        health = maxHealth;
        this.transform.position = new Vector3(0f, -4, 0f);
        this.gameObject.SetActive(true); //This game object is visible.
    }

    public void takeDamage(int value)
    {
        health -= value;

        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

}
