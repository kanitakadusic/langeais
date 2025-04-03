using UnityEngine;

public class Canvas : MonoBehaviour
{
    public void Info(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void Help(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}