using UnityEngine;

[CreateAssetMenu(fileName = "Power", menuName = "Scriptable Objects/Power")]
public class Power : ScriptableObject
{
    public float generatedPower;
    public float usedPower;
    public float remainingPower;

    public void calculatePower()
    {
        remainingPower = generatedPower- usedPower;
    }

}
