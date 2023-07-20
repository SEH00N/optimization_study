using UnityEngine;

public class TestSingleton : MonoBehaviour
{
    private void Update()
    {
        // TestManager.Instance 호출
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            TestManager.Instance.Hello();
        }
    }
}
