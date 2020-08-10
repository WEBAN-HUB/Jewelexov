using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.UI;

public class CUIGemInfo : MonoBehaviour
{
 

    // Start is called before the first frame update
    void Start()
    {
        string tJsonGemInfoList = LoadResourcesTextfile("GemData");

        GemInfoList tInfoList = JsonUtility.FromJson<GemInfoList>(tJsonGemInfoList);

        CSgtGameData.GetInstance().SetGemInfoList(tInfoList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string LoadResourcesTextfile(string tFileName)
    {
        TextAsset tTextAsset = null;
        tTextAsset = Resources.Load<TextAsset>(tFileName);

        if(null == tTextAsset)
        {
            return "";
        }

        return tTextAsset.text;
    }
}
