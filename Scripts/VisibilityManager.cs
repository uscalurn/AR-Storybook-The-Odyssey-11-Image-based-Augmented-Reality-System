using System.Collections;
using UnityEngine;

public class VisibilityManager : MonoBehaviour
{
    // Kéo đối tượng cha (không có renderer) vào đây
    public GameObject objectToControl;
    public float delayTime = 10.0f;

    void Start()
    {
        if (objectToControl != null)
        {
            StartCoroutine(HideAndShowObject());
        }
        else
        {
            Debug.LogError("Chưa gán đối tượng để điều khiển!");
        }
    }

    IEnumerator HideAndShowObject()
    {
        // 1. Ẩn đối tượng cha (và tất cả con của nó)
        Debug.Log("Tắt đối tượng: " + objectToControl.name);
        objectToControl.SetActive(false);

        // 2. Chờ
        // Script này vẫn chạy vì nó nằm trên một đối tượng khác không bị tắt
        yield return new WaitForSeconds(delayTime);

        // 3. Hiện lại
        Debug.Log("Bật lại đối tượng: " + objectToControl.name);
        objectToControl.SetActive(true);
    }
}