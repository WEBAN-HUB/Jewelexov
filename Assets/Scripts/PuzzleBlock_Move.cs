using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlock_Move : MonoBehaviour
{
    public float Move_Scalar = 0.06f;
    float Move_Cliping = 0f;
    public float Max_Y = 14.0f;
    public float Min_Y = -14.0f;
    Vector3 Move_V = Vector3.zero;
    public bool ActiveGem = false;

    Transform mpTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        mpTransform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (true == ActiveGem)
        {
            Move_Cliping = Move_Cliping + Move_Scalar;
            if (Move_Cliping > Max_Y || Move_Cliping < Min_Y)
            {
                Move_Scalar = Move_Scalar * -1;
                Move_Cliping = 0;
            }

            Move_V.y = Move_Scalar;

            mpTransform.Translate(Move_V, Space.World);
        }
    }
}
