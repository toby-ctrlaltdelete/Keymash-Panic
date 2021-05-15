using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGameFlyMovement : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public float time;
	public float changeInterval = 0.5f;
	
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

	// Creates a new position for the ball, for use after the flyswatter hits
	public void NewPosition()
	{
		float randX = Random.Range(-0.43f,0.43f);
		float randY = Random.Range(-0.43f,0.43f);
		
		transform.localPosition = new Vector2(randX, randY);
	}
	
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
		if (time >= changeInterval) {
			time = 0;
			rb2d.velocity = new Vector2(0,0);
			float newX = Random.Range(-1.0f,1.0f);
			float newY = Random.Range(-1.0f,1.0f);
			rb2d.AddForce(new Vector2(newX, newY));
		}
    }
	
}
