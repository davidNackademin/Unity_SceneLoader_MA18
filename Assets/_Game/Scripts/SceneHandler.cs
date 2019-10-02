using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public GameObject whiteSquare;
    public float fadeSpeed = 1.5f;
    SpriteRenderer whiteSquareRenderer;
    public string levelToLoad;

    private static SceneHandler _instance;

    public static SceneHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Instantiate(Resources.Load<GameObject>("SceneHandler"))
                    .GetComponent<SceneHandler>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        whiteSquare.SetActive(false);
        whiteSquareRenderer = whiteSquare.GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        FadeFromWhite();
      
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {

        if( SceneManager.GetActiveScene().name == "LoadingScene")
        {
            StartCoroutine(LoadLevelAndChange(levelToLoad));
        } else
        {
            FadeFromWhite();
        }   
    }

    //public void OnEnterLoadingScene()
    //{
    //    Debug.Log("LoadingScene");
    //}

    IEnumerator LoadLevelAndChange(string levelName)
    {
        whiteSquare.SetActive(false);
        yield return null;

        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
        async.allowSceneActivation = false;

        yield return new WaitForSeconds(3);

        async.allowSceneActivation = true;
       
    }

    void FadeFromWhite()
    {
        Color color = whiteSquareRenderer.color;
        color.a = 1;
        whiteSquareRenderer.color = color;
        whiteSquare.SetActive(true);
        LeanTween.alpha(whiteSquare, 0, fadeSpeed).setEaseInCubic()
            .setOnComplete(() => {
                whiteSquare.SetActive(false);
            });


    }


    public void ChangeLevelTo(string levelName)
    {
        levelToLoad = levelName;
        Color color = whiteSquareRenderer.color;
        color.a = 0;
        whiteSquareRenderer.color = color;
        whiteSquare.SetActive(true);
        LeanTween.alpha(whiteSquare, 1, fadeSpeed).setEaseInCubic()
            .setOnComplete(() => {
                SceneManager.LoadScene("LoadingScene");
            });
    }




}
