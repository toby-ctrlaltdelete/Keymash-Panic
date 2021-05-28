using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGameController : MonoBehaviour
{
	public GameObject Reticle;
	public KeyCode Action = KeyCode.B;
	private bool isReticleOver = false;
	
	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.name == "BReticle") {
        isReticleOver = true; }
    }

	void OnTriggerExit2D(Collider2D other)
    {
		if (other.name == "BReticle") {
        isReticleOver = false; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Action)) {
			if (isReticleOver == true) {
				GameScoreManager.Score(1);
			}
			else {
				GameScoreManager.LifeLoss(1);
			}
		}
    }
}
