using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    // Start is called before the first frame update
    void Start()
    {
        CameraReverse();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }

    public void CameraDefualt()
    {
        offset = new Vector3(0, 0, -10);
        transform.Rotate(new Vector3(0, 0, 0));
    }

    public void CameraUpsideDown()
    {
        transform.Rotate(new Vector3(0, 0, 180));
    }


    public void CameraOnSide(bool leftside)
    {
        if(leftside)
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }

        else
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }        
    }


    public void CameraReverse()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        offset = new Vector3(0, 0, 10);
    }


}
