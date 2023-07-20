using System.Reflection;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public enum LoadingState
{
    None,
    Unload,
    GotoScene,
    Done
}

public class UILoading : MonoBehaviour
{
    private AsyncOperation unloadDone;
    private AsyncOperation loadLevelDone;

    private LoadingState myState;
    private StringBuilder sb;

    private float timeLimit;

    const string MainSceneStr = "MainScene";

    private void Awake()
    {
        sb = new StringBuilder();
    }

    private void Start()
    {
        myState = LoadingState.None;
        NextState();
    }

    private IEnumerator NoneState()
    {
        myState = LoadingState.Unload;

        while(myState == LoadingState.None)
            yield return null;

        NextState();
    }

    private IEnumerator UnloadState()
    {
        unloadDone = Resources.UnloadUnusedAssets();
        System.GC.Collect();

        while(myState == LoadingState.Unload)
        {
            if(unloadDone.isDone)
                myState = LoadingState.GotoScene;

            yield return null;
        }

        NextState();
    }
    
    private IEnumerator GotoSceneState()
    {
        loadLevelDone = SceneManager.LoadSceneAsync(MainSceneStr);

        timeLimit = 3.0f; // 최소 3초 이상 로딩화면을 보여준다

        while(myState == LoadingState.GotoScene)
        {
            timeLimit -= Time.deltaTime;
            if(loadLevelDone.isDone && timeLimit <= 0)
                myState = LoadingState.Done;

            yield return null;
        }

        NextState();
    }

    
    private IEnumerator DoneState()
    {
        MGScene.Instance.LoadingDone();

        while(myState == LoadingState.Done)
            yield return null;
    }

    private void NextState()
    {
        sb.Remove(0, sb.Length);
        sb.Append(myState.ToString());
        sb.Append("State");

        MethodInfo mInfo = this.GetType().GetMethod(sb.ToString(), BindingFlags.Instance | BindingFlags.NonPublic);
        StartCoroutine((IEnumerator)mInfo.Invoke(this, null));
    }
}
