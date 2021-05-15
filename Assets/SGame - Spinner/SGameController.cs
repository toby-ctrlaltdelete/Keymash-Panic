using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameController : MonoBehaviour
{
	public KeyCode Action = KeyCode.S;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Action)) {
			if (transform.rotation.z < 0){
				
				if (transform.rotation.z > -0.75 && transform.rotation.z < 0) {
					GameScoreManager.Score(1);
				}
				else {
					GameScoreManager.Score(10);
				}
			}
			else {
				if (transform.rotation.z < 0.75 && transform.rotation.z > 0) {
					GameScoreManager.Score(1);
				}
				else {
					GameScoreManager.Score(10);
				}
			}
		}
		
		transform.Rotate(0, 0, 50*Time.deltaTime);
    }
}
