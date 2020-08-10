using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public CPlayer mpPlayer = null;
    Info_World_1 mpWorld1Info = null;
    Info_World_2 mpWorld2Info = null;
    Puzzle_01_HiddenMaze HMMgr = null;
    //bool[] SavePointActiveInfo = new bool[2];

    // Start is called before the first frame update
    void Start()
    {
        mpWorld1Info = FindObjectOfType<Info_World_1>();
        mpWorld2Info = FindObjectOfType<Info_World_2>();
        HMMgr = FindObjectOfType<Puzzle_01_HiddenMaze>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save_Playing(int WorldNum, Transform mSP)
    {
        PlayerPrefsX.SetVector3(WorldNum.ToString() + "_Player_Pos", mSP.position);
        PlayerPrefs.SetFloat(WorldNum.ToString() + "_Player_Rot_Y", mpPlayer.ViewDir.transform.eulerAngles.y);
        PlayerPrefs.SetInt(WorldNum.ToString() + "_CheckPoint", mpPlayer.TargetIndex);
        PlayerPrefs.SetInt("JumpGemLv", CSgtGameData.GetInstance().JumpGemLV);
        PlayerPrefs.SetInt("DashGemLv", CSgtGameData.GetInstance().DashGemLV);

        switch (WorldNum)
        {
            case 1:
                {
                    for (int i = 0; i < mpWorld1Info.GemList.Count; i++)
                    {
                        PlayerPrefsX.SetBool(WorldNum.ToString() + "_GemActive_" + i, mpWorld1Info.GemList[i].activeSelf);
                    }
                    for (int i = 0; i < mpWorld1Info.OnGemList.Count; i++)
                    {
                        PlayerPrefsX.SetBool(WorldNum.ToString() + "_OnGemActive_" + i, mpWorld1Info.OnGemList[i].activeSelf);
                    }
                    PlayerPrefs.SetInt(WorldNum.ToString() + "_ClearInfo_HM", HMMgr.HMStatusForSave);
                }
                break;
            case 2:
                {
                    //for (int i = 0; i < mpWorld2Info.GemList.Count; i++)
                    //{
                    //    PlayerPrefsX.SetBool(WorldNum.ToString() + "_GemActive_" + i, mpWorld2Info.GemList[i].activeSelf);
                    //}
                    //for (int i = 0; i < mpWorld2Info.OnGemList.Count; i++)
                    //{
                    //    PlayerPrefsX.SetBool(WorldNum.ToString() + "_OnGemActive_" + i, mpWorld2Info.OnGemList[i].activeSelf);
                    //}
                }
                break;
        }
    }
    public void Save_SPActive(int WorldNum)
    {
        switch (WorldNum)
        {
            case 1:
                {
                    for (int i = 0; i < mpWorld1Info.SavePointList.Count; i++)
                    {
                        PlayerPrefsX.SetBool(WorldNum.ToString() + "_SavePointActive_" + i, mpWorld1Info.SavePointList[i].activeSelf);
                    }
                }
                break;
            case 2:
                {

                }
                break;
        }
    }

    public void Load_Playing(int WorldNum)
    {
        if (true == PlayerPrefs.HasKey(WorldNum.ToString() + "_Player_Pos"))
        {
            Vector3 Player_Pos = PlayerPrefsX.GetVector3(WorldNum.ToString() + "_Player_Pos");
            float Player_Rot_Y = PlayerPrefs.GetFloat(WorldNum.ToString() + "_Player_Rot_Y");
            int CheckPoint = PlayerPrefs.GetInt(WorldNum.ToString() + "_CheckPoint");

            mpPlayer.transform.position = PlayerPrefsX.GetVector3(WorldNum.ToString() + "_Player_Pos");
            mpPlayer.ViewDir.transform.rotation = Quaternion.Euler(0, PlayerPrefs.GetFloat(WorldNum.ToString() + "_Player_Rot_Y"), 0);
            mpPlayer.TargetIndex = PlayerPrefs.GetInt(WorldNum.ToString() + "_CheckPoint");
            mpPlayer.CurrentIndex = PlayerPrefs.GetInt(WorldNum.ToString() + "_CheckPoint") - 1;

            switch (WorldNum)
            {
                case 1:
                    {
                        for (int i = 0; i < mpWorld1Info.GemList.Count; i++)
                        {
                            mpWorld1Info.GemList[i].SetActive(PlayerPrefsX.GetBool(WorldNum.ToString() + "_GemActive_" + i));
                        }
                        for (int i = 0; i < mpWorld1Info.OnGemList.Count; i++)
                        {
                            mpWorld1Info.OnGemList[i].SetActive(PlayerPrefsX.GetBool(WorldNum.ToString() + "_OnGemActive_" + i));
                        }
                        for (int i = 0; i < mpWorld1Info.SavePointList.Count; i++)
                        {
                            mpWorld1Info.SavePointList[i].SetActive(PlayerPrefsX.GetBool(WorldNum.ToString() + "_SavePointActive_" + i));
                        }
                        int ClearInfo_HM = PlayerPrefs.GetInt(WorldNum.ToString() + "_ClearInfo_HM");
                        HMMgr.HMStatusForSave = PlayerPrefs.GetInt(WorldNum.ToString() + "_ClearInfo_HM");
                    }
                    break;
                case 2:
                    {
                        //for (int i = 0; i < mpWorld2Info.GemList.Count; i++)
                        //{
                        //    mpWorld2Info.GemList[i].SetActive(PlayerPrefsX.GetBool(WorldNum.ToString() + "_GemActive_" + i));
                        //}
                        //for (int i = 0; i < mpWorld2Info.OnGemList.Count; i++)
                        //{
                        //    mpWorld2Info.OnGemList[i].SetActive(PlayerPrefsX.GetBool(WorldNum.ToString() + "_OnGemActive_" + i));
                        //}
                    }
                    break;
            }
        }
    }
    public void Load_Playing_FromStart(int WorldNum)
    {
        switch (WorldNum)
        {
            case 1:
                {
                    for (int i = 0; i < 2; i++)
                    {
                        mpWorld1Info.GemList[i].SetActive(PlayerPrefsX.GetBool(WorldNum.ToString() + "_GemActive_" + i));
                    }
                }
                break;
            case 2:
                {
                    //for (int i = 0; i < mpWorld2Info.GemList.Count; i++)
                    //{
                    //    mpWorld2Info.GemList[i].SetActive(PlayerPrefsX.GetBool(WorldNum.ToString() + "_GemActive_" + i));
                    //}
                    //for (int i = 0; i < mpWorld2Info.OnGemList.Count; i++)
                    //{
                    //    mpWorld2Info.OnGemList[i].SetActive(PlayerPrefsX.GetBool(WorldNum.ToString() + "_OnGemActive_" + i));
                    //}
                }
                break;
        }
    }
}
