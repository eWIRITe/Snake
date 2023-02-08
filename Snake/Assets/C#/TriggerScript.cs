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
        //if the object is a bonus
        if(other.tag == BonusTag)
        {
            //add pice to player
            Player.GetComponent<SnakeMoove>().AddBodyPice();

            //destroy bonus object
            Destroy(other.gameObject);

            //play musick
            if(_sourse != null) _sourse.PlayOneShot(ClipGetBonus);
        }
        //if the object is a barier
        else if(other.tag == BlockTag)
        {
            //turn off background musick
            _firstSourse.enabled = false;
            //play loose musick
            _sourse.PlayOneShot(ClipLoose);
            //player cant moove
            Player.GetComponent<SnakeMoove>().isCanMoove = false;
            DeadCanv.SetActive(true);
        }
    }
}
