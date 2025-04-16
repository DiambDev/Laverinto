using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerMove : MonoBehaviour
{
    public float velocity;
    public int id;
    Rigidbody2D rgb;
    [SerializeField] LineRenderer Ayuda;
    public Action LLegar;
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

        switch (id)
        {
            case 1:
                if (Input.GetKey(KeyCode.W))
                {
                    rgb.velocity = Vector2.up * velocity;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    rgb.velocity = Vector2.down * velocity;
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    rgb.velocity = Vector2.left * velocity;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    rgb.velocity = Vector2.right * velocity;
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rgb.velocity = Vector2.up * velocity;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    rgb.velocity = Vector2.down * velocity;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rgb.velocity = Vector2.left * velocity;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    rgb.velocity = Vector2.right * velocity;
                }
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("asd" + id);
            rgb.velocity = Vector2.zero;   
        }
        
        if(Mathf.Abs(transform.position.x - collision.gameObject.transform.position.x) < 0.5f)
        {
            float y = 0.2f * ( collision.gameObject.transform.position- transform.position).normalized.y;
            transform.position = new Vector3(transform.position.x, transform.position.y - y, transform.position.z);
            
        }
        if (Mathf.Abs(transform.position.y - collision.gameObject.transform.position.y) < 0.5f)
        {
            float x = 0.2f * (collision.gameObject.transform.position- transform.position).normalized.x;
            transform.position = new Vector3(transform.position.x - x, transform.position.y, transform.position.z);
        }
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Meta")
        {
            Debug.Log("asd" + id);
            LLegar?.Invoke();
        }
    }

}
