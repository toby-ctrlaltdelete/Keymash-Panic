using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGameController : MonoBehaviour
{
	public KeyCode Action = KeyCode.N;
	public GameObject MovingWall;
	
	private Rigidbody2D rb2d;
	private string CurrentPos = "Top";
	
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		Invoke("ResetNGame", 0);
    }
	
	void ResetNGame()
	{
		Vector2 localPos = transform.localPosition;
		rb2d.velocity = new Vector2(0.5f, 0);
		transform.localPosition = new Vector2(-0.3f, localPos.y);
		float rand = Random.Range(0, 2);
		if(rand < 1){
			MovingWall.transform.localPosition = new Vector2(0.2f, 0.2f);
		} else {
			MovingWall.transform.localPosition = new Vector2(0.2f, -0.2f);
		}
	}

    // Update is called once per frame
    void Update()
    {
		Vector2 localPos = transform.localPosition;
        if (Input.GetKeyDown(Action)) {
			if (CurrentPos == "Top") {
				CurrentPos = "Bottom";
				localPos.y = -0.2f;
			}
			else {
				CurrentPos = "Top";
				localPos.y = 0.2f;
			}
		}
		transform.localPosition = localPos;
		
		if (transform.localPosition.x >= 0.3f) {
			GameScoreManager.Score(1);
			Invoke("ResetNGame", 0);
		}
	}
	
	void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "NWallHazard")
        {
			GameScoreManager.LifeLoss(1);
			Invoke("ResetNGame", 0);
        }
    }
}
