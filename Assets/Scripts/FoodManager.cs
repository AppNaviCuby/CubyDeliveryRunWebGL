using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    TargetManager targetManager;
    AudioController audioController;

    bool foodTouchFlag = false;

    // Start is called before the first frame updat
    void Start()
    {
        targetManager = GameObject.Find("TargetManager").GetComponent<TargetManager>();
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Sprite thisFood = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        //衝突判定
        if (other.gameObject.tag == "Character" && foodTouchFlag == false)
        {
            targetManager.gravityAdd(targetManager.weight + 1);
            Debug.Log("food touch");
            //当たった時にtargetListと比較し正誤判定
            //Debug.Log("判定開始");
            targetManager.targetJudge(thisFood);
            //Debug.Log("判定終了");
            foodTouchFlag = true;
            audioController.FoodGet();
            //this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //判定後重さ+1して自分を消す
            Destroy(this.gameObject);
        }
    }
    /*void OnCollisionEnter2D(Collision2D thisCollision)
    {
        Sprite thisFood = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        //衝突判定
        if (thisCollision.gameObject.tag == "Character")
        {
            targetManager.gravityAdd(targetManager.weight + 1);
            Debug.Log("food touch");
            //当たった時にtargetListと比較し正誤判定
            //Debug.Log("判定開始");
            targetManager.targetJudge(thisFood);
            //Debug.Log("判定終了");

            audioController.FoodGet();
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //判定後重さ+1して自分を消す
            Destroy(this.gameObject);
        }
    }*/
}