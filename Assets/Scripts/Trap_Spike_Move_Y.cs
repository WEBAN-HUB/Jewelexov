using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Spike_Move_Y : MonoBehaviour
{
    public float Move_Scalar = 0.05f;
    float Move_Cliping = 0f;
    public float Max_Y = 1.5f;
    public float Min_Y = -1.5f;
    Vector3 Move_V = Vector3.zero;

    public bool Pause_Trap = false;
    public bool Trap_Stop = false;
    int Trap_Start_Count = 0;
    public int Trap_Start_Limit = 0;

    public GameObject Red_Light = null;
    public GameObject Blue_Light = null;

    public int Trap_Type = 0;

    public int Trap_Awake_Count = 0;

    Transform mpTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        if (Red_Light != null && Blue_Light != null)
        {
            if (Move_Scalar > 0)
            {
                Red_Light.SetActive(true);
                Blue_Light.SetActive(false);
            }
            else
            {
                Blue_Light.SetActive(true);
                Red_Light.SetActive(false);
            }
        }

        mpTransform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Trap_Awake_Count <= 0)
        {
            if (Trap_Stop == false)
            {
               

                Move_Cliping = Move_Cliping + Move_Scalar;
                if (Move_Cliping > Max_Y || Move_Cliping < Min_Y)
                {
                    if (Red_Light != null && Blue_Light != null)
                    {
                        if (Trap_Type == 0)
                        {
                            if (Move_Cliping < Min_Y)
                            {
                                Blue_Light.SetActive(true);
                                Red_Light.SetActive(false);
                            }
                            else
                            {
                                Red_Light.SetActive(true);
                                Blue_Light.SetActive(false);
                            }
                        }
                        else if (Trap_Type == 1)
                        {
                            if (Move_Cliping > Max_Y)
                            {
                                Blue_Light.SetActive(true);
                                Red_Light.SetActive(false);
                            }
                            else
                            {
                                Red_Light.SetActive(true);
                                Blue_Light.SetActive(false);
                            }
                        }
                    }
                    Move_Scalar = Move_Scalar * -1;
                    Move_Cliping = 0;
                    Trap_Stop = true;
                }

                Move_V.y = Move_Scalar;

                mpTransform.Translate(Move_V,Space.Self);
            }
            else
            {
                Trap_Start_Count++;

                if (Trap_Start_Count > Trap_Start_Limit)
                {

                    Trap_Stop = false;
                    Trap_Start_Count = 0;
                    if (Red_Light != null && Blue_Light != null)
                    {
                        Red_Light.SetActive(true);
                        Blue_Light.SetActive(false);
                    }
                }

            }

        }
        else
        {
            Trap_Awake_Count--;
        }
    }
}
