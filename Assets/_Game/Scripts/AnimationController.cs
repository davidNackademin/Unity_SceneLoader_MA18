using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public GameObject greenSquare;
    public GameObject blueSquare;
    public GameObject yellowSquare;
    public GameObject redSquare;

    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //LeanTween.scale(gameObject, transform.localScale * 2.0f, 2.0f).setEaseOutElastic()
        //    //.setOnComplete(() => {
        //    //    LeanTween.scale(gameObject, transform.localScale * 0.5f, 2.0f).setEaseInElastic();
        //    //});
        //    .setOnComplete(ScaleDown);
        Animation();
    }

    //void ScaleDown()
    //{
    //    LeanTween.scale(gameObject, transform.localScale * 0.5f, 2.0f).setEaseInElastic();

    //}

    void Animation()
    {
        LeanTween.move(greenSquare, blueSquare.transform.position, speed).setEaseInOutCubic();
        LeanTween.move(blueSquare, yellowSquare.transform.position, speed).setEaseInOutCubic();
        LeanTween.move(yellowSquare, redSquare.transform.position, speed).setEaseInOutCubic();
        LeanTween.move(redSquare, greenSquare.transform.position, speed).setEaseInOutCubic()
            .setOnComplete(Animation);

    }


}
