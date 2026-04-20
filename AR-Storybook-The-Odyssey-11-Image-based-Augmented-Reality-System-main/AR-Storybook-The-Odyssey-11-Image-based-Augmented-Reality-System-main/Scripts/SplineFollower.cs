using UnityEngine;
using UnityEngine.Splines; // Cần thêm dòng này để dùng Spline

public class SplineFollower : MonoBehaviour
{
    // Tham chiếu đến Spline trong scene
    public SplineContainer splineContainer;

    // Tốc độ di chuyển
    public float speed = 5f;

    // Biến để theo dõi tiến trình di chuyển trên spline (từ 0 đến 1)
    private float distanceTravelled = 0f;

    void Update()
    {
        if (splineContainer == null)
        {
            return;
        }

        // Tăng khoảng cách đã đi được theo thời gian và tốc độ
        distanceTravelled += speed * Time.deltaTime;

        // Lấy độ dài của toàn bộ spline
        float splineLength = splineContainer.CalculateLength();

        // Chuẩn hóa tiến trình (từ 0 đến 1)
        // Dùng toán tử modulo (%) để lặp lại khi đi hết đường
        float progress = Mathf.Repeat(distanceTravelled, splineLength) / splineLength;

        // Lấy vị trí và hướng tại điểm tiến trình trên spline
        Vector3 currentPosition = splineContainer.EvaluatePosition(progress);
        Vector3 nextPosition = splineContainer.EvaluatePosition(Mathf.Repeat(distanceTravelled + 0.1f, splineLength) / splineLength);

        // Cập nhật vị trí của object
        transform.position = currentPosition;

        // (Tùy chọn) Làm cho object luôn hướng về phía trước của đường đi
        transform.rotation = Quaternion.LookRotation(nextPosition - currentPosition);
    }
}