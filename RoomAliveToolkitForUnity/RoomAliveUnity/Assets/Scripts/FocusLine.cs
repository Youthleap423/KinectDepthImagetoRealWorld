using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusLine : MonoBehaviour {

    public bool m_bMouseDownState = false;
    public GameObject[] m_focusline;

	// Use this for initialization
	void Start () {

        m_focusline = new GameObject[transform.GetComponentsInChildren<Image>().Length];

        int i = 0;
        foreach (Image img in transform.GetComponentsInChildren<Image>())
        {
            m_focusline[i] = img.gameObject;
            m_focusline[i].SetActive(false);
            i++;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            drawFocusLine(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            drawFocusLine();
        }
	}

    //private void OnMouseDown()
    //{
    //    Debug.Log("on mouse down");
    //    drawFocusLine(true);
    //}

    //private void OnMouseUp()
    //{
    //    Debug.Log("on mouse up");
    //    drawFocusLine();
    //}

    private void drawFocusLine(bool flag = false)
    {
        Debug.Log("draw focus line" + flag);
        m_bMouseDownState = flag;
        foreach(GameObject obj in m_focusline)
        {
            obj.SetActive(flag);
        }
    }
}
