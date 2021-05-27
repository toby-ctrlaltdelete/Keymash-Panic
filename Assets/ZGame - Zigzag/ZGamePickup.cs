using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZGamePickup : MonoBehaviour
{
	private Rigidbody2D rb2d;
	
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2(0, -0.5f);
    }

    void NewPosition()
    {
        float rand = Random.Range(-0.3f,0.3f);
		transform.localPosition = new Vector2(rand, 0.3f);
    }
	
	void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "ZBottom")
        {
			Invoke("NewPosition", 0);
        }
    }
}
