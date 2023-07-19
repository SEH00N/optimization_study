using System.Text;
using UnityEngine;

public class GoodString : MonoBehaviour
{
    private string[] testStr = { "a", "b", "c", "d", "e" };

    private StringBuilder sb = new StringBuilder();

    private void Start()
    {
        sb.Clear();
    }

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
        sb.Clear();

        for(int i = 0; i < strArray.Length; i++)
            sb.Append(strArray[i]);

        return sb.ToString();
    }
}
