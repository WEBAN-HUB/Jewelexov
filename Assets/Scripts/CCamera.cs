using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCamera : MonoBehaviour
{
    public enum CAMSTATUS
    {
        NORMAL = 0,

        PLAY_MAZE,
        MOVE_MAZE_TO_PLAYER,
        PRE_MAZE,
        DIE_MAZE,

        GEMEVENT_W1_1,
        GEMEVENT_W1_2,
        GEMEVENT_W1_3,

        GEMEVENT_W2_1,
        GEMEVENT_W2_2,
        GEMEVENT_W2_3,
        GEMEVENT_W2_4,
    }
    public CAMSTATUS mCAMSTATUS = CAMSTATUS.NORMAL;

    public CPlayer mpActor = null;
    GameObject mpPlayerCameraPos = null;

    public float mDistance = 12f;
    public float mHeight = 4.5f;
    public float mDampTrace = 100.0f;

    bool CamTimerOn = false;
    int CamTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        mpPlayerCameraPos = mpActor.CameraPos;

        if (mpActor.mHorizontal > 0f)
        {
            this.transform.position = mpActor.transform.position -
                (Vector3.Cross(mpActor.ViewDir.transform.forward, mpActor.ViewDir.transform.up) * mDistance) + (this.transform.up * mHeight);
        }
        else if (mpActor.mHorizontal < 0f)
        {
            this.transform.position = mpActor.transform.position -
                (Vector3.Cross(mpActor.ViewDir.transform.forward, mpActor.ViewDir.transform.up) * -mDistance) + (this.transform.up * mHeight);
        }

        this.transform.LookAt(mpPlayerCameraPos.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (true == CamTimerOn)
        {
            CamTimer++;
            if (CamTimer < 90)
            {

            }
            else
            {
                mCAMSTATUS = CAMSTATUS.NORMAL;
                CamTimerOn = false;
                CamTimer = 0;
            }
        }
    }

    private void LateUpdate()
    {
        switch (mCAMSTATUS)
        {
            case CAMSTATUS.NORMAL:
            case CAMSTATUS.DIE_MAZE:
                {
                    Camera.main.orthographic = false;
                    Camera.main.fieldOfView = 60f;

                    if (mpActor.mHorizontal > 0f && mpActor.Right_Edge == false)
                    {
                        this.transform.position = mpActor.transform.position -
                            (Vector3.Cross(mpActor.ViewDir.transform.forward, mpActor.ViewDir.transform.up) * mDistance) + (this.transform.up * mHeight);
                    }
                    else if (mpActor.mHorizontal < 0f && mpActor.Left_Edge == false)
                    {
                        this.transform.position = mpActor.transform.position -
                            (Vector3.Cross(mpActor.ViewDir.transform.forward, mpActor.ViewDir.transform.up) * -mDistance) + (this.transform.up * mHeight);
                    }
                    else
                    {
                        if (0 == mpActor.mDir)
                        {
                            this.transform.position = mpActor.transform.position -
                            (Vector3.Cross(mpActor.ViewDir.transform.forward, mpActor.ViewDir.transform.up) * mDistance) + (this.transform.up * mHeight);
                        }
                        else if (1 == mpActor.mDir)
                        {
                            this.transform.position = mpActor.transform.position -
                            (Vector3.Cross(mpActor.ViewDir.transform.forward, mpActor.ViewDir.transform.up) * -mDistance) + (this.transform.up * mHeight);
                        }
                    }

                    this.transform.LookAt(mpPlayerCameraPos.transform.position);
                }
                break;

            case CAMSTATUS.PLAY_MAZE:
            case CAMSTATUS.PRE_MAZE:
                {
                    Camera.main.orthographic = true;
                    Camera.main.orthographicSize = 10f;

                    this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(122.5f, 14f, 68.5f), 5f * Time.deltaTime);
                    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(new Vector3(90f, -90f, 0)), 5f * Time.deltaTime);
                }
                break;

            case CAMSTATUS.GEMEVENT_W1_1:
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(31.85f, 6.94f, -11.13f), 10f * Time.deltaTime);

                    mpActor.mHorizontal = 0f;
                    CamTimerOn = true;
                }
                break;
            case CAMSTATUS.GEMEVENT_W1_2:
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(67.65f, 5.4f, -11.13f), 10f * Time.deltaTime);

                    mpActor.mHorizontal = 0f;
                    CamTimerOn = true;
                }
                break;
            case CAMSTATUS.GEMEVENT_W1_3:
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(62.5f, 12.5f, -11.13f), 10f * Time.deltaTime);

                    mpActor.mHorizontal = 0f;
                    CamTimerOn = true;
                }
                break;

            case CAMSTATUS.GEMEVENT_W2_1:
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(205.8f, 38.0f, 215.1f), 10f * Time.deltaTime);
                    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(new Vector3(0, -73f, 0)), 5f * Time.deltaTime);

                    mpActor.mHorizontal = 0f;
                    CamTimerOn = true;
                }
                break;
            case CAMSTATUS.GEMEVENT_W2_2:
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(197.3f, 15.5f, 186.7f), 10f * Time.deltaTime);
                    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(new Vector3(0, -73f, 0)), 5f * Time.deltaTime);

                    mpActor.mHorizontal = 0f;
                    CamTimerOn = true;
                }
                break;
            case CAMSTATUS.GEMEVENT_W2_3:
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(203.5f, 37.5f, 205.7f), 10f * Time.deltaTime);
                    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(new Vector3(0, -73f, 0)), 5f * Time.deltaTime);

                    mpActor.mHorizontal = 0f;
                    CamTimerOn = true;
                }
                break;
            case CAMSTATUS.GEMEVENT_W2_4:
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(186.8f, 29.4f, 162.0f), 10f * Time.deltaTime);
                    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(new Vector3(0, -73f, 0)), 5f * Time.deltaTime);

                    mpActor.mHorizontal = 0f;
                    CamTimerOn = true;
                }
                break;
        }
    }
}
