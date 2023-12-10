using UnityEngine;

public class DroneStats : MonoBehaviour
{
    public int maxCharge = 100;
    public int energy = 100;
    public GameObject Item;
    public bool isaction = false;
    private void Awake()
    {
        energy = maxCharge;
    }
}