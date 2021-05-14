using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGameManager : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public KeyCode Action = KeyCode.F;
	public GameObject fly;
	bool FlyOverlapping = false;
	
	void Start ()
	{
		fly = GameObject.Find("/FGameWindow/Fly");
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.name == "Fly") {
        FlyOverlapping = true; }
    }

	void OnTriggerExit2D(Collider2D other)
    {
		if (other.name == "Fly") {
        FlyOverlapping = false; }
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Action)) {
			if (FlyOverlapping == true) {
				GameScoreManager.Score(1);
			}
			if (FlyOverlapping == false) {
				GameScoreManager.LifeLoss(1);
			}
		fly.GetComponent<FGameFlyMovement>().NewPosition();
		}
    }
}
