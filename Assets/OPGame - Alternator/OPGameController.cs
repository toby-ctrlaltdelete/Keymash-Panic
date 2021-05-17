using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPGameController : MonoBehaviour
{
	public KeyCode LeftButtonAction = KeyCode.O;
	public KeyCode RightButtonAction = KeyCode.P;
	public GameObject leftButton;
	public GameObject rightButton;
	private string activeButton = "O";
	
	void Start()
	{
		leftButton.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1f);
		rightButton.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
	}
	
    // Update is called once per frame
    void Update()
    {	
        if (Input.GetKeyDown(LeftButtonAction)) {
			if (activeButton != "O") {
				GameScoreManager.LifeLoss(1);
			}
			//Correct button press; change everything to the right button
			else {
				GameScoreManager.Score(1);
				leftButton.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
				rightButton.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1f);
				activeButton = "P";
			}
		}
		else if (Input.GetKeyDown(RightButtonAction)) {
			if (activeButton != "P") {
				GameScoreManager.LifeLoss(1);
			}
			//Correct button press; change everything to the right button
			else {
				GameScoreManager.Score(1);
				leftButton.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1f);
				rightButton.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
				activeButton = "O";
			}
		}
    }
}
