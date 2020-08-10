using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITitle : MonoBehaviour
{
    public GameObject mWorldSelectGrid = null;
    public GameObject SettingUI = null;
    public Button BtnSelectWorld = null;
    public Button BtnContinue = null;
    public Text TxtContinue = null;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

        //PlayerPref 검사 후
        //없으면 '새 게임'을 활성화
        //있으면 '이어서 하기'를 활성화
        if (false == PlayerPrefs.HasKey("LastPlayedWorld"))
        {
            BtnSelectWorld.interactable = false;
            BtnContinue.interactable = false;
        }
        else if (PlayerPrefs.GetInt("LastPlayedWorld") == -1)
        {
            BtnSelectWorld.interactable = true;
            BtnContinue.interactable = false;
        }
        else
        {
            BtnSelectWorld.interactable = true;
            BtnContinue.interactable = true;
            TxtContinue.text = "이어서 하기 (World " + PlayerPrefs.GetInt("LastPlayedWorld") + ")";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        CSoundsMgr.Getinstance().MusicAllStop();


        if (false == PlayerPrefs.HasKey("LastPlayedWorld"))
        {
            //PlayerPrefs.SetInt("LastPlayedWorld", 0);
            //SceneManager.LoadScene("SceneTutorial");
            LoadingSceneManager.LoadScene("SceneTutorial");
        }
        else
        {
            //"게임을 새로 시작하면 기존 데이터는 삭제됩니다." 알림
            //SceneManager.LoadScene("SceneTutorial");
            PlayerPrefs.DeleteAll();
            //PlayerPrefs.SetInt("LastPlayedWorld", 0);
            LoadingSceneManager.LoadScene("SceneTutorial");
        }

        CSgtGameData.GetInstance().DashGemLV = 0;
        CSgtGameData.GetInstance().JumpGemLV = 0;

        CSgtGameData.GetInstance().SetDashScalar(CSgtGameData.GetInstance().DashGemLV);
        CSgtGameData.GetInstance().SetJumpCount();
    }
    public void OnClickSelectWorld()
    {
        this.gameObject.SetActive(false);
        //Fade Out
        mWorldSelectGrid.SetActive(true);
    }
    public void OnClickContinue()
    {
        CSoundsMgr.Getinstance().MusicAllStop();

        LoadingSceneManager.LoadScene("SceneWorld_" + PlayerPrefs.GetInt("LastPlayedWorld"));
    }
    public void OnClickSettings()
    {
        this.gameObject.SetActive(false);
        SettingUI.SetActive(true);
    }
    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); //어플리케이션 종료
#endif
    }
}
