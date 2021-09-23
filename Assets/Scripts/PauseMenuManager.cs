using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    private bool paused = false;
    public GameObject collider1;
    public GameObject collider2;
    public GameObject pauseMenu;

    private SimpleCameraFollow camFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Camera mainCam = FindObjectOfType<Camera>();
        camFollow = mainCam.GetComponent<SimpleCameraFollow>();

        pauseMenu.SetActive(false);
        collider1.SetActive(false);
        collider2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused)
            {
                pauseMenu.SetActive(true);
                collider1.SetActive(true);
                collider2.SetActive(true);

                if (camFollow != null)
                    camFollow.enabled = false;
            } else
            {
                pauseMenu.SetActive(false);
                collider1.SetActive(false);
                collider2.SetActive(false);

                if (camFollow != null)
                    camFollow.enabled = true;
            }
            paused = !paused;
        }
    }
}
