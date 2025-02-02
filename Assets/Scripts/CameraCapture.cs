﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
 
public class CameraCapture : MonoBehaviour
{
    //public int fileCounter;
    public KeyCode screenshotKey;
    public Camera Camera;
    public DNAManager dnaManagerReference;
    public ImportJSON JsonExportReference;
   
 
    private void LateUpdate()
    {
        if (Input.GetKeyDown(screenshotKey))
        {
            Capture();
        }
    }
 
    public void Capture()
    {
        RenderTexture activeRenderTexture = RenderTexture.active;
        RenderTexture.active = Camera.targetTexture;
 
        Camera.Render();
 
        Texture2D image = new Texture2D(Camera.targetTexture.width, Camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, Camera.targetTexture.width, Camera.targetTexture.height), 0, 0);
        image.Apply();
        RenderTexture.active = activeRenderTexture;
 
        byte[] bytes = image.EncodeToJPG();
        Destroy(image);
 
        File.WriteAllBytes(Application.dataPath + "/StreamingAssets/Images/boomboxhead" + dnaManagerReference.genID + ".jpg", bytes);
        //fileCounter++;
    }

    public void CapturePNG()
    {
        RenderTexture activeRenderTexture = RenderTexture.active;
        RenderTexture.active = Camera.targetTexture;
 
        Camera.Render();
 
        Texture2D image = new Texture2D(Camera.targetTexture.width, Camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, Camera.targetTexture.width, Camera.targetTexture.height), 0, 0);
        image.Apply();
        RenderTexture.active = activeRenderTexture;
 
        byte[] bytes = image.EncodeToPNG();
        Destroy(image);
 
        File.WriteAllBytes(Application.dataPath + "/StreamingAssets/Images/boomboxhead" + dnaManagerReference.genID + ".png", bytes);
        //fileCounter++;
    }

    public void ExportCapture()
    {
        RenderTexture activeRenderTexture = RenderTexture.active;
        RenderTexture.active = Camera.targetTexture;
 
        Camera.Render();
 
        Texture2D image = new Texture2D(Camera.targetTexture.width, Camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, Camera.targetTexture.width, Camera.targetTexture.height), 0, 0);
        image.Apply();
        RenderTexture.active = activeRenderTexture;
 
        byte[] bytes = image.EncodeToJPG();
        Destroy(image);
 
        File.WriteAllBytes(Application.dataPath + "/StreamingAssets/Images/" + JsonExportReference.currentOutoutEdition + ".jpg", bytes);

        
        //fileCounter++;
    }

    
}