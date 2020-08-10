using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    CPlayer mpPlayer = null;
    public Text target = null;
    public Text current = null;
    public Text movedir = null;
    public Text thispos = null;
    public Text targetpos = null;

    // Start is called before the first frame update
    void Start()
    {
        mpPlayer = FindObjectOfType<CPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        target.text = "Target Index : " + mpPlayer.TargetIndex.ToString();
        current.text = "Current Index : " + mpPlayer.CurrentIndex.ToString();
        movedir.text = "MoveDir : " + mpPlayer.MoveDir.ToString();
        thispos.text = "this.transform.position : " + mpPlayer.transform.position.ToString();
        targetpos.text = "mCheckPointNum[" + mpPlayer.TargetIndex + "].transform.position : " + mpPlayer.mCheckPointNum[mpPlayer.TargetIndex].transform.position.ToString();
    }
}
