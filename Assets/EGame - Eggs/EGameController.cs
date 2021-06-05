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
	
    // Start is called before the first frame update
    void Start()
    { 
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.gravityScale = 0.0f;
		rb2d.velocity = Vector2.zero;
		Invoke("MakeEggFall", 2);
    }
	
	void MakeEggFall()
	{
		rb2d.gravityScale = 0.25f;
	}
	
	void Update()
	{
		if (Input.GetKeyDown(Action)) {
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
