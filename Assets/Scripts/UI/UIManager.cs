using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject uiPanel;

    void Start()
    {
        uiPanel.SetActive(false);
    }

    public void ShowUI()
    {
        uiPanel.SetActive(true);
    }

    public void HideUI()
    {
        uiPanel.SetActive(false);
    }
}
