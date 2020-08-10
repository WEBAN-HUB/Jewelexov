using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    CPlayer mpPlayer = null;

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
            this.gameObject.SetActive(false);

            if (this.CompareTag("tagGem_0_0"))
            {
                CSgtGameData.GetInstance().DashGemLvUp();
                mpPlayer.SetDashScalar();
            }
            if (this.CompareTag("tagGem_0_1"))
            {
                CSgtGameData.GetInstance().JumpGemLvUp();
                mpPlayer.SetJumpCount();
            }

            if (this.CompareTag("tagGem_1_0"))
            {
                CSgtGameData.GetInstance().Move_Gem = true;
            }
            if (this.CompareTag("tagGem_1_1"))
            {
                CSgtGameData.GetInstance().Create_Gem = true;
            }
            if (this.CompareTag("tagGem_1_2"))
            {
                CSgtGameData.GetInstance().Destroy_Gem = true;
            }
        }
    }
}
