using System.Collections;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CoroutineCaching : MonoBehaviour
{
    public int maxSpawnCount = 100;
    public float spawnDelay = 0.1f;
    public GameObject cubeObjPrefab;

    private int spawnCount;
    private Vector3 randomPos;
    private GameObject newCube;

    private WaitForSeconds spawnWFS;
    private Coroutine spawnCoVal;

    private Stopwatch stopWatch = new Stopwatch();
    
    private void Start()
    {
        spawnWFS = new WaitForSeconds(spawnDelay);
        spawnCoVal = null;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(spawnCoVal == null)
                spawnCoVal = StartCoroutine(SpawnCo());
        }
    }

    private IEnumerator SpawnCo()
    {
        Debug.Log("큐브 생성 테스트 시작!");

        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);

        stopWatch.Reset();
        stopWatch.Start();

        spawnCount = maxSpawnCount;

        while(spawnCount > 0)
        {
            randomPos = new Vector3(Random.value, Random.value, Random.value);
            newCube = Instantiate(cubeObjPrefab, randomPos, Quaternion.identity);

            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
            newCube.transform.SetParent(this.transform);

            yield return spawnWFS;

            spawnCount--;
        }

        stopWatch.Stop();
        spawnCoVal = null;

        Debug.Log($"{stopWatch.ElapsedMilliseconds / 1000}초 걸림");
    }
}
