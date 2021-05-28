using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KGameController : MonoBehaviour
{
	public KeyCode Action = KeyCode.K;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(Action)){
			//This takes into account an error margin of 15 degrees in both rotations
			if ((transform.rotation.eulerAngles.z <= 15.0f) ||
				(transform.rotation.eulerAngles.z >= 165.0f && transform.rotation.eulerAngles.z <= 195.0f) ||
				(transform.rotation.eulerAngles.z >= 345.0f)){
				GameScoreManager.Score(1);
			}
		}
		transform.Rotate(0, 0, 45*Time.deltaTime);
    }
}
