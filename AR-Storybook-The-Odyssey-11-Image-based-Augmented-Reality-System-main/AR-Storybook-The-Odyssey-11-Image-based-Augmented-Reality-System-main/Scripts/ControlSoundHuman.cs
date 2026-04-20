using UnityEngine;
using System.Collections;

public class StateSoundController_human : MonoBehaviour
{
    [Header("Wave Sounds")]
    public AudioSource waveSource;
    public AudioClip waveClip1;
    public AudioClip waveClip2;

    public string waveStateName = "bitancong";

    public float delayBetweenClips = 1f; // thời gian im lặng giữa 2 clip

    private Animator animator;
    private bool isPlayingSequence = false;
    private bool hasPlayedSequence = false; // flag đánh dấu đã phát xong

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

        if (currentState.IsName(waveStateName))
        {
            if (!isPlayingSequence && !hasPlayedSequence)
            {
                StartCoroutine(PlayWaveSequence());
            }
        }
        else
        {
            // Ra khỏi state thì reset để có thể phát lại nếu vào lại state này
            if (isPlayingSequence)
            {
                StopAllCoroutines();
                waveSource.Stop();
            }
            isPlayingSequence = false;
            hasPlayedSequence = false;
        }
    }

    IEnumerator PlayWaveSequence()
    {
        isPlayingSequence = true;

        // Phát clip 1
        waveSource.clip = waveClip1;
        waveSource.Play();
        yield return new WaitForSeconds(waveClip1.length);

        // Im lặng
        yield return new WaitForSeconds(delayBetweenClips);

        // Phát clip 2
        waveSource.clip = waveClip2;
        waveSource.Play();
        yield return new WaitForSeconds(waveClip2.length);

        // Kết thúc sequence, đánh dấu đã phát xong
        isPlayingSequence = false;
        hasPlayedSequence = true;
    }
}
