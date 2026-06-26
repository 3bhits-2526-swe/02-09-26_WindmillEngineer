using UnityEngine;

public class city : MonoBehaviour
{
    float tt = 1; 
    float count = 0; 
    float power = 100; 
    float demand = 30; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime; 
        if (count >= tt){
            count = 0; 
            power -= demand; 
        }
    }
}
