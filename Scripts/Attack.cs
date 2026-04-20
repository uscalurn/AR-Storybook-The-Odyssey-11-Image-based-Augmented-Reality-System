using UnityEngine;

public class NgaBayVaXoay : MonoBehaviour
{
    public Animator animator;

    public string ngaStateName = "bitancong";

    public float moveForward = 2f;     // Di chuyển về trước (tạm thay thế force)
    public float moveUp = 1f;          // Di chuyển lên
    public float rotateSpeed = 180f;   // Tốc độ xoay (độ/giây)
    public float maxRotateAngle = 80f; // Góc xoay tối đa

    private bool isNga = false;
    private float currentAngle = 0f;
    private Vector3 velocity;
    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.localRotation;
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName(ngaStateName))
        {
            if (!isNga)
            {
                isNga = true;
                // Gán vận tốc mô phỏng lực đẩy lên và ra trước
                velocity = transform.forward * moveForward + Vector3.up * moveUp;
            }

            // Di chuyển theo velocity mô phỏng lực bay
            transform.position += velocity * Time.deltaTime;

            // Xoay dần dần
            float deltaAngle = rotateSpeed * Time.deltaTime;
            currentAngle = Mathf.Min(currentAngle + deltaAngle, maxRotateAngle);
            Quaternion targetRotation = startRotation * Quaternion.Euler(currentAngle, 0f, 0f);
            transform.localRotation = targetRotation;
        }
        else
        {
            if (isNga)
            {
                // Reset trạng thái sau khi rời khỏi animation "bitancong"
                isNga = false;
                currentAngle = 0f;
                transform.localRotation = startRotation;
                velocity = Vector3.zero;
            }
        }
    }
}
