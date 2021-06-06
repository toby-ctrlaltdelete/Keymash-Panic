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
        Invoke("SelectTooth", 4);
    }
	
	void SelectTooth()
	{
		int rand = Random.Range(1,4);
		print(rand);
		selectedTooth = rand;
		ToothBase.transform.localPosition = new Vector2(0, 0.375f);
		ToothBase.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -0.25f);
		Tooth1.transform.localPosition = new Vector2(-0.333f, 0.125f);
		Tooth1.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -0.25f);
		Tooth2.transform.localPosition = new Vector2(0.0f, 0.125f);
		Tooth2.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -0.25f);
		Tooth3.transform.localPosition = new Vector2(0.333f, 0.125f);
		Tooth3.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -0.25f);
		switch (selectedTooth) {
			case 3:
				Tooth3.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				break;
			case 2:
				Tooth2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				break;
			case 1:
				Tooth1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				break;
			default:
				Tooth3.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				print("C: Selected tooth outside of 1 to 3 was used, maybe fix that?");
				break;
		}
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
