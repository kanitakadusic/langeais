using UnityEngine;

public class DaVinci : MonoBehaviour
{
    public GameObject textHolder;
    private Ray ray;
    private RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    textHolder.SetActive(!textHolder.activeSelf);
                }
            }
        }
    }
}