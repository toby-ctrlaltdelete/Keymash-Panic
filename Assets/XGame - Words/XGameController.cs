using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XGameController : MonoBehaviour
{
	public KeyCode Action = KeyCode.X;
	public GameObject letter1;
	public GameObject letter2;
	public GameObject letter3;
	public GameObject letter4;
	public GameObject letter5;
	public GameObject letterChoiceA;
	public GameObject letterChoiceB;
	public GameObject arrow;
	public Slider slider;
	
	private float timer;
	private bool leftLetterChoiceCorrect;
	private bool currentChoiceLeft;

	public List<XString> wordList;
	private XString currentWord;
	private Sprite newLetterSprite;
	
	// Setting up the list because storing it in another script was a smart idea, but doesn't seem to work so easily
	[System.Serializable]
	public class XString{
		public string word;
		public int removedLetter;
		public string correctLetter;
		public string incorrectLetter;
 
    public XString(string word, int removedLetter, string correctLetter, string incorrectLetter){
			this.word = word;
			this.removedLetter = removedLetter;
			this.correctLetter = correctLetter;
			this.incorrectLetter = incorrectLetter;
		}
	}
	
	void initialize()
	{
		timer = 1.0f;
		currentChoiceLeft = true;
		wordList = new List<XString>();
	}
	
    // Start is called before the first frame update
    void Start()
    {
        ChangeWord();
    }
	
	// Change the currently displayed word
	void ChangeWord()
	{
		currentWord = wordList[Random.Range(0, wordList.Count)];
		
		//Reset the letters so that something doesn't break; again, probably a better way to make this with a loop
		letter1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Letters/Unknown");
		letter2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Letters/Unknown");
		letter3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Letters/Unknown");
		letter4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Letters/Unknown");
		letter5.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Letters/Unknown");
		
		//Changes all the letters excluding the missing one to appear;
		// there's 100% a better way to do this with loops than this abomination of code, though
		newLetterSprite = Resources.Load<Sprite>("Letters/" + (currentWord.word.Substring(0, 1)).ToUpper());
		if (currentWord.removedLetter != 1) {
			letter1.GetComponent<SpriteRenderer>().sprite = newLetterSprite;
		}
		// letter 2
		newLetterSprite = Resources.Load<Sprite>("Letters/" + (currentWord.word.Substring(1, 1)).ToUpper());
		if (currentWord.removedLetter != 2) {
			letter2.GetComponent<SpriteRenderer>().sprite = newLetterSprite;
		}
		// letter 3
		newLetterSprite = Resources.Load<Sprite>("Letters/" + (currentWord.word.Substring(2, 1)).ToUpper());
		if (currentWord.removedLetter != 3) {
			letter3.GetComponent<SpriteRenderer>().sprite = newLetterSprite;
		}
		// letter 4
		newLetterSprite = Resources.Load<Sprite>("Letters/" + (currentWord.word.Substring(3, 1)).ToUpper());
		if (currentWord.removedLetter != 4) {
			letter4.GetComponent<SpriteRenderer>().sprite = newLetterSprite;
		}
		// letter 5
		newLetterSprite = Resources.Load<Sprite>("Letters/" + (currentWord.word.Substring(4, 1)).ToUpper());
		if (currentWord.removedLetter != 5) {
			letter5.GetComponent<SpriteRenderer>().sprite = newLetterSprite;
		}
		
		//Randomly pick which of the two letter options is the correct and incorrect one,
		//then change them accordingly
		float rand = Random.Range(0, 2);
		if(rand < 1){
			leftLetterChoiceCorrect = true;
			newLetterSprite = Resources.Load<Sprite>("Letters/" + (currentWord.correctLetter.Substring(0, 1)).ToUpper());
			letterChoiceA.GetComponent<SpriteRenderer>().sprite = newLetterSprite;

			newLetterSprite = Resources.Load<Sprite>("Letters/" + (currentWord.incorrectLetter.Substring(0, 1)).ToUpper());
			letterChoiceB.GetComponent<SpriteRenderer>().sprite = newLetterSprite;
		} else {
			leftLetterChoiceCorrect = false;
			newLetterSprite = Resources.Load<Sprite>("Letters/" + (currentWord.incorrectLetter.Substring(0, 1)).ToUpper());
			letterChoiceA.GetComponent<SpriteRenderer>().sprite = newLetterSprite;

			newLetterSprite = Resources.Load<Sprite>("Letters/" + (currentWord.correctLetter.Substring(0, 1)).ToUpper());
			letterChoiceB.GetComponent<SpriteRenderer>().sprite = newLetterSprite;
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Action)) {
			if (currentChoiceLeft == true)
			{
				currentChoiceLeft = false;
				arrow.transform.Rotate(0, 0, 180);
			}
			else 
			{
				currentChoiceLeft = true;
				arrow.transform.Rotate(0, 0, 180);
			}
		}
		timer -= (0.25f*Time.deltaTime);
		slider.value = timer;
		if (timer <= 0.0f) {
			//For some reason, the code is using the inverse, so please ignore the spaghetti here
			if ((currentChoiceLeft == true && leftLetterChoiceCorrect == true) || (currentChoiceLeft == false && leftLetterChoiceCorrect == false))
			{
				GameScoreManager.LifeLoss(1);
			}
			else
			{
				GameScoreManager.Score(1);
			}
			ChangeWord();
			timer = 1.0f;
		}
    }
}
