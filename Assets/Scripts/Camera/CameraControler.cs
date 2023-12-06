using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private Transform _transform;

    public GameObject[] drons;
    public int dronselected = 0;
    public int speedmultiplier = 2;
    private void Awake()
    {
        _transform = transform;
    }
    private void Update()
    {
        float distance = Vector3.Distance(_transform.position, drons[dronselected].transform.position);
        if (distance != 0)
        {
            Vector3 direction = Vector3.Normalize(drons[dronselected].transform.position - _transform.position);
            _transform.position += direction * speedmultiplier * Time.deltaTime;
        }
    }
}