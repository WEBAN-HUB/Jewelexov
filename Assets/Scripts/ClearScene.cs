using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class ClearScene : MonoBehaviour
{
    public Light mLight = null;

    bool GB = true;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        CSoundsMgr.Getinstance().MusicAllStop();

        InvokeRepeating("LightOff", 0, 0.5f);
        InvokeRepeating("LightOn", 0.2f, 0.5f);
           
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LightOn()
    {
        if(count == 3)
        {
            if(GB == true)
            {
               GB = false;
            }
            else
            {
               GB = true;
            }

            count = 0;
        }


        if (GB == true)
        {
            mLight.intensity = 7;     
        }

        count++;
    }

    void LightOff()
    {
        if (GB == true)
        {
            mLight.intensity = 1;
        }
    }

    public void GotoTitle()
    {
        LoadingSceneManager.LoadScene("SceneTitle");
    }
}
