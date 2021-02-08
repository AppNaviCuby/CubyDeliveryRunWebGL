using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroWeight : MonoBehaviour
{
    TargetManager targetManager;
    private int startTime, nowTime;
    // Start is called before the first frame update
    void Start()
    {
        targetManager = GameObject.Find("TargetManager").GetComponent<TargetManager>();
        startTime = (int)Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        nowTime = (int)Time.time;
        targetManager.gravityAdd((int)(((float)(nowTime - startTime) % 8.0f + 1.0f) / 2.0f + 0.5f));
    }
}