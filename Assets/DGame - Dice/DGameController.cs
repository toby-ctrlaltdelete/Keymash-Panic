using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGameController : MonoBehaviour
{
	public KeyCode Action = KeyCode.D;
	public GameObject Dice1;
	public GameObject Dice2;
	public GameObject Dice3;
	public GameObject Dice4;
	public GameObject Dice5;
	public GameObject Dice6;
	
	private SpriteRenderer spriteR;
	private float switchTimer;
	private int currentDiceNumber;
	private int pickedDiceNumber;
	
    // Start is called before the first frame update
    void Start()
    {
		spriteR = gameObject.GetComponent<SpriteRenderer>();
		currentDiceNumber = 1;
		Invoke("NewDiceValue", 0);
    }
	
	void NewDiceValue()
	{
		int rand = Random.Range(0,7);
		spriteR.sprite = Resources.Load<Sprite>("Dice/Dice" + (rand) + "Pip");
		pickedDiceNumber = rand;
	}

    // Update is called once per frame
    void Update()
    {
        switchTimer += (0.5f*Time.deltaTime);
		if (switchTimer >= 1.0f) {
            switch (currentDiceNumber) {
			case 6:
				currentDiceNumber = 1;
				Dice6.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 0.75f);
				Dice1.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 1.0f);
				break;
			case 5:
				currentDiceNumber = 6;
				Dice5.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 0.75f);
				Dice6.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 1.0f);
				break;
			case 4:
				currentDiceNumber = 5;
				Dice4.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 0.75f);
				Dice5.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 1.0f);
				break;
			case 3:
				currentDiceNumber = 4;
				Dice3.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 0.75f);
				Dice4.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 1.0f);
				break;
			case 2:
				currentDiceNumber = 3;
				Dice2.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 0.75f);
				Dice3.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 1.0f);
				break;
			case 1:
				currentDiceNumber = 2;
				Dice1.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 0.75f);
				Dice2.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 1.0f);
				break;
			default:
				print("Q: A number outside of 1 to 6 was used, maybe fix that?");
				currentDiceNumber = 1;
				break;
			}
			switchTimer = 0.0f;
		}
		
		if (Input.GetKeyDown(Action)) {
			if (currentDiceNumber == pickedDiceNumber) {
				GameScoreManager.Score(1);
				Invoke("NewDiceValue", 0);
			}
			else {
				GameScoreManager.LifeLoss(1);
				
			}
		}
	}
}