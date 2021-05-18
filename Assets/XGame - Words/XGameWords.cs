using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XGameWords : MonoBehaviour
{
	public List<XString> wordList;
	
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
		wordList = new List<XString>();
	}
}
