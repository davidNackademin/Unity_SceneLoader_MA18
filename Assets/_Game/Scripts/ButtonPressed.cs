using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{

    public string nextLevel;

    private void Start()
    {
       var tmp =  SceneHandler.Instance;
    }


    //public SceneHandler sceneHandler;

    private void OnMouseDown()
    {
        SceneHandler.Instance.ChangeLevelTo(nextLevel);
        //sceneHandler.ChangeLevelTo("Level2");
    }


}
