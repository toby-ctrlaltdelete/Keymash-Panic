using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameController : MonoBehaviour
{
	public KeyCode Action = KeyCode.C;
	public GameObject Tooth1;
	public GameObject Tooth2;
	public GameObject Tooth3;
	public GameObject ToothBase;
	private int selectedTooth;
	
	private float pos1 = -0.33f;
	private float pos2 = 0.0f;
	private float pos3 = 0.33f;
	private int currentPos = 2;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	void SelectTooth()
	{
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Action)) {
			Vector2 localPos = transform.localPosition;
			switch (currentPos) {
			case 3:
				currentPos = 1;
				localPos.x = pos1;
				break;
			case 2:
				currentPos = 3;
				localPos.x = pos3;
				break;
			case 1:
				currentPos = 2;
				localPos.x = pos2;
				break;
			default:
				print("C: A position number outside of 1 to 3 was used, maybe fix that?");
				currentPos = 1;
				localPos.y = (float)pos1;
				break;
			}
			transform.localPosition = localPos;
		}
    }
}
