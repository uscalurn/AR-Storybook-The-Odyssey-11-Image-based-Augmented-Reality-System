using System.Collections;
using UnityEngine;

public class RetreatAfterHutSinhLuc : MonoBehaviour
{
    public Animator animator;
    public string hutsinhlucStateName = "hutsinhluc";
    public float retreatDistance = 2f;  // Khoảng cách lùi
    public float retreatDuration = 0.5f; // Thời gian di chuyển lùi
    private bool isRetreating = false;

    void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.IsName(hutsinhlucStateName) && !isRetreating)
        {
            isRetreating = true;
            StartCoroutine(RetreatAfterDelay(1f));
        }

        // Reset cờ khi animation khác
        if (!state.IsName(hutsinhlucStateName))
        {
            isRetreating = false;
        }
    }

    IEnumerator RetreatAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos - transform.forward * retreatDistance;

        float elapsed = 0f;
        while (elapsed < retreatDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / retreatDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
    }
}
