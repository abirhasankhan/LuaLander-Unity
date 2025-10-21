using UnityEngine;

public class LandingPad : MonoBehaviour
{

    [SerializeField] private int scoreDotVectorMultiplier;

    public int GetScoreMultiplier()
    {
        return scoreDotVectorMultiplier;
    }

}
