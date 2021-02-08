using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmoriInfor : MonoBehaviour
{


    public int FirstOmori;
    public int OmoriMass = 1;


    int unitychanObstacleWeight = 0;
    bool OmoriOnFloorFlag = false;

    FallDownFloor DownFloorOmori;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("触れた");
        if (other.gameObject.tag == "FallDownFloor")
        {

            DownFloorOmori = other.gameObject.GetComponent<FallDownFloor>();
            OmoriOnFloorFlag = true;
        }
        Debug.Log(OmoriOnFloorFlag);
        /* if (OmoriOnFloorFlag)
         {
             DownFloorOmori.GetOmoriMassUpdate(this.gameObject, OmoriMass);
         }*/
    }


    /*public void OnTriggerExit2D(Collider2D other)
    {
        /*if (OmoriOnFloorFlag)
        {
            DownFloorOmori.GetOmoriMassUpdate(this.gameObject, OmoriMass);
        }*/
    /* OmoriOnFloorFlag = false;
 }*/


    public void OnOmoriUpdate(int OnOmoriMass)
    {
        //Debug.Log("OnOmoriUpdate on");
        OmoriMass = FirstOmori + OnOmoriMass;
        if (OmoriOnFloorFlag)
        {
            DownFloorOmori.GetOmoriMassUpdate(this.gameObject, OmoriMass);
            //Debug.Log(this.gameObject);
        }
    }
}
