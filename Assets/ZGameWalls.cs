using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZGameWalls : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "ZPlayer")
        {
            GameScoreManager.LifeLoss(1);
            hitInfo.gameObject.SendMessage("ResetBallZ", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
