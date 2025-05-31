using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed=10;
    public int coins=0;
    public Rigidbody2D rgb;
    //public SFXController[] sfxController;
    private void Start()
    {
        //rgb = GetComponent<Rigidbody2D>();
    }
    //private void Update()
    //{
    //    //Transform
    //    MovementPlayerGetKey();//2
    //    //MovementPlayerGetAxis();//1
    //}
  
    //Transform + Vector + speed + Time.deltaTime
    void MovementPlayerGetKey()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x-(speed*Time.deltaTime)
                , transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x , transform.position.y - (speed * Time.deltaTime)
                , 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x +(speed * Time.deltaTime)
                , transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x , transform.position.y + (speed * Time.deltaTime)
                , 0);
        }
    }
    void MovementPlayerGetAxis()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.position = new Vector3(transform.position.x + (x * speed * Time.deltaTime)
            , transform.position.y + (y * speed * Time.deltaTime), 0);
    }

    private void FixedUpdate()
    {
        //Rigibody2D
 
        MovementPlayerGetAxisRgb();//1
    }
    //Rigidbody2D + Vector + speed + Time.deltaTime
    void MovementPlayerGetAxisRgb()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rgb.velocity = new Vector3((x * speed), (y * speed), 0);
    }
    void MovementPlayerGetKeyRgb()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rgb.velocity = new Vector3( (-speed), 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rgb.velocity = new Vector3(0,  (-speed ), 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rgb.velocity = new Vector3( (speed ),0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rgb.velocity = new Vector3(0 , (speed ), 0);
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            coins++;
        }
    }
}
