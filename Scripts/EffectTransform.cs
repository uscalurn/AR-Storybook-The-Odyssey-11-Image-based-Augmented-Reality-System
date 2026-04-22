using UnityEngine;
using System.Collections;

public class EffectTransform : MonoBehaviour
{
    public float speed = 0f;                   // Tốc độ di chuyển
    public float delayBeforeSwitch = 2f;       // Thời gian chờ trước khi biến hình
    public GameObject effectObject;            // Hiệu ứng particle hoặc object effect

    private Transform monsterTransform;
    private Transform humanTransform;
    private Renderer monsterRenderer;
    private Color originalColor;

    private float timer = 0f;
    private bool hasSwitched = false;

    void Awake()
    {
        // Lấy tham chiếu đến các transform
        monsterTransform = transform.Find("monster");
        humanTransform = transform.Find("human");

        if (monsterTransform != null)
        {
            monsterRenderer = monsterTransform.GetComponentInChildren<Renderer>();
            if (monsterRenderer != null)
            {
                originalColor = monsterRenderer.material.color;
            }
        }
    }

    void OnEnable()
    {
        // Mỗi lần object được kích hoạt lại (ví dụ do Vuforia tracking lại)
        ResetState();
    }

    void Update()
    {
        transform.position -= transform.right * speed * Time.deltaTime;

        if (!hasSwitched)
        {
            timer += Time.deltaTime;

            if (timer >= delayBeforeSwitch)
            {
                StartCoroutine(SwitchWithEffect());
                hasSwitched = true;
            }
        }
    }

    IEnumerator SwitchWithEffect()
    {
        // Bật hiệu ứng
        if (effectObject != null)
            effectObject.SetActive(true);

        yield return new WaitForSeconds(1f); // Thời gian hiệu ứng

        // Chuyển đổi: tắt monster, bật human
        if (monsterTransform != null)
            monsterTransform.gameObject.SetActive(false);
        if (humanTransform != null)
            humanTransform.gameObject.SetActive(true);

        // Tắt hiệu ứng sau khi chuyển đổi
        if (effectObject != null)
            effectObject.SetActive(false);
    }

    void ResetState()
    {
        timer = 0f;
        hasSwitched = false;

        if (monsterTransform != null)
            monsterTransform.gameObject.SetActive(true);
        if (humanTransform != null)
            humanTransform.gameObject.SetActive(false);
        if (effectObject != null)
            effectObject.SetActive(false);
    }
}
