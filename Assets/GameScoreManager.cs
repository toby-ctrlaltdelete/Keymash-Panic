using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreManager : MonoBehaviour
{
	public static int PlayerScore = 0;
	public static int PlayerLives = 4;

	public GUISkin layout;

	GameObject QWGame;

	// Call will add to the score as necessary
	public static void Score (int ScoreAmount) {
		PlayerScore += ScoreAmount; }
	
	public static void LifeLoss (int LossAmount) {
		PlayerLives -= LossAmount; }
	
	//Display the player's score and lives
	void OnGUI () {
    GUI.skin = layout;
	GUI.contentColor = Color.black;
    GUI.Label(new Rect(Screen.width / 2 + 410, 365, 200, 100), "" + PlayerScore);
	}
	
    // Start is called before the first frame update
    void Start()
    {
        QWGame = GameObject.Find("Q/WGameWindow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
