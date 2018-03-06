using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    
    [Header("Value of mouse translate")]
    public float horizontalSpeed = 10f;
    public float verticalSpeed = 10f;
    public float forwardSpeed = 10;

    [Header("Value of keyboard")]
    public float yAxisRotation = 10f;
    public float xAxisRotation = 10f;

    [Header("Focus Game Object")]
    public GameObject _cameraFocusPoint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        onClickLeftMouseEvent();
        onClickScrollButtonEvent();
        onClickKeyboardEvent();
        //checkCameraRotation();
	}
    /*
    private void checkCameraRotation()
    {
        Debug.Log(transform.rotation.eulerAngles.y);

        if (transform.rotation.eulerAngles.x > 90f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
        }else if (transform.rotation.eulerAngles.x < -90f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(-90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
        }

        if (transform.rotation.eulerAngles.y > 90f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 90f, transform.rotation.eulerAngles.z));
        }else if (transform.rotation.eulerAngles.y < -90f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, -90f, transform.rotation.eulerAngles.z));
        }

        if (transform.rotation.eulerAngles.z > 90f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 90f));
        }else if (transform.rotation.eulerAngles.z < -90f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -90f));
        }
    }*/

    private void onClickLeftMouseEvent()
    {
        if (!Input.GetMouseButton(0))
            return;

        float v = Input.GetAxis("Mouse X") * verticalSpeed * Time.fixedDeltaTime;
        float h = Input.GetAxis("Mouse Y") * horizontalSpeed * Time.fixedDeltaTime;
        transform.Translate(v, h, 0);

        _cameraFocusPoint.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2f;
    }

    private void onClickScrollButtonEvent()
    {
        float z = Input.GetAxis("Mouse ScrollWheel") * forwardSpeed * Time.fixedDeltaTime;
        transform.Translate(transform.forward * z);

        _cameraFocusPoint.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2f;
    }

    private void onClickKeyboardEvent()
    {
        float y = Input.GetAxis("Vertical") * yAxisRotation * Time.fixedDeltaTime;
        float x = Input.GetAxis("Horizontal") * xAxisRotation * Time.fixedDeltaTime;        

        transform.RotateAround(_cameraFocusPoint.transform.position, Vector3.up, x);
        transform.RotateAround(_cameraFocusPoint.transform.position, Vector3.right, y);
    }
}
