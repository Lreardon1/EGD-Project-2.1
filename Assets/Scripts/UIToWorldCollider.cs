using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToWorldCollider : MonoBehaviour
{
    public GameObject colliderGO;
    public RectTransform rTransform;

    private Camera mainCam;
    private BoxCollider2D colliderWorld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        mainCam = FindObjectOfType<Camera>();
        colliderWorld = colliderGO.GetComponent<BoxCollider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 colliderPos = mainCam.ScreenToWorldPoint(rTransform.position);
        Vector3 buttonPosWOffset = rTransform.position;
        Vector3 buttonPosHOffset = rTransform.position;
        buttonPosWOffset.x += rTransform.sizeDelta.x;
        buttonPosHOffset.x += rTransform.sizeDelta.y;

        float colliderWidth = (Vector2.Distance(colliderPos, mainCam.ScreenToWorldPoint(buttonPosWOffset)));
        float colliderHeight = (Vector2.Distance(colliderPos, mainCam.ScreenToWorldPoint(buttonPosHOffset)));

        colliderWorld.transform.position = colliderPos;
        colliderWorld.size = new Vector2(colliderWidth, colliderHeight);
    }
}
