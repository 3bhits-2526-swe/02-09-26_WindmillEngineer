using UnityEngine;

public class Part : MonoBehaviour {

	int number;
	Vector2 startPos;
	Ray ray;
	void Start(){
		//init sprite
		startPos = this.transform.position;
		Debug.Log("part init"); 
		
	}
	

	void Update(){
		
	}

	void OnMouseOver(){
		Debug.Log("this part could be selected"); 
	}

    void OnMouseDrag()
    {
		Vector3 input = Input.mousePosition; 
		Vector3 offset = Camera.main.transform.position; 
		offset.x += -860 + input.x; 
		offset.y += -540 + input.y; 
		offset.z = 1f;
		this.transform.SetPositionAndRotation(offset, this.transform.rotation);
    	Debug.Log("chosen pos[x: "+ offset.x + "; y: " + offset.y + "; z: " + offset.z); 
		Debug.Log("screen pos:   x: " + Input.mousePosition.x + "y: " + Input.mousePosition.y); 
		
		ray = new Ray(Camera.main.transform.position, this.transform.position - Camera.main.transform.position);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 9999))
        {
            // 3. Extract information if it hits something
            GameObject hitObject = hit.collider.gameObject;
            Windmill mb = hitObject.GetComponent<Windmill>();
			if(mb != null && mb.brokenL > 0){
				mb.repair();
			}

            Debug.Log($"Hit object: {hitObject.name}");
        }

        // 4. Debugging: Draw the ray in the Scene view so you can see it
        Debug.DrawRay(ray.origin, ray.direction * 9999, Color.red);
	}

	void OnMouseExit(){
		this.transform.position = startPos;
	}
}