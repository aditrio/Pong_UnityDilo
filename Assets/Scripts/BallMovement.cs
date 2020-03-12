using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float xInitialForce ;
    public float yInitialForce ;

    private Vector2 trajectoryOrigin;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        RestartGame();
        trajectoryOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBall()
    {
    	transform.position = Vector2.zero;
    	rb.velocity = Vector2.zero;
    }

    void PushBall()
    {
    	float yRandomInitial = Random.Range(-yInitialForce , yInitialForce);

    	float RandomDirection = Random.Range(0,2);

    	if(RandomDirection < 1.0f)
    	{
    		rb.AddForce(new Vector2 (-xInitialForce,10.0f));
    	}else{
    		rb.AddForce(new Vector2 (xInitialForce,10.0f));
    	}
    }

    void RestartGame()
    {
    	ResetBall();
    	Invoke("PushBall" , 2);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
