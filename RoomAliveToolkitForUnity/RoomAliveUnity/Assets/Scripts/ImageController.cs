using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RoomAliveToolkit;

public enum IMAGE_STATE
{
    None = 0,
    RGB = 1,
    Infrared = 2
}

public enum MODEL_COlOR_STATE
{
    None = 0,
    RGB = 1,
    DEPTH = 2
}
public class ImageController : MonoBehaviour {

    public RATKinectClient kinectClient;
    public RATDepthMesh ratDepthMesh;

    public Text m_btnTxt;
    public Image colorImage;

    private IMAGE_STATE m_imageState = IMAGE_STATE.None;
    private MODEL_COlOR_STATE m_modelColorState = MODEL_COlOR_STATE.None;

    
	// Use this for initialization
	void Start () {
        kinectClient = GameObject.FindObjectOfType<RATKinectClient>();
        ratDepthMesh = GameObject.FindObjectOfType<RATDepthMesh>();

        changeRGBImage();
        onClickModelDepth();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickInverseButton()
    {
        if(m_imageState == IMAGE_STATE.Infrared)
        {
            changeRGBImage();
        }
        else
        {
            changeInferradImage();
        }
    }

    private void changeInferradImage()
    {
        Debug.Log("Inferrad Image state");
        m_imageState = IMAGE_STATE.Infrared;
        m_btnTxt.text = "RGB";
        ChangeImage(kinectClient.IRTexture);
        colorImage.transform.localScale = new Vector3(1, -1, 1);
    }

    private void changeRGBImage()
    {
        Debug.Log("RGB Image state");
        m_imageState = IMAGE_STATE.RGB;
        m_btnTxt.text = "Infrared";
        ChangeImage(kinectClient.RGBTexture);
        colorImage.transform.localScale = Vector3.one;
    }

    private void ChangeImage(Texture2D tex2d)
    {
        Texture2D sprites = tex2d;
        Rect rect = new Rect(0, 0, sprites.width, sprites.height);
        colorImage.sprite = Sprite.Create(tex2d, rect, new Vector2(0, 0), .01f);
    }

    public void onClickModelRGB()
    {
        if (m_modelColorState.Equals(MODEL_COlOR_STATE.RGB))
            return;

        m_modelColorState = MODEL_COlOR_STATE.RGB;
        ratDepthMesh.surfaceMaterial.shader = Shader.Find("RoomAlive/DepthMeshSurfaceShader");
    }

    public void onClickModelDepth()
    {
        if (m_modelColorState.Equals(MODEL_COlOR_STATE.DEPTH))
            return;

        m_modelColorState = MODEL_COlOR_STATE.DEPTH;
        ratDepthMesh.surfaceMaterial.shader = Shader.Find("RoomAlive/ProjectionMappingDepthMeshMinimal");
    }
}
