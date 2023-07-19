using UnityEngine;

public class DummyObjectCreator : MonoBehaviour
{
    public int numberOfObjects;
    
    private GameObject dummyObj;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            CreateObjects();
        if(Input.GetKeyUp(KeyCode.Space))
            DestroyObjects();
    }

    private void CreateObjects()
    {
        for(int i = 0; i < numberOfObjects; i++)
        {
            dummyObj = new GameObject("A_Dummy");
            dummyObj.tag = "Player";
        }
    }

    private void DestroyObjects()
    {
        GameObject[] dummies = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject go in dummies)
            Destroy(go);
    }
}
