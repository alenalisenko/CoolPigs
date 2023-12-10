using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // ��������� ����� �� ����������
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // ���������� ������� ��������
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;

        // ����������� ������
        MovePlayer(movement);
    }

    void MovePlayer(Vector3 movement)
    {
        // ������������� �������� �������� ������� Rigidbody2D
        Vector2 moveVelocity = new Vector2(movement.x, movement.y) * moveSpeed;
        rb.velocity = moveVelocity;
    }
}
