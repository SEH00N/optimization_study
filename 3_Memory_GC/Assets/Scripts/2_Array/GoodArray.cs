using UnityEngine;

public class GoodArray : MonoBehaviour
{
    [SerializeField]
    private float[] randResultVal;

    private void Start()
    {
        randResultVal = new float[10000];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            RandomList(randResultVal);
    }

    private void RandomList(float[] arrayToFill)
    {
        for(int i = 0; i < arrayToFill.Length; i++)
            arrayToFill[i] = Random.value;
    }
}
