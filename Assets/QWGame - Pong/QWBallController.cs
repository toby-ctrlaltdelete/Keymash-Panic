using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: finish this tutorial - https://www.awesomeinc.org/tutorials/unity-pong/
public class QWBallController : MonoBehaviour
{
	private Rigidbody2D rb2d;
	
    // Start is called before the first frame update
    void Start()
    {
		rb2d = GetComponent<Rigidbody2D>();
		Invoke("StartBall", 3);
	}
	
	void StartBall(){
	rb2d = GetComponent<Rigidbody2D>();
    float rand = Random.Range(0, 2);
		if(rand < 1){
			rb2d.AddForce(new Vector2((float)1.0, (float)-0.75));
		} else {
			rb2d.AddForce(new Vector2((float)-1.0, (float)-0.75));
		}
	}

	void ResetBall(){
		rb2d.velocity = Vector2.zero;
		transform.localPosition = Vector2.zero;
		Invoke("StartBall", 5);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if(coll.collider.CompareTag("Player")){
			GameScoreManager.Score(1);
			Vector2 vel;
			float rand = Random.Range((float)-0.3,(float)0.3);
			vel.x = rb2d.velocity.x;
			vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3) + rand;
			rb2d.velocity = vel;
		}
	}
}