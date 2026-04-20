using UnityEngine;

public class RotateAroundBlueAxis : MonoBehaviour
{
    [Tooltip("Tốc độ xoay theo độ mỗi giây.")]
    public float rotationSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Xoay đối tượng quanh trục Y cục bộ của nó (mũi tên màu xanh lá).
        // Vector3.up là một cách viết tắt cho new Vector3(0, 1, 0).
        // Time.deltaTime đảm bảo rằng việc xoay diễn ra mượt mà và độc lập với tốc độ khung hình.
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}