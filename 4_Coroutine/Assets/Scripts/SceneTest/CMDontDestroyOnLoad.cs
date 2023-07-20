using UnityEngine;

public class CMDontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}