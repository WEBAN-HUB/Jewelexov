using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGem_1_0 : MonoBehaviour
{
    public GameObject Gem_1_0 = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (CSgtGameData.GetInstance().Move_Gem)
        {
            case false:
                {
                    Gem_1_0.SetActive(false);
                }
                break;
            case true:
                {
                    Gem_1_0.SetActive(true);
                }
                break;
        }
    }
}
