using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QPaddleControl : MonoBehaviour
{
	public KeyCode Action = KeyCode.Q;
	public double pos1 = 0.0;
	public double pos2 = 0.3;
	public double pos3 = -0.0;
	public double pos4 = -0.3;
	private int currentpos = 1;
	private Rigidbody2D rb2d;
    
	// Start is called before the first frame update
    void Start()
    {
		rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 localPos = transform.localPosition;
        if (Input.GetKeyDown(Action)) {
            switch (currentpos) {
			case 4:
				currentpos = 1;
				localPos.y = (float)pos1;
				break;
			case 3:
				currentpos = 4;
				localPos.y = (float)pos4;
				break;
			case 2:
				currentpos = 3;
				localPos.y = (float)pos3;
				break;
			case 1:
				currentpos = 2;
				localPos.y = (float)pos2;
				break;
			default:
				print("Q: A position number outside of 1 to 4 was used, maybe fix that?");
				currentpos = 1;
				localPos.y = (float)pos1;
				break;
			}
		}
		transform.localPosition = localPos;
    }
}