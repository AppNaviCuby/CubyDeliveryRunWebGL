using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectController : MonoBehaviour
{
    string[] StageList = new string[15] { "weightStage", "ItemStage", "PushStage", "kuzureruStage", "Stage1"
    ,"Nobu_Stage1","hiroStage","Stage_naru","Guchi_Stage2","Stage_naru3","Nobu_Stage2","Stage_naru2","Guchi_Stage1","hiro2stage","Guchi_Stage3" };















    public static int StageNumber = 0;
    void Start()
    {

    }
    public void StageSelectButtonClicked(int number)
    {
        StageNumber = number;
        SceneManager.LoadScene(StageList[StageNumber - 1]);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
