using UnityEngine;

public class GrannyControls : MonoBehaviour
{
    Animator anim;
    float speed = 0.1f;

    private readonly int RunningHash = Animator.StringToHash("running");

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool(RunningHash, true);
            this.transform.position += this.transform.forward * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool(RunningHash, true);
            this.transform.position -= this.transform.forward * speed;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool(RunningHash, false);
        }
    }
}
