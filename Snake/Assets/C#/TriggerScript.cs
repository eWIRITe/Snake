using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject Player;

    public string BlockTag;
    public string BonusTag;

    public GameObject DeadCanv;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == BonusTag)
        {
            Player.GetComponent<SnakeMoove>().AddBodyPice();
            Destroy(other.gameObject);
        }
        else if(other.tag == BlockTag)
        {
            Player.GetComponent<SnakeMoove>().isCanMoove = false;
            DeadCanv.SetActive(true);
        }
    }
}
