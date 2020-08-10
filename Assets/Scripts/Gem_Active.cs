using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Gem_Active : MonoBehaviour
{
    Info_World_1 mpWorld1Info = null;
    Info_World_2 mpWorld2Info = null;
    PuzzleBlock_Move PZBlockMove = null;
    CCamera MainCamera = null;

    public GameObject Gem = null;
    public GameObject Wall = null;
    public GameObject KeyTip = null;

    public int ACType = 0;

    // Start is called before the first frame update
    void Start()
    {
        mpWorld1Info = FindObjectOfType<Info_World_1>();
        mpWorld2Info = FindObjectOfType<Info_World_2>();
        PZBlockMove = FindObjectOfType<PuzzleBlock_Move>();
        MainCamera = FindObjectOfType<CCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("tagWayCheck"))
        {
            KeyTip.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (true == CSgtGameData.GetInstance().Move_Gem && ACType == 0)
                {
                    CSgtGameData.GetInstance().Move_Gem = false;
                    Gem.SetActive(true);

                    switch (SceneManager.GetActiveScene().name)
                    {
                        case "SceneWorld_1":
                            {
                                
                            }
                            break;
                        case "SceneWorld_2":
                            {
                                if (this.gameObject == mpWorld2Info.GemCaseList[1])
                                {
                                    MainCamera.mCAMSTATUS = CCamera.CAMSTATUS.GEMEVENT_W2_2;
                                    PZBlockMove.ActiveGem = true;
                                }
                            }
                            break;
                    }
                }
                if (true == CSgtGameData.GetInstance().Create_Gem && ACType == 1)
                {
                    CSgtGameData.GetInstance().Create_Gem = false;
                    Gem.SetActive(true);
                    Wall.SetActive(true);

                    switch (SceneManager.GetActiveScene().name)
                    {
                        case "SceneWorld_1":
                            {
                                if (this.gameObject == mpWorld1Info.StoneList[1])
                                {
                                    MainCamera.mCAMSTATUS = CCamera.CAMSTATUS.GEMEVENT_W1_2;
                                }
                                else if (this.gameObject == mpWorld1Info.StoneList[2])
                                {
                                    MainCamera.mCAMSTATUS = CCamera.CAMSTATUS.GEMEVENT_W1_3;
                                }
                            }
                            break;
                        case "SceneWorld_2":
                            {
                                if (this.gameObject == mpWorld2Info.GemCaseList[2])
                                {
                                    MainCamera.mCAMSTATUS = CCamera.CAMSTATUS.GEMEVENT_W2_3;
                                }
                                else if (this.gameObject == mpWorld2Info.GemCaseList[3])
                                {
                                    MainCamera.mCAMSTATUS = CCamera.CAMSTATUS.GEMEVENT_W2_4;
                                }
                            }
                            break;
                    }
                    
                }
                if (true == CSgtGameData.GetInstance().Destroy_Gem && ACType == 2)
                {
                    CSgtGameData.GetInstance().Destroy_Gem = false;
                    Gem.SetActive(true);
                    Wall.SetActive(false);

                    switch (SceneManager.GetActiveScene().name)
                    {
                        case "SceneWorld_1":
                            {
                                if (this.gameObject == mpWorld1Info.StoneList[0])
                                {
                                    MainCamera.mCAMSTATUS = CCamera.CAMSTATUS.GEMEVENT_W1_1;
                                }
                            }
                            break;
                        case "SceneWorld_2":
                            {
                                if (this.gameObject == mpWorld2Info.GemCaseList[0])
                                {
                                    MainCamera.mCAMSTATUS = CCamera.CAMSTATUS.GEMEVENT_W2_1;
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("tagWayCheck"))
        {
            KeyTip.SetActive(false);
        }
    }
}
