using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject Player;

    public string BlockTag;
    public string BonusTag;

    public GameObject DeadCanv;

    //Sound effects
    public AudioSource _sourse;
    public AudioSource _firstSourse;
    public AudioClip ClipGetBonus;
    public AudioClip ClipLoose;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == BonusTag)
        {
            Player.GetComponent<SnakeMoove>().AddBodyPice();
            Destroy(other.gameObject);
            _sourse.PlayOneShot(ClipGetBonus);
        }
        else if(other.tag == BlockTag)
        {
            _firstSourse.enabled = false;
            _sourse.PlayOneShot(ClipLoose);
            Player.GetComponent<SnakeMoove>().isCanMoove = false;
            DeadCanv.SetActive(true);
        }
    }
}
