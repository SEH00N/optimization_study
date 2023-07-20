using System;
using System.Text;
using UnityEngine;

public class SpeedTest : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StringDemoFunc();
        }
    }

    private void StringDemoFunc()
    {
        //string s = "";
        StringBuilder sb = new StringBuilder();

        Debug.Log($"StartTime : {DateTime.Now.ToLongTimeString()}");

        for(int i = 0; i < 100000; i++)
            sb.Append("Hi ");

        Debug.Log($"EndTime : {DateTime.Now.ToLongTimeString()}");
        Debug.Log(sb);
    }
}
