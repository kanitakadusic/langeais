using UnityEngine;

public class WineBarrel : MonoBehaviour
{
    public AudioSource audioSource;
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
                    audioSource.Play();
                }
            }
        }
    }
}