using UnityEngine;

public class PerformanceTesting : MonoBehaviour
{
    const int numberOfTests = 5000;
    private Transform testTrm = null;
    
    private void Update()
    {
        PerformanceTest1();
        PerformanceTest2();
        PerformanceTest3();
    }

    private void PerformanceTest1()
    {
        for(int i = 0; i < numberOfTests; i++)
            testTrm = GetComponent<Transform>();
    }

    private void PerformanceTest2()
    {
        for(int i = 0; i < numberOfTests; i++)
            testTrm = (Transform)GetComponent("Transform");
            // testTrm = GetComponent("Transform").transform.transform.transform.transform.transform.transform.transform.transform;
    }

    private void PerformanceTest3()
    {
        for(int i = 0; i < numberOfTests; i++)
            testTrm = (Transform)GetComponent(typeof(Transform));
    }
}
