using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{

    public GameObject Unitychan;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StageSelectOfTitleButtonClicked()
    {
        SceneManager.LoadScene("StageSelect_nobu");
    }
    public void GoToFirstStageButtonClicked()
    {
        SceneManager.LoadScene("weightStage");
    }
    public void OnRuleClick()
    {
        SceneManager.LoadScene("Rule");
    }
    public void OnTitleClick()
    {
        SceneManager.LoadScene("Title");
    }
}