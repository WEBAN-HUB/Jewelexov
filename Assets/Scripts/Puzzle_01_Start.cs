using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_01_Start : MonoBehaviour
{
    CCamera mCamera = null;
    Puzzle_01_HiddenMaze HMMgr;

    public GameObject KeyTip1 = null;
    public GameObject KeyTip2 = null;

    int TriggerShield = 0;
    bool IsPreview = false;

    // Start is called before the first frame update
    void Start()
    {
        mCamera = FindObjectOfType<CCamera>();
        HMMgr = FindObjectOfType<Puzzle_01_HiddenMaze>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("tagWayCheck"))
        {
            KeyTip1.SetActive(true);
            KeyTip2.SetActive(true);

            if (TriggerShield == 0)
            {
                if (false == IsPreview && Input.GetKeyDown(KeyCode.E))
                {
                    TriggerShield = 1;
                    IsPreview = true;
                    mCamera.mCAMSTATUS = CCamera.CAMSTATUS.PLAY_MAZE;
                    HMMgr.mHMSTATUS = Puzzle_01_HiddenMaze.HMSTATUS.PLAYING;
                }

                if (false == IsPreview && HMMgr.mHMSTATUS == Puzzle_01_HiddenMaze.HMSTATUS.NORMAL && Input.GetKeyDown(KeyCode.F))
                {
                    TriggerShield = 1;
                    IsPreview = true;
                    mCamera.mCAMSTATUS = CCamera.CAMSTATUS.PRE_MAZE;
                }
            }

            if (true == IsPreview && HMMgr.mHMSTATUS == Puzzle_01_HiddenMaze.HMSTATUS.NORMAL && Input.GetKeyUp(KeyCode.F))
            {
                TriggerShield = 0;
                IsPreview = false;
                mCamera.mCAMSTATUS = CCamera.CAMSTATUS.NORMAL;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("tagWayCheck"))
        {
            TriggerShield = 0;

            KeyTip1.SetActive(false);
            KeyTip2.SetActive(false);
        }
    }
}
