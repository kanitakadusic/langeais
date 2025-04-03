using UnityEngine;

public class Option : MonoBehaviour
{
    public Material quizSelectedMaterial;
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
                    gameObject.GetComponent<Renderer>().material = quizSelectedMaterial;
                }
            }
        }
    }
}
