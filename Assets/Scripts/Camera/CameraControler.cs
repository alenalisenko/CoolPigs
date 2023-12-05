using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private Transform _transform;

    public GameObject[] drons;
    public int dronselected = 0;
    public int multiplier = 2;
    private void Awake()
    {
        _transform = transform;
    }
    private void Update()
    {
        float distance = Vector3.Distance(_transform.position, drons[dronselected].transform.position);
        if (distance > 1 && distance != 0)
        {
            float axisy = -(_transform.position.y - drons[dronselected].transform.position.y) * multiplier;
            float axisx = -(_transform.position.x - drons[dronselected].transform.position.x) * multiplier;
            _transform.position += axisy * _transform.TransformDirection(Vector3.up) * Time.deltaTime + axisx * _transform.TransformDirection(Vector3.right) * Time.deltaTime;
        }
    }
}