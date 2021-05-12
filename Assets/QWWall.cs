using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QWWall : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "Circle")
        {
            GameScoreManager.LifeLoss(1);
            hitInfo.gameObject.SendMessage("ResetBall", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
