using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGameController : MonoBehaviour
{
	public GameObject Basket;
	public KeyCode Action = KeyCode.E;
	
	private Rigidbody2D rb2d;
	private float basketPos1 = -0.25f;
	private float basketPos2 = 0.25f;
	private int currentBasketPos = 1;
	
    //Ensure the gravity and velocity is at zero, so it doesn't fall before we want it to fall
    void Start()
    { 
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.gravityScale = 0.0f;
		rb2d.velocity = Vector2.zero;
		Invoke("MakeEggFall", 2);
    }
	
	//And this is for when we want it to fall
	void MakeEggFall()
	{
		rb2d.gravityScale = 0.25f;
	}
	
	void Update()
	{
		if (Input.GetKeyDown(Action)) {
			//Thankfully, since there's only two positions for the basket, an if else statement is perfect here!
			if (currentBasketPos == 1) {
				currentBasketPos = 2;
				Basket.transform.localPosition = new Vector2(basketPos2, -0.3f);
			}
			else {
				currentBasketPos = 1;
				Basket.transform.localPosition = new Vector2(basketPos1, -0.3f);
			}
		}
	}
	
	//Check if the egg hits the basket
	void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "EggBasket")
        {
			GameScoreManager.Score(1);
        }
		float rand = Random.Range(-0.4f,0.4f);
		transform.localPosition = new Vector2(rand, 0.4f);
		rb2d.gravityScale = 0.0f;
		rb2d.velocity = Vector2.zero;
		Invoke("MakeEggFall", 1);
    }
}
