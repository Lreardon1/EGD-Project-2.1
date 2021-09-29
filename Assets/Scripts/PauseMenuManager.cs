using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    private bool paused = false;
    public GameObject collider1;
    public GameObject collider2;
    public GameObject pauseMenu;
    public bool workNormally = true;

    private GameObject player;
    private SimpleCameraFollow camFollow;
    private Vector3 playerPausePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player = FindObjectOfType<CharacterController_Geremy>().gameObject;
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
                if(!workNormally)
                {
                    collider1.SetActive(true);
                    collider2.SetActive(true);
                }

                playerPausePosition = player.transform.position;
                

                if (camFollow != null)
                    camFollow.enabled = false;
            } else
            {
                pauseMenu.SetActive(false);
                if (!workNormally)
                {
                    collider1.SetActive(false);
                    collider2.SetActive(false);
                } 

                if (camFollow != null)
                    camFollow.enabled = true;
            }
            paused = !paused;
        }

        if (workNormally && paused)
            player.transform.position = playerPausePosition;
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        if (!workNormally)
        {
            collider1.SetActive(false);
            collider2.SetActive(false);
        }

        if (camFollow != null)
            camFollow.enabled = true;
        paused = !paused;
    }
    
    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
