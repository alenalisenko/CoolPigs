using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClickHandler2D : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // ��������� ������� ���� �� ������
        Debug.Log("Object Clicked: " + gameObject.name);
    }
}
