using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_01_Pointer : MonoBehaviour
{
    Puzzle_01_HiddenMaze HMMgr;
    Info_World_1 mpWorld1Info;
    CPlayer mpPlayer;
    CCamera mCamera;
    UIPlaying mUIPlaying;
    float DieTimeCount = 0f;
    bool DieTimeOn = false;

    int[,] MazeGrid = new int[9, 9]
    {
        {2,2,2,2,3,3,2,2,2 },
        {2,3,3,2,3,2,2,3,2 },
        {2,3,2,2,3,2,3,3,2 },
        {2,3,2,3,2,2,3,3,2 },
/*시작*/{0,3,2,3,2,3,3,3,1 },
        {3,2,2,3,2,2,2,2,3 },
        {2,2,3,3,3,3,3,2,2 },
        {2,3,3,3,2,2,2,3,2 },
        {2,2,2,2,2,3,2,2,2 }
    };
    //0:시작 1:도착 2:길O 3:길X
    int mX = 0;
    int mY = 4;

    // Start is called before the first frame update
    void Start()
    {
        HMMgr = FindObjectOfType<Puzzle_01_HiddenMaze>();
        mpWorld1Info = FindObjectOfType<Info_World_1>();
        mpPlayer = FindObjectOfType<CPlayer>();
        mCamera = FindObjectOfType<CCamera>();
        mUIPlaying = FindObjectOfType<UIPlaying>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mCamera.mCAMSTATUS == CCamera.CAMSTATUS.PLAY_MAZE)
        {
            mpPlayer.mHorizontal = 0f;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                mY--;
                this.transform.localPosition = new Vector3(this.transform.localPosition.x - 1.6f, this.transform.localPosition.y, this.transform.localPosition.z);
                if (mY < 0)
                {
                    mY = 0;
                    this.transform.localPosition = new Vector3(-6.9f, this.transform.localPosition.y, this.transform.localPosition.z);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                mY++;
                this.transform.localPosition = new Vector3(this.transform.localPosition.x + 1.6f, this.transform.localPosition.y, this.transform.localPosition.z);
                if (mY > MazeGrid.GetLength(0) - 1)
                {
                    mY = 8;
                    this.transform.localPosition = new Vector3(5.9f, this.transform.localPosition.y, this.transform.localPosition.z);
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                mX--;
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z - 1.59f);
                if (mX < 0)
                {
                    mX = 0;
                    this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, -7.2f);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                mX++;
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z + 1.59f);
                if (mX > MazeGrid.GetLength(1) - 1)
                {
                    mX = 8;
                    this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, 5.5f);
                }
            }

            //Judge
            if (MazeGrid[mY, mX] == 0)
            {
                
            }
            else if (MazeGrid[mY, mX] == 2)
            {
                
            }
            else if (MazeGrid[mY, mX] == 3)
            {
                mCamera.mCAMSTATUS = CCamera.CAMSTATUS.DIE_MAZE;
                mUIPlaying.outPauseUI.SetActive(false);
                DieTimeOn = true;
            }
            else
            {
                mpWorld1Info.SavePointList[1].SetActive(true);
                mCamera.mCAMSTATUS = CCamera.CAMSTATUS.NORMAL;
                HMMgr.mHMSTATUS = Puzzle_01_HiddenMaze.HMSTATUS.ENDED;
            }
        }

        if (true == DieTimeOn)
        {
            if (DieTimeCount < 80)
            {
                DieTimeCount++;
            }
            else
            {
                mpPlayer.Dead();
                DieTimeOn = false;
            }
        }
    }
}
