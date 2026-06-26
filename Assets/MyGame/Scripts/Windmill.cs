using UnityEngine; 

public class Windmill : MonoBehaviour {
	
	bool broken = false; 
	public int brokenL = 0; 
	float windStrength = 0f; 
	GameObject gm; 


	// Use this for initialization
	void Start () {
		//pulling config
		//MonoBehaviour gm = GameObject.Find("GameManager").GetComponent<Part>();
		

	}
	
	// Update is called once per frame
	void Update () {
		InvokeRepeating("tryBreaking",0,0.5f);
	}

	public void repair(){
        
        if (brokenL == 0){
			broken = false;
        	return;
		}
            
        brokenL--;
    }

    void tryBreaking()
    {
		Debug.Log("trying to break"); 
        if (Random.Range(0, 250) == 19)
        {
			breaking();
        }
    }

    void breaking(){
		if(brokenL<3)
        	brokenL += 1;
        broken = true;
    }

    void updateModel()
    {
		//gm.getModel(brokenL);
    }

}