using System.Collections;
using UnityEngine;

public class Opposite : MonoBehaviour
{
    // Kéo đối tượng bạn muốn điều khiển vào đây
    public GameObject objectToControl;

    // Thời gian chờ trước khi đối tượng biến mất
    public float delayBeforeDisappearing = 10.0f;

    void Start()
    {
        // Đảm bảo đối tượng được bật lúc bắt đầu (phòng trường hợp nó bị tắt sẵn trong Editor)
        if (objectToControl != null)
        {
            objectToControl.SetActive(true);
            
            // Bắt đầu coroutine để đếm ngược và ẩn đối tượng
            StartCoroutine(DisappearAfterDelay());
        }
        else
        {
            Debug.LogError("Chưa gán đối tượng để điều khiển!");
        }
    }

    IEnumerator DisappearAfterDelay()
    {
        // 1. In một thông báo để biết coroutine đã bắt đầu (tốt cho việc gỡ lỗi)
        Debug.Log(objectToControl.name + " sẽ biến mất sau " + delayBeforeDisappearing + " giây.");

        // 2. CHỜ một khoảng thời gian TRƯỚC
        yield return new WaitForSeconds(delayBeforeDisappearing);

        // 3. Sau khi chờ xong, ẨN đối tượng đi
        Debug.Log("Đã đến lúc! Tắt đối tượng: " + objectToControl.name);
        objectToControl.SetActive(false);
    }
}