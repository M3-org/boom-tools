﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ToTextFile : MonoBehaviour
{

    public DNAManager dnaIDReference;
    public Button buttonReference;
    public ImportJSON JsonExportReference;
    //private int batchNumber;
    

    void Start(){
            //batchNumber = 1;
            // create a folder
            Directory.CreateDirectory(Application.streamingAssetsPath + "/JSON_Output/");
        
            // Reference to Button
            Button btn = buttonReference.GetComponent<Button>();
		    btn.onClick.AddListener(TaskOnClick);
    }

    public void CreateTextFile(){

        // name it
        string txtDocumentName = Application.streamingAssetsPath + "/JSON_Output/" + dnaIDReference.genID + ".json";
        // string txtDocumentName = Application.streamingAssetsPath + "/JSON_Output/JSON_Output" + dnaIDReference.genID + ".json"; had to change to text

        // check to see if exists
        if (!File.Exists(txtDocumentName))
        {
            // Write to File
            File.WriteAllText(txtDocumentName, dnaIDReference.jsonOutputPreview);
        }
    }

    public void CreateBatchImportTextFile(){

        // name it
        string txtDocumentName = Application.streamingAssetsPath + "/JSON_Output/" + JsonExportReference.currentOutoutEdition + ".json";
        // string txtDocumentName = Application.streamingAssetsPath + "/JSON_Output/JSON_Output" + dnaIDReference.genID + ".json"; had to change to text

        // check to see if exists
        if (!File.Exists(txtDocumentName))
        {
            // Write to File
            File.WriteAllText(txtDocumentName, dnaIDReference.jsonOutputPreview);
        }
    }

    void TaskOnClick(){
		Debug.Log ("You have created a json file"); 
       
        if(dnaIDReference.jsonOutputPreview == ""){
            return;
        }
       
        // create and print the text file
        CreateTextFile();
                  
	}
}
