using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownFloor : MonoBehaviour
{
    //　床が落下するまでの時間
    [SerializeField] private float timeToFall = 1.0f;
    [SerializeField] private float overWeight = 1;


    Dictionary<GameObject, int> ObjectWeightList = new Dictionary<GameObject, int>();
    GameObject TargetManager;
    // public GameObject OmoriController;

    TargetManager Targetscript;
    //OmoriInfor Omoriscript;
    int unitychanWeight = 0;
    //int omoriWeight = 0;
    int totalWeight = 0;

    Rigidbody2D rb;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        TargetManager = GameObject.Find("TargetManager");
        Targetscript = TargetManager.GetComponent<TargetManager>();
        //OmoriController = GameObject.Find("OmoriController");
        //Omoriscript = OmoriController.GetComponent<OmoriInfor>();
        //Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rb.isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {
        unitychanWeight = Targetscript.weight;
        //omoriWeight = Omoriscript.omoriMass;

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Character")
        {
            ObjectWeightList.Add(other.gameObject, unitychanWeight);
            Debug.Log("chara in");
        }

        TotalWeightCalc();

        if (totalWeight >= overWeight)
        {
            StartCoroutine("FloorDownCount");
        }


        /* if ((other.gameObject.tag == "Character" && (unitychanWeight >= overWeight) )|| (omoriWeight >= overWeight)){
              StartCoroutine("FloorDownCount");
             Debug.Log("in");

         }*/
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            //Debug.Log("お守りに触れた");
            int OmoriWeight = other.gameObject.GetComponent<OmoriInfor>().OmoriMass;
            ObjectWeightList.Add(other.gameObject, OmoriWeight);
        }

        TotalWeightCalc();

        if (totalWeight >= overWeight)
        {
            StartCoroutine("FloorDownCount");
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        ObjectWeightList.Remove(other.gameObject);
        TotalWeightCalc();
        if (totalWeight < overWeight)
        {
            StopCoroutine("FloorDownCount");


        }
        Debug.Log("chara out");
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        ObjectWeightList.Remove(other.gameObject);
        TotalWeightCalc();
        if (totalWeight < overWeight)
        {
            StopCoroutine("FloorDownCount");


        }
    }


    IEnumerator FloorDownCount()
    {//指定秒経過後に落ちる
        //ObjectWeightList.Clear();
        yield return new WaitForSeconds(timeToFall);
        rb.isKinematic = false;
        col.isTrigger = true;
        Debug.Log("down");
    }

    void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);
    }

    void TotalWeightCalc()
    {
        int ObjectWeight = 0;
        foreach (int Value in ObjectWeightList.Values)
        {
            ObjectWeight += Value;
        }
        totalWeight = ObjectWeight;
    }

    public void GetOmoriMassUpdate(GameObject OmoriUpdate, int OmoriUpdateValue)
    {
        ObjectWeightList[OmoriUpdate] = OmoriUpdateValue;
        TotalWeightCalc();
        if (totalWeight >= overWeight)
        {
            StartCoroutine("FloorDownCount");
        }
        if (totalWeight < overWeight)
        {
            StopCoroutine("FloorDownCount");
        }
    }

}
