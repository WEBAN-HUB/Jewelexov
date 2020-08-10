using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class UIPlaying : MonoBehaviour
{
    public GameObject outPauseUI = null;
    public GameObject inPauseUI = null;
    public GameObject DeadUI = null;
    CPlayer mpPlayer = null;
    CCamera mCamera = null;
    Trap_Spike_Move_Y mMoveTrap = null;
    bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        mpPlayer = FindObjectOfType<CPlayer>();
        mCamera = FindObjectOfType<CCamera>();
        mMoveTrap = FindObjectOfType<Trap_Spike_Move_Y>();

        switch (SceneManager.GetActiveScene().name)
        {
            case "SceneTutorial":
                {
                    
                }
                break;
            case "SceneWorld_1":
                {
                    
                }
                break;
            case "SceneWorld_2":
                {

                }
                break;
        }

        CSgtGameData.GetInstance().DashGemLV = CSgtGameData.GetInstance().InStart_DashGemLV;
        CSgtGameData.GetInstance().JumpGemLV = CSgtGameData.GetInstance().InStart_JumpGemLV;
        CSgtGameData.GetInstance().SetDashScalar(CSgtGameData.GetInstance().DashGemLV);
        CSgtGameData.GetInstance().SetJumpCount();
        mpPlayer.SetDashScalar();
        mpPlayer.SetJumpCount();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && mpPlayer.Life == true && (mCamera.mCAMSTATUS != CCamera.CAMSTATUS.DIE_MAZE))
        {
            OnClickBtnPause();
        }
        
        if(mpPlayer.Life == false)
        {
            outPauseUI.SetActive(false);
            DeadUI.SetActive(true);
        }

        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void OnClickBtnPause()
    {
        if (isPause == false)
        {
            isPause = true;

            outPauseUI.SetActive(false);
            inPauseUI.SetActive(true);
            Time.timeScale = 0.0f;
            mpPlayer.mSpeedScalar = 0.0f;
            mpPlayer.mDashScalar = 0.0f;
            mpPlayer.mJumpScalar = 0.0f;

            switch (SceneManager.GetActiveScene().name)
            {
                case "SceneTutorial":
                    {
                        
                    }
                    break;
                case "SceneWorld_1":
                    {
                        //mMoveTrap.Trap_Stop = true;
                    }
                    break;
                case "SceneWorld_2":
                    {
                        
                    }
                    break;
            }
        }
        else
        {
            isPause = false;

            outPauseUI.SetActive(true);
            inPauseUI.SetActive(false);
            Time.timeScale = 1.0f;
            mpPlayer.mSpeedScalar = 3.0f;
            mpPlayer.mDashScalar = CSgtGameData.GetInstance().DashScalar;
            mpPlayer.mJumpScalar = 8.0f;

            switch (SceneManager.GetActiveScene().name)
            {
                case "SceneTutorial":
                    {

                    }
                    break;
                case "SceneWorld_1":
                    {
                        //mMoveTrap.Trap_Stop = false;
                    }
                    break;
                case "SceneWorld_2":
                    {

                    }
                    break;
            }
        }
    }

    public void OnClickBtnHome()
    {
        Time.timeScale = 1.0f;

        LoadingSceneManager.LoadScene("SceneTitle");
    }

    public void OnClickBtnRestart(int a)
    {
        Time.timeScale = 1.0f;

        LoadingSceneManager.LoadScene(SceneManager.GetActiveScene().name);

        CSgtGameData.GetInstance().DashGemLV = 0;
        CSgtGameData.GetInstance().JumpGemLV = 0;

        CSgtGameData.GetInstance().SetDashScalar(CSgtGameData.GetInstance().DashGemLV);
        CSgtGameData.GetInstance().SetJumpCount();

        CSgtGameData.GetInstance().FromStart = a;
    }

    public void OnClickBtnSettings()
    {
        
    }
}
