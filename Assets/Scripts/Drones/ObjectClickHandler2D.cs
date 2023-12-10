using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClickHandler2D : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Обработка нажатия мыши на объект
        Debug.Log("Object Clicked: " + gameObject.name);
    }
}
