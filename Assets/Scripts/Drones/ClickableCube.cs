using UnityEngine;

public class ClickableCube : MonoBehaviour
{
    public UIManager uiManager; // ��������� � ���������� Unity

    void OnMouseDown()
    {
        Debug.Log("��� ��� �������!");
        uiManager.ShowUI();
    }
}
