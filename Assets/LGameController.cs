using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGameController : MonoBehaviour
{
	public KeyCode Action = KeyCode.L;
	public GameObject Hole;
	public GameObject BallArrow;
	private Rigidbody2D rb2d;
	
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		NewHolePosition();
    }
	
	void NewHolePosition()
	{
		//So as to prevent the ball from spawning directly over the hole, this chooses a hole placement within range
		//and randomly decides if it should be positive or negative, thus placing it around one of four corners
        float randX = Random.Range(0.12f,0.3f);
		int randXneg = Random.Range(0,2);
		if (randXneg == 1) {
			randX = randX * -1;
		}
		float randY = Random.Range(0.12f,0.3f);
		int randYneg = Random.Range(0,2);
		if (randYneg == 1) {
			randY = randY * -1;
		}
		
		Hole.transform.localPosition = new Vector2(randX, randY);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(Action)) {
			rb2d.AddForce(transform.right * 1);
		}
        transform.Rotate(0, 0, 45*Time.deltaTime);
    }
	
	void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "LGameHole")
        {
			GameScoreManager.Score(1);
			Invoke("NewHolePosition", 0);
        }
		transform.localPosition = Vector2.zero;
		rb2d.velocity = Vector2.zero;
    }
}
