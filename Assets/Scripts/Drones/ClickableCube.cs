using UnityEngine;

public class ClickableCube : MonoBehaviour
{
    public UIManager uiManager; // Присвойте в инспекторе Unity

    void OnMouseDown()
    {
        Debug.Log("Куб был кликнут!");
        uiManager.ShowUI();
    }
}
