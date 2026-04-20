using UnityEngine;

public class StateSoundController : MonoBehaviour
{
    [Header("Run")]
    public AudioSource runSource;
    public AudioClip runClip;
    public string runStateName = "Run";

    [Header("Attack")]
    public AudioSource attackSource;
    public AudioClip attackClip;
    public string attackStateName = "Attack";

    [Header("Hút sinh lực")]
    public AudioSource hutSource;
    public AudioClip hutClip;
    public string hutsinhlucStateName = "hutsinhluc";

    private Animator animator;
    private bool runSoundPlayed = false;
    private bool attackSoundPlayed = false;
    private bool hutSoundPlayed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

        // Run
        if (currentState.IsName(runStateName))
        {
            if (!runSoundPlayed)
            {
                runSource.clip = runClip;
                runSource.Play();
                runSoundPlayed = true;
            }
        }
        else
        {
            runSoundPlayed = false;
        }

        // Attack
        if (currentState.IsName(attackStateName))
        {
            if (!attackSoundPlayed)
            {
                attackSource.clip = attackClip;
                attackSource.Play();
                attackSoundPlayed = true;
            }
        }
        else
        {
            attackSoundPlayed = false;
        }

        // Hút sinh lực
        if (currentState.IsName(hutsinhlucStateName))
        {
            if (!hutSoundPlayed)
            {
                hutSource.clip = hutClip;
                hutSource.Play();
                hutSoundPlayed = true;
            }
        }
        else
        {
            hutSoundPlayed = false;
        }

    }
}
