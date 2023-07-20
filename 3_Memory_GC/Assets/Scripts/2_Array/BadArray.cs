using UnityEngine;

public class BadArray : MonoBehaviour
{
    [SerializeField]
    private float[] randResultVal;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            randResultVal = RandomList(10000);
    }

    private float[] RandomList(int count)
    {
        float[] result = new float[count];

        for(int i = 0; i < count; i++)
            result[i] = Random.value;

        return result;
    }
}
