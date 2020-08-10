using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSgtGameData 
{
    static public CSgtGameData mpInstance = null;

    GemInfoList SgtGemInfoList = null;

    public int DashGemLV = 0;
    public int JumpGemLV = 0;

    public float DashScalar = 0f;
    public int JumpCount = 0;

    public bool Move_Gem = false;
    public bool Create_Gem = false;
    public bool Destroy_Gem = false;

    public int InStart_DashGemLV = 0;
    public int InStart_JumpGemLV = 0;

    public int FromStart = 0;

    private CSgtGameData()
    {
        
    }

    static public CSgtGameData GetInstance()
    {
        if(mpInstance == null)
        {
           mpInstance = new CSgtGameData();
        }
        return mpInstance;
    }

    public void SetGemInfoList(GemInfoList infolist)
    {
        SgtGemInfoList = infolist;

        SetDashScalar(0);
    }
    
    public void SetDashScalar(float Lv)
    {
        DashScalar = 2 + (Lv * SgtGemInfoList.GemList[0].Power);
    }

    public void SetJumpCount()
    {
        JumpCount = JumpGemLV;
    }

    public void DashGemLvUp()
    {
        if (DashGemLV < SgtGemInfoList.GemList[0].MAX_LV)
        {
            DashGemLV = DashGemLV + 1;
        }

        SetDashScalar(DashGemLV);
    }


    public void JumpGemLvUp()
    {
        if (JumpGemLV < SgtGemInfoList.GemList[1].MAX_LV)
        {
            JumpGemLV = JumpGemLV + 1;
        }

        SetJumpCount();
    }

}
