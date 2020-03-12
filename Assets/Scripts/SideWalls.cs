using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
	public PlayerMovement player;

	[SerializeField]
	private GameManager gameManager; 

	void OnTriggerEnter2D(Collider2D anotherCollider)
	{
		if (anotherCollider.name == "Ball")
		{
			player.IncreamentScore();

			if (player.Score() < gameManager.maxScore)
            {
                anotherCollider.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
		}
	}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
