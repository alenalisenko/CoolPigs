using UnityEngine;

public class Unexploredcell : MonoBehaviour
{
    public Animation _animation;
    private void OnTriggerEnter(Collider other)
    {
        _animation.Play();
        Destroy(gameObject, 0.5f);
    }

}
