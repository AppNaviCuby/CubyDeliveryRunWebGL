using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    public List<GameObject> targetList = new List<GameObject>();
    [HideInInspector]public List<Sprite> targetSpriteList = new List<Sprite>();
    public List<GameObject> goalList = new List<GameObject>();
    public int longth, weight, gotTarget = 0;
    public Text weightText;
    MoveCharacterAction moveCharacterAction;

    // Start is called before the first frame update
    void Start()
    {
        moveCharacterAction = GameObject.FindGameObjectWithTag("Character").GetComponent<MoveCharacterAction>();

        weight = 1;
        longth = targetList.Count;
        for(int i=0;i < longth;i++)
        {
            targetSpriteList.Add(targetList[i].GetComponent<Image>().sprite);
        }
        //Debug.Log(targetSpriteList.Count);

    }

    // Update is called once per frame
    void Update()
    {
        weightText.text = "重さ：" +weight;
    }

    public void targetJudge(Sprite thisFood)
    {
        for(int i = 0; i < longth; i++)
        {
            if(thisFood == targetSpriteList[i])
            {
                targetList[i].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                gotTarget++;
            }

            //すべてのtargetを集めたらゴールが開く
            if(gotTarget == longth)
            {
                for(int j = 0; j < goalList.Count; j++)
                {
                    Destroy(goalList[j]);
                }
            }
        }

        //Debug.Log(falseNumber+ "回間違えた");
    }
    public int gravityAdd(int nowWeight)
    {
        weight = nowWeight;
        for(int i = 1; i< weight + 1; i++)
        {
            if(weight ==1)
            {
                moveCharacterAction.jumpHight = 8;
                break;
            }
            if(weight ==2)
            {
                moveCharacterAction.jumpHight = 7;
                break;
            }
            if(weight ==3)
            {
                moveCharacterAction.jumpHight = 5;
                break;
            }
            if(weight ==4)
            {
                moveCharacterAction.jumpHight = 3;
                break;
            }
            
        }

        return moveCharacterAction.jumpHight;
    }
}
