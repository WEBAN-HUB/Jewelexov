using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using UnityEngine.UI;

public class StaffUI : MonoBehaviour
{
    public Text EndingTxt = null;
    int i = 0;

    
    void Start()
    {

        InvokeRepeating("WriteEnding", 0, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void WriteEnding()
    {
        if( i == 3)
        {
            i = 0;
        }
        EndingTxt.text = "";

        string Txt_0 = "Jewelexov" + "\n" +"\n"+ "-Team-"+"\n"+ "2Beats"+"\n"+"\n"+"-Member-"+"\n"+"서지혁, 김상휘";
        string Txt_1 = "Develop period" + "\n" + "2019.09.16 ~~" + "\n" + "2019.10.18" + "\n" + "\n" + "Powered by Unity";
        string Txt_2 = "플레이 해주셔서 감사합니다." + "\n" + "\n"+"(^_^)/";

;


        if (i == 0)
        {
            EndingTxt.DOText(Txt_0,4,true);
        }
        else if( i == 1)
        {
            EndingTxt.DOText(Txt_1, 4, true);
        }
        else if( i == 2)
        {
            EndingTxt.DOText(Txt_2, 4, true);
        }


        i++;
    }    
}
