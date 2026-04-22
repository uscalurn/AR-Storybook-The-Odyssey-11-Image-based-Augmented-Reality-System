using System.Collections;
using UnityEngine;

public class TheSpacecraftFlewup: MonoBehaviour
{
    public float speed = 2f;                // Tốc độ bay lên
    public float delayBeforeFly = 3f;       // Thời gian khởi động trước khi bay
    public GameObject startEffect;          // Hiệu ứng khởi động (Particle System, Light...)

    private bool isFlying = false;

    void Start()
    {
        if (startEffect != null)
            startEffect.SetActive(true); // Bật hiệu ứng khởi động

        StartCoroutine(WaitAndFly());
    }

    IEnumerator WaitAndFly()
    {
        yield return new WaitForSeconds(delayBeforeFly); // Đợi 3s
        isFlying = true;

        if (startEffect != null)
            startEffect.SetActive(false); // Tắt hiệu ứng khi bắt đầu bay
    }

    void Update()
    {
        if (isFlying)
        {
            // Bay lên theo trục Y
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
