using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGameController : MonoBehaviour
{
	// Unity UI References
    public Slider slider;
	public KeyCode Action = KeyCode.M;
    
	// Create a property to handle the slider's value
	private float currentValue = 0f;
	
	// Start is called before the first frame update
    void Start()
    {
        currentValue = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Action)) {
			if (currentValue >= 0.9f) {
				GameScoreManager.Score(1);
				currentValue = 0.8f;
			}
			currentValue += 0.12f;
		}
		
		currentValue -= (0.2f*Time.deltaTime);
		slider.value = currentValue;
		
		if (currentValue <= 0.1f) {
			GameScoreManager.LifeLoss(1);
			currentValue = 0.6f;
		}
    }
}
