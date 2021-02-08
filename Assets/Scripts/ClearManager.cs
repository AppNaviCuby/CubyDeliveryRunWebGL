using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    public GameObject clearPanel,tutorialPanel;
    AudioController audioController;

    //public GameObject MenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    // Update is called once per frame

/*　
void MenuConsole()
    {
        MenuPanel.SetActive(true);
    }
    */

    void OnTriggerEnter2D(Collider2D thisTrigger)
    {
        if(thisTrigger.gameObject.tag =="Character")
        {
            audioController.ClearSound();
            if(tutorialPanel != null)
            {
                tutorialPanel.SetActive(false);
            }
            clearPanel.SetActive(true);
        }
    
    }

     /*
     void Update()
    {
         if (Input.GetKeyDown(KeyCode.A)) {
           　　MenuConsole();
            
        }
    }
    */
}
