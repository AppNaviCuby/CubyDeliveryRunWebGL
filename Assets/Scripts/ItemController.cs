using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    AudioController audioController;
    TargetManager targetManager;
    // Start is called before the first frame update
    void Start()
    {
        targetManager = GameObject.Find("TargetManager").GetComponent<TargetManager>();
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D thisCollision)
    {
        if(thisCollision.gameObject.tag == "Character")
        {
            targetManager.gravityAdd(1);

            audioController.ItemGet();
            Destroy(this.gameObject);
        }
    }
}