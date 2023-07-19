using UnityEngine;

public class BadString : MonoBehaviour
{
    private string[] testStr = { "a", "b", "c", "d", "e" };

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < 1000; i++)
            {
                ConcatExample(testStr);
            }        
        }
    }

    private string ConcatExample(string[] strArray)
    {
        string result = "";

        for(int i = 0; i < strArray.Length; i++)
            result += strArray[i];

        return result;
    }
}
