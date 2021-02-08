using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmoriOnTrigger : MonoBehaviour
{
    Dictionary<GameObject, int> ObstacleWeightList = new Dictionary<GameObject, int>();

    GameObject TargetManager;

    GameObject ObstacleInfo;

    TargetManager Targetscript;
    OmoriInfor OmoriInfor;

    public int OnOmoriMass = 0;


    int unitychanObstacleWeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject childObject = gameObject.transform.parent.gameObject;
        ObstacleInfo = childObject.transform.Find("ObstacleInfo").gameObject;

        //ObstacleInfo = GameObject.Find("ObstacleInfo");
        OmoriInfor = ObstacleInfo.GetComponent<OmoriInfor>();
        TargetManager = GameObject.Find("TargetManager");
        Targetscript = TargetManager.GetComponent<TargetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        unitychanObstacleWeight = Targetscript.weight;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Character")
        {
            ObstacleWeightList.Add(other.gameObject, unitychanObstacleWeight);
            Debug.Log("Character on");
        }


        /*if (other.gameObject.tag == "Obstacle")
        {

            Debug.Log("お守りに触れた");
            int OmoriWeight = other.gameObject.GetComponent<OmoriInfor>().OmoriMass;
            ObstacleWeightList.Add(other.gameObject, OmoriWeight);
        }*/

        TotalObstacleWeightCalc();

        OmoriInfor.OnOmoriUpdate(OnOmoriMass);

    }


    public void OnTriggerExit2D(Collider2D other)
    {
        ObstacleWeightList.Remove(other.gameObject);

        TotalObstacleWeightCalc();

        OmoriInfor.OnOmoriUpdate(OnOmoriMass);
    }

    void TotalObstacleWeightCalc()
    {
        int ObjectObstacleWeight = 0;
        foreach (int Value in ObstacleWeightList.Values)
        {
            ObjectObstacleWeight += Value;
        }
        OnOmoriMass = ObjectObstacleWeight;
    }
}
