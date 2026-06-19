using UnityEngine;

public class Part : MonoBehaviour {

	Sprite2D sprite;
	int number;
	Vector2D startPos;
	void Start(){
		//init sprite
	}
	// Use this for initialization
	// Update is called once per frame
	void Update () {
        startPos = this.transform.position;
	}


    void OnMouseDrag()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    	Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
		this.transform.position = worldPosition;
	}

	void OnMouseExit(){
		this.transform.position = startPos;
	}
}