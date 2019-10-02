using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{


    public SceneHandler sceneHandler;

    private void OnMouseDown()
    {
        sceneHandler.ChangeLevelTo("Level2");
    }


}
