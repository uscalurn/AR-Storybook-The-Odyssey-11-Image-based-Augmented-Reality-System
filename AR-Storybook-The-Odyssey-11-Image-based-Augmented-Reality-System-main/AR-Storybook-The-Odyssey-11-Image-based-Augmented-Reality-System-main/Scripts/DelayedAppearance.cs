using UnityEngine;
using System.Collections;

public class DelayedAppearance : MonoBehaviour
{
    // Biến để bạn có thể chỉnh thời gian chờ trong Inspector của Unity
    public float delayInSeconds = 1.0f;

    // Hàm này được gọi ngay khi object được khởi tạo trong game
    void Start()
    {
        // 1. Ẩn object này đi ngay lúc đầu
        gameObject.SetActive(false);

        // 2. Bắt đầu Coroutine để đếm ngược thời gian
        StartCoroutine(ShowObjectAfterDelay());
    }

    // Đây là Coroutine (một hàm có thể tạm dừng)
    IEnumerator ShowObjectAfterDelay()
    {
        // 3. Chờ một khoảng thời gian (delayInSeconds)
        yield return new WaitForSeconds(delayInSeconds);

        // 4. Sau khi chờ xong, kích hoạt lại object để nó xuất hiện
        gameObject.SetActive(true);
    }
}