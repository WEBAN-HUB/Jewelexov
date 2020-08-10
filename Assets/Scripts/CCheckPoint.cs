using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCheckPoint : MonoBehaviour
{
    CPlayer mpPlayer = null;

    string Num_c = "";
    int Collision_c = 0;
    int TriggerShield = 0;

    // Start is called before the first frame update
    void Start()
    {
        mpPlayer = FindObjectOfType<CPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tagWayCheck"))
        {
            if (TriggerShield == 0)
            {
                TriggerShield = 1;
                if (mpPlayer.TargetIndex == 0)
                {
                    mpPlayer.TargetIndex++;

                    mpPlayer.mTime = 0f;

                    Vector3 Start_move = Vector3.zero;
                    Start_move = ((mpPlayer.mCheckPointNum[mpPlayer.TargetIndex].transform.position) - mpPlayer.transform.position).normalized;

                    mpPlayer.transform.Translate(Start_move * 2);

                }
                else if (mpPlayer.TargetIndex != 0)
                {
                    mpPlayer.Jump_Vector3_Foward = mpPlayer.MoveDir;

                    Num_c = this.gameObject.name.ToString();

                    Collision_c = int.Parse(Num_c);

                    if (mpPlayer.TargetIndex != Collision_c)
                    {
                        if (Collision_c == 0)
                        {
                            mpPlayer.TargetIndex = 1;
                            mpPlayer.CurrentIndex = 0;
                            mpPlayer.Left_Edge = true;
                        }
                        else
                        {
                            mpPlayer.TargetIndex = Collision_c;
                            mpPlayer.CurrentIndex = Collision_c - 1;
                        }
                    }
                    else if (mpPlayer.TargetIndex == Collision_c)
                    {
                        if (Collision_c == mpPlayer.LastIndex)
                        {
                            mpPlayer.TargetIndex = mpPlayer.LastIndex;
                            mpPlayer.CurrentIndex = mpPlayer.LastIndex - 1;
                            mpPlayer.Right_Edge = true;
                        }
                        else
                        {
                            mpPlayer.TargetIndex = Collision_c + 1;
                            mpPlayer.CurrentIndex = Collision_c;
                        }
                    }

                    if (mpPlayer.Right_Edge == false && mpPlayer.Left_Edge == false)
                    {
                        mpPlayer.mTime = 0f;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("tagWayCheck"))
        {
            Num_c = this.gameObject.name.ToString();

            Collision_c = int.Parse(Num_c);
            mpPlayer.Left_Edge = false;
            mpPlayer.Right_Edge = false;
            TriggerShield = 0;
        }
    }
}
