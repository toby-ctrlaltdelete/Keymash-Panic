using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JGameController : MonoBehaviour
{
	public KeyCode Action = KeyCode.J;
	public GameObject Hazard;
	private Rigidbody2D rb2d;
	private Rigidbody2D Hazardrb2d;
	private bool canJump = true;
	
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		Hazardrb2d = Hazard.GetComponent<Rigidbody2D>();
		ResetHazard();
    }
	
	void ResetHazard()
	{
		Hazard.transform.localPosition = new Vector2(0.4f, -0.15f);
		Hazardrb2d.velocity = new Vector2(-0.5f,0);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Action) && canJump == true)
		{
			rb2d.velocity = new Vector2(0,3.4f);
			canJump = false;
		}
		if (Hazard.transform.localPosition.x <= -0.4f) {
			GameScoreManager.Score(1);
			ResetHazard();
		}
    }
	
	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "JGameHazard")
		{
			GameScoreManager.LifeLoss(1);
			ResetHazard();
		}
    }
	
	void OnCollisionEnter2D (Collision2D coll) {
		if(coll.collider.CompareTag("Ground")){
			canJump = true;
		}
	}
}
