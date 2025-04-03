using UnityEngine;
using UnityEngine.Video;

public class GnomeWelcome : MonoBehaviour
{
    public GameObject videoHolder;
    private VideoPlayer videoPlayer;
    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        videoPlayer = videoHolder.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if (videoHolder.activeSelf)
                    {
                        videoPlayer.Stop();
                        videoHolder.SetActive(false);
                    }
                    else
                    {
                        videoHolder.SetActive(true);
                        videoPlayer.Play();
                    }
                }
            }
        }
    }
}