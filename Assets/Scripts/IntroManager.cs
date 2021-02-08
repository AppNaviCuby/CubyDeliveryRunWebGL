using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Phase
{
    Rule1, Rule2, Rule3, Rule4, Menu, normal
}
public class IntroManager : MonoBehaviour
{
    public static Phase phase;
    [SerializeField] private List<GameObject> panelList;
    [SerializeField] private bool isRule;
    private Phase tempPhase;

    // Start is called before the first frame update
    void Start()
    {
        if(isRule)
        {
            phase = Phase.Rule1;
        }else
        {
            phase = Phase.normal;
        }

        foreach (var panel in panelList)
        {
            panel.SetActive(false);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        switch (phase)
        {
            case Phase.Rule1:
                panelList[(int)Phase.Rule1].SetActive(true);
                panelList[(int)Phase.Rule2].SetActive(false);
                panelList[(int)Phase.Rule3].SetActive(false);
                panelList[(int)Phase.Rule4].SetActive(false);
                panelList[(int)Phase.Menu].SetActive(false);
                break;
            case Phase.Rule2:
                panelList[(int)Phase.Rule1].SetActive(false);
                panelList[(int)Phase.Rule2].SetActive(true);
                panelList[(int)Phase.Rule3].SetActive(false);
                panelList[(int)Phase.Rule4].SetActive(false);
                panelList[(int)Phase.Menu].SetActive(false);
                break;
            case Phase.Rule3:
                panelList[(int)Phase.Rule1].SetActive(false);
                panelList[(int)Phase.Rule2].SetActive(false);
                panelList[(int)Phase.Rule3].SetActive(true);
                panelList[(int)Phase.Rule4].SetActive(false);
                panelList[(int)Phase.Menu].SetActive(false);
                break;
            case Phase.Rule4:
                panelList[(int)Phase.Rule1].SetActive(false);
                panelList[(int)Phase.Rule2].SetActive(false);
                panelList[(int)Phase.Rule3].SetActive(false);
                panelList[(int)Phase.Rule4].SetActive(true);
                panelList[(int)Phase.Menu].SetActive(false);
                break;
            case Phase.Menu:
                panelList[(int)Phase.Rule1].SetActive(false);
                panelList[(int)Phase.Rule2].SetActive(false);
                panelList[(int)Phase.Rule3].SetActive(false);
                panelList[(int)Phase.Rule4].SetActive(false);
                panelList[(int)Phase.Menu].SetActive(true);
                break;
            case Phase.normal:
                panelList[(int)Phase.Rule1].SetActive(false);
                panelList[(int)Phase.Rule2].SetActive(false);
                panelList[(int)Phase.Rule3].SetActive(false);
                panelList[(int)Phase.Rule4].SetActive(false);
                panelList[(int)Phase.Menu].SetActive(false);
                break;
        }
    }

    public void OnButtonClick(int pase)
    {
        if(pase == 1)   phase = Phase.Rule1;
        if(pase == 2)   phase = Phase.Rule2;
        if(pase == 3)   phase = Phase.Rule3;
        if(pase == 4)   phase = Phase.Rule4;
        if(pase == 0)   phase = Phase.Menu;
        if(pase == 5)   phase = Phase.normal;
    }
}
