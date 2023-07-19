using UnityEngine;

public class DummyGCTest : MonoBehaviour
{
    private void Update()
    {
        CreateTanks();
        
        DestroyTanks();
    }

    private void CreateTanks()
    {
        for(int i = 0; i < 100; i ++)
        {
            GameObject tankObj = new GameObject();
            tankObj.tag = "tank";
        }
    }

    private void DestroyTanks()
    {
        GameObject[] tankObjs = GameObject.FindGameObjectsWithTag("tank");
        for(int i = 0; i < 100; i ++)
        {
            Destroy(tankObjs[i]);
        }
    }
}
