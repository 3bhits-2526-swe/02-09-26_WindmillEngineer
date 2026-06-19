using UnityEngine;

public class Part : MonoBehaviour {

	int number;
	Vector2 startPos;
	void Start(){
		//init sprite
		startPos = this.transform.position;
		Debug.Log("part init"); 
	}
	// Use this for initialization
	// Update is called once per frame
	
	void Update(){
		Debug.Log("screen pos:   x: " + Input.mousePosition.x + "y: " + Input.mousePosition.y); 
	}

	void OnMouseOver(){
		Debug.Log("this part could be selected"); 
	}

    void OnMouseDrag()
    {
		Vector3 input = Input.mousePosition; 
		Vector3 offset = Camera.main.transform.position; 
		input.x += -860 + offset.x; 
		input.y += -540 + offset.y; 
    	Debug.Log("chosen pos[x: "+ input.x + "; y: " + input.y + "; z: " + input.z); 
	}

	void OnMouseExit(){
		this.transform.position = startPos;
	}
}