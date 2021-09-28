using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBehavior : MonoBehaviour
{
    public AudioSource audioS;
    public string level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Camera cam = FindObjectOfType<Camera>();
        if (other.tag == "Player")
        {
            cam.GetComponent<GlitchEffect>().intensity = 1;
            cam.GetComponent<GlitchEffect>().flipIntensity = 1;
            cam.GetComponent<GlitchEffect>().colorIntensity = 1;
            Debug.Log("Bruh");
            audioS.Play();
            StartCoroutine(delay(3));
            
        }
        //Debug.Log(other.tag);
    }
    
    IEnumerator delay(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(level);
    }
}
