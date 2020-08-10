using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGem_1_2 : MonoBehaviour
{
    public GameObject Gem_1_2 = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (CSgtGameData.GetInstance().Destroy_Gem)
        {
            case false:
                {
                    Gem_1_2.SetActive(false);
                }
                break;
            case true:
                {
                    Gem_1_2.SetActive(true);
                }
                break;
        }
    }
}
