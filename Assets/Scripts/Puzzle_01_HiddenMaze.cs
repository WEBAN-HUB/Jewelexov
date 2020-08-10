using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_01_HiddenMaze : MonoBehaviour
{
    public enum HMSTATUS
    {
        NORMAL = 0,
        PLAYING,
        ENDED
    }

    public HMSTATUS mHMSTATUS = HMSTATUS.NORMAL;
    public int HMStatusForSave = 0;

    public GameObject mpPlayer = null;

    public GameObject Wall = null;
    public GameObject HM0 = null;
    public GameObject HM1 = null;
    public GameObject HMPointer = null;
    public GameObject AfterRoute = null;
    public GameObject KeyTip = null;



    // Start is called before the first frame update
    void Start()
    {
        mHMSTATUS = (HMSTATUS)HMStatusForSave;
    }

    // Update is called once per frame
    void Update()
    {
        HMStatusForSave = (int)mHMSTATUS;
        switch (mHMSTATUS)
        {
            case (HMSTATUS)0: //HMSTATUS.NORMAL
                {
                    Wall.SetActive(true);
                    HM0.SetActive(false);
                    HM1.SetActive(true);
                    HMPointer.SetActive(true);
                    AfterRoute.SetActive(false);
                }
                break;
            case (HMSTATUS)1: //HMSTATUS.PLAYING
                {
                    Wall.SetActive(true);
                    HM0.SetActive(true);
                    HM1.SetActive(true);
                    HMPointer.SetActive(true);
                    AfterRoute.SetActive(false);
                }
                break;
            case (HMSTATUS)2: //HMSTATUS.ENDED
                {
                    Wall.SetActive(false);
                    HM0.SetActive(false);
                    HM1.SetActive(false);
                    HMPointer.SetActive(false);
                    AfterRoute.SetActive(true);

                    KeyTip.SetActive(false);
                }
                break;
        }
    }
}
