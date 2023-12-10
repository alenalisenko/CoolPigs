using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform target; // Ссылка на Transform игрока
    public float smoothSpeed = 0.125f; // Параметр для плавного следования

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + new Vector3(0, 0, -10); // Установка желаемой позиции камеры
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Плавное следование

            transform.position = smoothedPosition; // Установка новой позиции камеры
        }
    }
}