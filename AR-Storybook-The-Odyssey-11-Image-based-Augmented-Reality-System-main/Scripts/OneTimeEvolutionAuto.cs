using UnityEngine;

public class OneTimeEvolutionAuto : MonoBehaviour
{
    public GameObject firstEvolution;
    public GameObject secondEvolution;
    public float evolutionDelay = 5f; // Thời gian chờ (tính bằng giây)

    void Start()
    {
        // Khi bắt đầu, chỉ hiển thị quái vật ban đầu
        firstEvolution.SetActive(true);
        secondEvolution.SetActive(false);

        // Gọi hàm tiến hóa sau một khoảng thời gian
        Invoke("EvolveOnce", evolutionDelay);
    }

    void EvolveOnce()
    {
        firstEvolution.SetActive(false);
        secondEvolution.SetActive(true);
    }
}