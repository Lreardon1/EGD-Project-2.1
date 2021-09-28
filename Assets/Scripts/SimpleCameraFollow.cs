using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public enum CameraSetting {Normal, Reversed, UpsideDown, OnSide};
    public CameraSetting cameraSetting = CameraSetting.Normal;
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float cameraMaxY = 5f;
    public float cameraMinY = -5f;

    // Start is called before the first frame update
    void Start()
    {
        if (cameraSetting == CameraSetting.Reversed)
            CameraReverse();
        else if (cameraSetting == CameraSetting.UpsideDown)
            CameraUpsideDown();
        else if (cameraSetting == CameraSetting.OnSide)
            CameraOnSide(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position + offset;
        targetPos.y = Mathf.Clamp(targetPos.y, cameraMinY, cameraMaxY);
        transform.position = targetPos;
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
