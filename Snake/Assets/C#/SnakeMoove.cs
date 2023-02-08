using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class SnakeMoove : MonoBehaviour
{
    //list of body pices
    [SerializeField] public List<Transform> BodyPices = new List<Transform>();

    //Moove varibles
    public float MinDistance;
    public float RotationSpeed;
    public float Speed;
    public bool isCanMoove = true;

    public float BeginSize;

    //Key coodes
    public KeyCode keyForSprint;

    //Prefab of body pices
    public GameObject BodyPicePref;

    private float Dis;
    private Transform curBodyPart;
    private Transform PrevBodypart;

    public void Awake()
    {
        //add start pices
        for (int i = 0; i < BeginSize - 1; i++)
        {
            AddBodyPice();
        }
    }

    void Update()
    {
        //function moove
        if(isCanMoove) Moove();
    }

    void Moove()
    {

        float _speed = Speed;

        //if key to stint pressed multiply speed by 2
        if (Input.GetKey(keyForSprint)) _speed *= 2;

        //Moove first pice
        BodyPices[0].Translate(BodyPices[0].forward * _speed * Time.smoothDeltaTime, Space.World);

        //Rotate first pice
        if (Input.GetAxis("Horizontal") != 0)
            BodyPices[0].Rotate(Vector3.up * RotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));

        for (int i = 1; i < BodyPices.Count; i++)
        {
            //tace pice
            curBodyPart = BodyPices[i];
            //take last pice
            PrevBodypart = BodyPices[i - 1];

            //count distance
            Dis = Vector3.Distance(PrevBodypart.position, curBodyPart.position);

            //create new Pos 
            Vector3 newpos = PrevBodypart.position;

            //set new Pos y 
            newpos.y = BodyPices[0].position.y;

            //cound able dostance
            float T = Time.deltaTime * Dis / MinDistance * _speed;

            //if distance to long, we cut it
            if (T > 0.5)
                T = 0.5f;

            //moove pice
            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, PrevBodypart.rotation, T);
        }
    }

    public void AddBodyPice()
    {
        //add pice
        GameObject newPice = Instantiate(BodyPicePref, BodyPices[BodyPices.Count - 1].position, BodyPices[BodyPices.Count - 1].rotation);

        //set parant
        newPice.transform.SetParent(transform);

        //add our new body pice in BodyPices list
        BodyPices.Add(newPice.transform);
    }

}
