using System.Reflection;
using UnityEngine;
using System.Text;
using System;
using UnityEngine.SceneManagement;

public enum SceneName
{
    None = -1,
    Loading,
    Logo,
    Title,
    Game
}

public class MGScene : MonoBehaviour
{
    private static MGScene instance;
    public static MGScene Instance {
        get {
            if(instance == null)
            {
                instance = FindObjectOfType<MGScene>();
                if(instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    instance = obj.AddComponent<MGScene>();
                }
            }

            return instance;
        }
    }

    private StringBuilder sb;

    private SceneName currentScene;
    private SceneName beforeScene;
    
    private Transform uiRootTrm;    // UI 루트 -> 캔버스
    private Transform addUITrm;     // Root 밑에 추가되는 각 씬에 종속된 UI

    public GameObject uiRootPrefab;
    public GameObject loadingUIPrefab;
    public GameObject logoUIPrefab;
    public GameObject titleUIPrefab;
    public GameObject gameUIPrefab;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        sb = new StringBuilder();
        
        GameObject uiRootObj = GameObject.Instantiate(uiRootPrefab) as GameObject;
        uiRootTrm = uiRootObj.transform;

        InitScene();
    }

    public void Generate()
    {
        
    }

    private void InitScene()
    {
        beforeScene = SceneName.None;
        ChangeScene(SceneName.Logo);
    }

    public void ChangeScene(SceneName inScene, bool loading = true)
    {
        currentScene = inScene;

        if(loading)
        {
            sb.Remove(0, sb.Length);
            sb.AppendFormat("{0}Scene", SceneName.Loading);
            SceneManager.LoadScene(sb.ToString());
        }

        ChangeUI(SceneName.Loading);
    }

    private void ChangeUI(SceneName inScene)
    {
        if(addUITrm != null)
        {
            addUITrm.SetParent(null);
            GameObject.Destroy(addUITrm.gameObject);
        }

        GameObject go = null;
        if(inScene == SceneName.Loading)
            go = GameObject.Instantiate(loadingUIPrefab) as GameObject;
        else if(inScene == SceneName.Logo)
            go = GameObject.Instantiate(logoUIPrefab) as GameObject;
        else if(inScene == SceneName.Title)
            go = GameObject.Instantiate(titleUIPrefab) as GameObject;
        else if(inScene == SceneName.Game)
            go = GameObject.Instantiate(gameUIPrefab) as GameObject;

        addUITrm = go.transform;
        addUITrm.SetParent(uiRootTrm);

        addUITrm.localPosition = Vector3.zero;
        addUITrm.localScale = new Vector3(1, 1, 1);

        RectTransform rts = go.GetComponent<RectTransform>();
        rts.offsetMax = new Vector2(0, 0);
        rts.offsetMin = new Vector2(0, 0);
    }

    public void LoadingDone()
    {
        beforeScene = currentScene;

        ChangeUI(currentScene);

        Debug.Log("로딩 끝");
    }
}
