using UnityEngine;

public class Run : MonoBehaviour
{
    public Animator animator;
    public float tocDo = 2f;
    public string allowedStateName = "Run";  // Chỉ cho phép di chuyển khi animation là Run

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName(allowedStateName))
        {
            transform.Translate(Vector3.forward * tocDo * Time.deltaTime);
        }
    }
}
