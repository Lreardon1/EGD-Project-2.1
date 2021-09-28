using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBehavior : MonoBehaviour
{
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
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<GlitchEffect>().intensity = 1;
            other.GetComponentInChildren<GlitchEffect>().flipIntensity = 1;
            other.GetComponentInChildren<GlitchEffect>().colorIntensity = 1;
            Debug.Log("Bruh");
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
