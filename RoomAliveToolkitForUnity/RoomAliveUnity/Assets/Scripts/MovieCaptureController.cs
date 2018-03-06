using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieCaptureController : MonoBehaviour {

    public GameObject[] m_objList;
    public AVProMovieCaptureBase _capture;

    // Use this for initialization
    void Start () {     
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            setObjListState(true);
            recordVideoState(false);
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            onClickedRecButton();
        }
    }

    public void onClickedRecButton()
    {
        setObjListState(false);
        recordVideoState(true);
    }

    private void recordVideoState(bool flag)
    {
        if (flag)
        {
            Debug.Log("start record video");
            if (_capture != null && !_capture.IsCapturing())
            {
                _capture.StartCapture();
            }
        }
        else
        {
            Debug.Log("stop record video");
            if (_capture != null && _capture.IsCapturing())
            {
                _capture.StopCapture();
            }
        }
    }

    private void setObjListState(bool flag)
    {
        foreach (GameObject obj in m_objList)
        {
            obj.SetActive(flag);
        }
    }
}