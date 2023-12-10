using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject destroyEffect;
    public void destroy()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
