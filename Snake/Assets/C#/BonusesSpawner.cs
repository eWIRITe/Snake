using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesSpawner : MonoBehaviour
{
    public GameObject BonusPref;

    public Transform Pos1;
    public Transform Pos2;

    public float TimeTo;
    private float Timer;

    public void FixedUpdate()
    {
        //just timer
        if(Timer >= TimeTo)
        {
            //spawn bonus in random position
            Instantiate(BonusPref, new Vector3(Random.Range(Pos1.position.x, Pos2.position.x), transform.position.y, Random.Range(Pos1.position.z, Pos2.position.z)), Quaternion.identity);
            
            Timer = 0;
        }
        else
        {
            Timer += Time.deltaTime;
        }
    }
}
