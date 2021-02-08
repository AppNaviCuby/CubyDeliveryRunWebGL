using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect_scenechange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClickSceneChangeButton(){
        SceneManager.LoadScene("StageSelect_nobu");
    }
    }
