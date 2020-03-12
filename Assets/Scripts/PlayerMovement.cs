using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// setting controller
	public KeyCode upButton = KeyCode.W;
	public KeyCode downButton = KeyCode.S;

	// setting speed player
	public float speed = 10.0f;

	// batas atas dan bawah
	private float yBoundary = 9.0f;

	// declare rigidbody2D 
	private Rigidbody2D rb ;

	// set score 
	private int score;

	//debug
	private ContactPoint2D lastCP;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;

        PowerUp();

        if(Input.GetKey(upButton))
        {
        	velocity.y = speed;
        }
        else if (Input.GetKey(downButton))
        {
        	velocity.y = -speed;
        }else{
        	velocity.y = 0.0f;
        }

        rb.velocity = velocity;

        Vector3 position = transform.position;

        if (position.y > yBoundary)
        {
        	position.y = yBoundary;
        }
        else if (position.y < -yBoundary)
        {
        	position.y = -yBoundary;
        }

        transform.position = position;
    }

    public void IncreamentScore()
    {
    	score++;
    }

    public void ResetScore()
    {
    	score = 0;
    }

    public int Score()
    {
    	return score;
    }

    public ContactPoint2D LastCP()
    {
    	return lastCP;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Ball"))
        {
            lastCP = collision.GetContact(0);
        }
    }

    void PowerUp()
    {
  		
    	if (score == 3 || score == 6)
    	{
    		transform.localScale = new Vector3(1,4,1);
    	}else{
    		transform.localScale = new Vector3(1,1,1);
    	}
    }
}
