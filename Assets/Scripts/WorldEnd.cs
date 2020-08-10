using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class WorldEnd : MonoBehaviour
{
    CPlayer mpPlayer;

    // Start is called before the first frame update
    void Start()
    {
        mpPlayer = FindObjectOfType<CPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tagWayCheck"))
        {
            if(SceneManager.GetActiveScene().name == "SceneTutorial")
            {
                PlayerPrefs.SetInt("LastPlayedWorld", 1);
                PlayerPrefs.SetInt("JumpGemLv", CSgtGameData.GetInstance().JumpGemLV);
                PlayerPrefs.SetInt("DashGemLv", CSgtGameData.GetInstance().DashGemLV);
                LoadingSceneManager.LoadScene("SceneWorld_1");
            }
            if (SceneManager.GetActiveScene().name == "SceneWorld_1")
            {
                PlayerPrefs.SetInt("LastPlayedWorld", 2);
                PlayerPrefs.SetInt("JumpGemLv", CSgtGameData.GetInstance().JumpGemLV);
                PlayerPrefs.SetInt("DashGemLv", CSgtGameData.GetInstance().DashGemLV);
                LoadingSceneManager.LoadScene("SceneWorld_2");
            }
            if (SceneManager.GetActiveScene().name == "SceneWorld_2")
            {
                PlayerPrefs.SetInt("LastPlayedWorld", -1);
                PlayerPrefs.SetInt("JumpGemLv", CSgtGameData.GetInstance().JumpGemLV);
                PlayerPrefs.SetInt("DashGemLv", CSgtGameData.GetInstance().DashGemLV);
                SceneManager.LoadScene("SceneClear");
            }
        }
    }
}
