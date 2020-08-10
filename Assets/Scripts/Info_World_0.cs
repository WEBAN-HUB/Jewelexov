using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_World_0 : MonoBehaviour
{
    public GameObject PFGem_0_1 = null;
    public List<GameObject> GemList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CSoundsMgr.Getinstance().MusicAllStop();


        CSgtGameData.GetInstance().InStart_DashGemLV = 0;
        CSgtGameData.GetInstance().InStart_JumpGemLV = 0;

        GameObject tGem1 = Instantiate<GameObject>(PFGem_0_1, new Vector3(23.0f, 3.0f, 4.0f), Quaternion.identity);
        GemList.Add(tGem1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
