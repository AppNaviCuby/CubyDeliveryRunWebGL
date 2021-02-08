using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroClear : MonoBehaviour
{
    TargetManager targetManager;
    NextMover nextMover;
    // Start is called before the first frame update
    void Start()
    {
        targetManager = GameObject.Find("TargetManager").GetComponent<TargetManager>();
        nextMover = GameObject.Find("TargetManager").GetComponent<NextMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IntroManager.phase == Phase.Rule4)
        {
            foreach (var target in targetManager.targetList)
            {
                target.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            for(int i = 0; i < targetManager.goalList.Count; i++)
                {
                    Destroy(targetManager.goalList[i]);
                }
        }
    }

    void OnTriggerEnter2D(Collider2D thisTrigger)
    {
        if(thisTrigger.gameObject.tag =="Character")
        {
            nextMover.OnClick();
        }
    }
}
