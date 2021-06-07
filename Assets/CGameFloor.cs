using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameFloor : MonoBehaviour
{
	public GameObject CPlayer;
	
	//Check if any tooth hit the floor
	void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name != "CGamePlayer")
        {
			GameScoreManager.Score(1);
			CPlayer.gameObject.SendMessage("SelectTooth", 0.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
