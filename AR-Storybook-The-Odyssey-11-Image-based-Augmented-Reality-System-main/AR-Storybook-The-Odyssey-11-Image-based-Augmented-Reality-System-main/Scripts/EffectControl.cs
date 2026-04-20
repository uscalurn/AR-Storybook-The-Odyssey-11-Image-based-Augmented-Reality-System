using UnityEngine;

public class StateEffectTriggerhuman : MonoBehaviour
{
    public string waveStateName = "bitancong";   // Tên state cần kiểm tra
    public GameObject effectHitObject;           // Gán object con "effecthit" vào đây

    private Animator animator;
    private bool isEffectPlaying = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (effectHitObject != null)
        {
            effectHitObject.SetActive(false); // Ẩn effect từ đầu
        }
    }

    void Update()
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

        if (currentState.IsName(waveStateName))
        {
            if (!isEffectPlaying)
            {
                StartCoroutine(PlayEffectTwice());
            }
        }
        else
        {
            isEffectPlaying = false; // Cho phép chạy lại nếu quay lại state
        }
    }

    System.Collections.IEnumerator PlayEffectTwice()
    {
        isEffectPlaying = true;

        // Lần 1
        if (effectHitObject != null)
        {
            effectHitObject.SetActive(true);
            yield return new WaitForSeconds(0.2f); // Hiển thị một lúc
            effectHitObject.SetActive(false);
        }

        // Đợi 1.5s
        yield return new WaitForSeconds(4f);

        // Lần 2
        if (effectHitObject != null)
        {
            effectHitObject.SetActive(true);
            yield return new WaitForSeconds(0.2f); // Hiển thị một lúc
            effectHitObject.SetActive(false);
        }

        // Kết thúc hiệu ứng
        isEffectPlaying = false;
    }
}
