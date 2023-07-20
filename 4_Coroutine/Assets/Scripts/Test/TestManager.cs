using UnityEngine;

public class TestManager : MonoBehaviour
{
    private static TestManager instance;
    public static TestManager Instance {
        get {
            if(instance == null)
            {
                instance = FindObjectOfType<TestManager>();

                if(instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    instance = obj.AddComponent<TestManager>();
                    Debug.Log("After TestManager Instance Assignment");
                }
            }

            return instance;
        }
    }

    private GameObject SomethingToReady;
    public GameObject SomethingPrefab;

    private void Awake()
    {
        Debug.Log("TestManager Awake Previous");
        Debug.Log($"Instacne State {instance}");
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

        // 초기화
        SomethingToReady = Instantiate(SomethingPrefab); // 요 부분에서 널레퍼가 뜨지 않을까? 라고 생각하게 됨
    }

    private void Update()
    {
        // TestManager.Instance 가 null이 될 상활 연출
        if(Input.GetKeyDown(KeyCode.Space))
            Destroy(gameObject);
    }

    public void Hello()
    {
        Debug.Log("Hello, World!");
    }
}
