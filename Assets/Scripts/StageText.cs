using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    string[] StageList = new string[15] { "weightStage", "ItemStage", "PushStage", "kuzureruStage", "Stage1"
    ,"Nobu_Stage1","hiroStage","Stage_naru","Guchi_Stage2","Stage_naru3","Nobu_Stage2","Stage_naru2","Guchi_Stage1","hiro2stage","Guchi_Stage3" };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<15;i++){
            if(SceneManager.GetActiveScene().name==StageList[i]){
                text.text="Stage "+(i+1);
            }
        }
    }
}
