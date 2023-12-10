using Unity.VisualScripting;
using UnityEngine;

public class deathsensor : MonoBehaviour
{
    public GameObject explore;
    public void Death()
    {
        Instantiate(explore, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Death();
    }
}
