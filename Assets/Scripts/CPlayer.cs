using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    enum STATE
    {
        IDLE = 0,
        WALK = 1,
        DASH = 2,
        JUMP = 3,
    }
    STATE mState = STATE.IDLE;


    public Animator mAnimator = null;
    public GameObject ViewDir = null;
    public GameObject CameraPos = null;
    public CCamera MainCamera = null;
    public GameObject Mesh = null;
    public GameObject Dead_Particle = null;

    public List<GameObject> mCheckPointNum = new List<GameObject>();

    public GameObject PFGem = null;
    public int GemCount = 0;
    public List<GameObject> GemList = new List<GameObject>();


    public float mHorizontal = 0f;
    public int mDir = 0; //0: right, 1: left

    public float mSpeedScalar = 3.5f;
    public float mDashScalar = CSgtGameData.GetInstance().DashScalar;
    public float mJumpScalar = 8f;

    float InputStr = 0f;
    int Jump_count = CSgtGameData.GetInstance().JumpCount;
    int IsGround = 0;
    float Jump_Scalar_Foward = 0;
    public Vector3 Jump_Vector3_Foward = Vector3.zero;
    int Jump_Cliping = 1;

    public Vector3 MoveDir = Vector3.zero;
    public int TargetIndex = 0;
    public int CurrentIndex = 0;
    public int LastIndex = 0;
    public bool Left_Edge = false;
    public bool Right_Edge = false;
    public bool Life = true;
    bool IsOnWall = false;
    bool Ani_isGround = true;


    public float mTime = 1f;
    int wallbound = 1;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] tWaypointArray = GameObject.FindGameObjectsWithTag("tagCheckPoint");

        SortedDictionary<string, GameObject> tSD = new SortedDictionary<string, GameObject>();
        foreach (var t in tWaypointArray)
        {
            tSD.Add(t.gameObject.name, t.gameObject);
        }
        foreach (var t in tSD)
        {
            mCheckPointNum.Add(t.Value);
        }

        LastIndex = mCheckPointNum.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        if (MainCamera.mCAMSTATUS == CCamera.CAMSTATUS.NORMAL)
        {
            if (Life == true)
            {
                mAnimator.SetInteger("Jump_Count", Jump_count);
                mHorizontal = Input.GetAxis("Horizontal");

                if (mHorizontal > 0f && Right_Edge == false)
                {
                    mDir = 0;

                    MoveDir = (mCheckPointNum[TargetIndex].transform.position - this.transform.position).normalized;
                    MoveDir.y = 0;

                    if (mTime < 1f)
                    {
                        ViewDir.transform.forward = Vector3.Lerp(ViewDir.transform.forward, MoveDir, mTime);
                        mTime += 0.05f;
                    }
                    else
                    {
                        ViewDir.transform.forward = MoveDir;
                    }
                }
                else if (mHorizontal < 0f && Left_Edge == false)
                {
                    mDir = 1;

                    MoveDir = (mCheckPointNum[CurrentIndex].transform.position - this.transform.position).normalized;
                    MoveDir.y = 0;

                    if (mTime < 1f)
                    {
                        ViewDir.transform.forward = Vector3.Lerp(ViewDir.transform.forward, MoveDir, mTime);
                        mTime += 0.05f;
                    }
                    else
                    {
                        ViewDir.transform.forward = MoveDir;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Space) && IsOnWall == false)
                {
                    if (Jump_count > 0)
                    {
                        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

                        Vector3 JumpVector = this.GetComponent<Rigidbody>().velocity;
                        JumpVector.y = 0;
                        this.GetComponent<Rigidbody>().velocity = JumpVector;

                        Vector3 tDir = Vector3.zero;
                        tDir = (Vector3.up * mJumpScalar);
                        this.GetComponent<Rigidbody>().AddForce(tDir, ForceMode.Impulse);

                        Jump_Scalar_Foward = InputStr;
                        Jump_Vector3_Foward = MoveDir;

                        mAnimator.SetTrigger("Jumping");

                        Jump_count--;
                    }
                }

                if (Jump_count < CSgtGameData.GetInstance().JumpCount)
                {
                    if (Left_Edge == true || Right_Edge == true)
                    {
                        Jump_Cliping = 0;
                    }
                    else { Jump_Cliping = 1; }

                    if (mState == STATE.WALK)
                    {
                        this.GetComponent<Rigidbody>().AddForce(Jump_Scalar_Foward * Jump_Vector3_Foward * mSpeedScalar * Jump_Cliping, ForceMode.Impulse);
                    }
                    else if (mState == STATE.DASH)
                    {
                        this.GetComponent<Rigidbody>().AddForce(Jump_Scalar_Foward * Jump_Vector3_Foward * mSpeedScalar * mDashScalar * Jump_Cliping, ForceMode.Impulse);
                    }
                }
            }
        }
        //else if (MainCamera.mCAMSTATUS == CCamera.CAMSTATUS.PLAY_MAZE || MainCamera.mCAMSTATUS == CCamera.CAMSTATUS.PRE_MAZE)
        //{

        //}
    }

    private void FixedUpdate()
    {
        if (Life == true)
        {
            Acting();
        }
    }

    void GroundCheck()
    {
        RaycastHit Ray_Hit;

        if (Physics.Raycast(this.transform.position + Vector3.up, Vector3.down, out Ray_Hit, 1f))
        {
            if (Ray_Hit.collider.CompareTag("tagGround"))
            {
                if (IsGround == 0)
                {
                    IsGround = 1;
                    Jump_count = CSgtGameData.GetInstance().JumpCount;
                    Ani_isGround = true;
                    mAnimator.SetBool("IsGround", Ani_isGround);
                }
            }
        }
        else
        {
            if (IsGround == 1)
            {
                IsGround = 0;
                Ani_isGround = false;
                mAnimator.SetBool("IsGround", Ani_isGround);
            }
        }
    }

    void Acting()
    {
        InputStr = Mathf.Abs(mHorizontal);

        if (mHorizontal == 0 && Jump_count == CSgtGameData.GetInstance().JumpCount)
        {
            if (Input.anyKey == false)
            {
                mState = STATE.IDLE;

                mAnimator.SetInteger("STATE", 0);
            }
        }
        else if (mHorizontal != 0 && Input.GetKey(KeyCode.LeftShift) && Jump_count == CSgtGameData.GetInstance().JumpCount)
        {
            if ((Left_Edge == false && mHorizontal < 0) || (Right_Edge == false && mHorizontal > 0))
            {
                mState = STATE.DASH;

                this.GetComponent<Rigidbody>().AddForce(InputStr * MoveDir * mSpeedScalar * mDashScalar, ForceMode.Impulse);

                mAnimator.SetInteger("STATE", 2);
            }
        }
        else if (mHorizontal != 0 && Jump_count == CSgtGameData.GetInstance().JumpCount)
        {
            if ((Left_Edge == false && mHorizontal < 0) || (Right_Edge == false && mHorizontal > 0))
            {
                mState = STATE.WALK;

                this.GetComponent<Rigidbody>().AddForce(InputStr * MoveDir * mSpeedScalar, ForceMode.Impulse);

                mAnimator.SetTrigger("Walk");
                mAnimator.SetInteger("STATE", 1);
            }
        }
    }

    public void Dead()
    {
        Mesh.SetActive(false);
        Life = false;
        Dead_Particle.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tagWall"))
        {
            IsOnWall = true;
            if (IsGround == 0)
            {
                if (wallbound == 1)
                {
                    MoveDir = Jump_Vector3_Foward * -1;

                    Jump_Vector3_Foward = MoveDir;

                    wallbound = 0;
                }
            }
        }

        if (other.CompareTag("tagTrap"))
        {
            Dead();
        }

        //if (other.CompareTag("tagSavePoint"))
        //{
        //    other.gameObject.SetActive(false);
        //    DataMgr.Save_Playing();
        //}
    }
    private void OnTriggerStay(Collider other)
    {
        //if(other.CompareTag("tagWall"))
        //{
        //    IsOnWall = true;

        //    if (IsGround == 0)
        //    {
        //        if(wallbound == 1)
        //        {
        //            MoveDir = Jump_Vector3_Foward * -1;

        //            Jump_Vector3_Foward = MoveDir;

        //            wallbound = 0;
        //        }
        //    }
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("tagWall"))
        {
            wallbound = 1;
            IsOnWall = false;
        }
    }


    public void SetDashScalar()
    {
        mDashScalar = CSgtGameData.GetInstance().DashScalar;
    }
    public void SetJumpCount()
    {
        Jump_count = CSgtGameData.GetInstance().JumpCount;
    }
}
