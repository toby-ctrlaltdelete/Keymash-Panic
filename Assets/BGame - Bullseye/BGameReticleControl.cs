using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGameReticleControl : MonoBehaviour
{
	private Rigidbody2D rb2d;
	
    // Start is called before the first frame update
    void Start()
    {
		rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(-1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x >= 0.45f) {
			rb2d.velocity = new Vector2(-1, 0);
		}
        else if (transform.localPosition.x <= -0.45f) {
			rb2d.velocity = new Vector2(1, 0);
		}
    }
}
