﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKey(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
        }*/
    }

    public void OnCloseClick()
    {
        gameObject.SetActive(false);
    }
}