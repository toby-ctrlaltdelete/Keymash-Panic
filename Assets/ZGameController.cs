using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZGameController : MonoBehaviour
{
	public KeyCode Action = KeyCode.Z;
	public GameObject pickup;
	private Rigidbody2D rb2d;
	private string Direction = "Left";
	
    // Start is called before the first frame update
    void Start()
    {
		rb2d = GetComponent<Rigidbody2D>();
		Invoke("StartBallZ", 2);
	}
	
	void StartBallZ(){
		Direction = "Left";
		rb2d.velocity = new Vector2(-1, 0);
	}

	void ResetBallZ(){
		rb2d.velocity = Vector2.zero;
		pickup.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		transform.localPosition = Vector2.zero;
		Invoke("StartBallZ", 5);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Action)) {
			if (Direction == "Left") {
				Direction = "Right";
				rb2d.velocity = new Vector2(1, 0);
			}
			else //If not left, it must be right
			{
				Direction = "Left";
				rb2d.velocity = new Vector2(-1, 0);
			}
		}
		if (pickup.GetComponent<Transform>().localPosition.y < -0.3f) {
			float rand = Random.Range(-0.3f,0.3f);
			pickup.transform.localPosition = new Vector2(rand, 0.3f);
		}
    }
	
	//Check if the player picked up a score pickup
	void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "ZPickup")
        {
			GameScoreManager.Score(1);
			hitInfo.gameObject.SendMessage("NewPosition", 0, SendMessageOptions.RequireReceiver);
        }
    }
}
