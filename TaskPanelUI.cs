using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TaskPanelUI : MonoBehaviour
{
    public PigChef pigChef;
    public TextMeshProUGUI ironText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI buildText;

    private int ironPriority=4;
    private int stonePriority=4;
    private int woodPriority=4; 
    private int buildPriority=4; 

    private void Awake()
    {
        ironText.text=ironPriority.ToString();
        stoneText.text=stonePriority.ToString();
        woodText.text=woodPriority.ToString();
        buildText.text=buildPriority.ToString();
    }
    
    public void OnClickIron(){
        ironPriority--;
        if(ironPriority==0){
            ironPriority=4;
        }
        ironText.text=ironPriority.ToString();
        pigChef.ChangePriorityIron(ReverseInt(ironPriority));
    }

    public void OnClickStone(){
        stonePriority--;
        if(stonePriority==0){
            stonePriority=4;
        }
        stoneText.text=stonePriority.ToString();
        pigChef.ChangePriorityStone(ReverseInt(stonePriority));
    }

    public void OnClickWood(){
        woodPriority--;
        if(woodPriority==0){
            woodPriority=4;
        }
        woodText.text=woodPriority.ToString();
        pigChef.ChangePriorityWood(ReverseInt(woodPriority));
    }

    public void OnClickBuild(){
        buildPriority--;
        if(buildPriority==0){
            buildPriority=4;
        }
        buildText.text=buildPriority.ToString();
        pigChef.ChangePriorityBuild(ReverseInt(buildPriority));
    }

    private int ReverseInt(int tempInt){
        if(tempInt==4){
            return 1;
        }else if (tempInt==3){
            return 2;
        }else if (tempInt==2){
            return 3;
        }else if(tempInt==1){
            return 4;
        }else return 4;
    }
}
