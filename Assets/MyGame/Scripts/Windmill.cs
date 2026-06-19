using UnityEngine; 

public class Windmill : MonoBehaviour {
	
	bool broken = false; 
	public int brokenL = 0; 
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

	public void repair(){
		//change sprite to +1 level
	}

	void breaking(){
		//change sprite to -1 level if possible
	}

}