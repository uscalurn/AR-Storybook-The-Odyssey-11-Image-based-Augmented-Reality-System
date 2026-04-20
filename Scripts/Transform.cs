using UnityEngine;
using System.Collections;

public class AnimationStateWatcher : MonoBehaviour
{
    [Header("References")]
    public Animator animator;
    public GameObject monster;       // GameObject quái vật ban đầu
    public GameObject phiHanhGia;    // GameObject phi hành gia sau khi biến hình

    [Header("Tên các Animation State")]
    public string hutSinhLucState = "hutsinhluc";
    public string bienHinhState = "bienhinh";

    private bool hasStartedBienHinh = false;
    private bool hasShownPhiHanhGia = false;

    void Update()
    {
        if (animator == null) return;

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // (1) Khi animation đang là "hutsinhluc" và chưa chuyển sang "bienhinh"
        if (!hasStartedBienHinh && stateInfo.IsName(hutSinhLucState) && stateInfo.normalizedTime >= 1f)
        {
            animator.Play(bienHinhState);       // chuyển animation
            hasStartedBienHinh = true;
        }

        // (2) Khi animation đang là "bienhinh" và chưa hiện phi hành gia
        if (!hasShownPhiHanhGia && stateInfo.IsName(bienHinhState) && stateInfo.normalizedTime >= 1f)
        {
            StartCoroutine(DelayShowPhiHanhGia(1f));  // delay 1 giây trước khi show
            hasShownPhiHanhGia = true;
        }
    }

    IEnumerator DelayShowPhiHanhGia(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Làm mờ quái vật
        if (monster != null)
        {
            var renderer = monster.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color color = renderer.material.color;
                color.a = 0.3f; // làm mờ đi
                renderer.material.color = color;
            }
        }

        // Hiện phi hành gia
        if (phiHanhGia != null)
        {
            phiHanhGia.SetActive(true);
        }
    }
}
