using UnityEngine; 

public class Windmill : MonoBehaviour {
	
	bool broken = false; 

	float windStrength = 0f; 
	GameObject gm; 


	// Use this for initialization
	void Start () {
		//pulling config
		MonoBehaviour gm = GameObject.Find("GameManager").GetComponent<Part>();
		

	}
	
	// Update is called once per frame
	void Update () {
        
	}


}