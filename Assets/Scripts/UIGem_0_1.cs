using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGem_0_1 : MonoBehaviour
{
    public GameObject Gem_0_1_Lv1 = null;
    public GameObject Gem_0_1_Lv2 = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (CSgtGameData.GetInstance().JumpGemLV)
        {
            case 0:
                {
                    Gem_0_1_Lv1.SetActive(false);
                    Gem_0_1_Lv2.SetActive(false);
                }
                break;
            case 1:
                {
                    Gem_0_1_Lv1.SetActive(true);
                    Gem_0_1_Lv2.SetActive(false);
                }
                break;
            case 2:
                {
                    Gem_0_1_Lv1.SetActive(false);
                    Gem_0_1_Lv2.SetActive(true);
                }
                break;
        }
    }
}
