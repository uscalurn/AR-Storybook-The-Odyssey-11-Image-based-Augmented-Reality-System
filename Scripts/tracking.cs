using UnityEngine;
using Vuforia;

public class ActivateOnTracking : MonoBehaviour
{
    private ObserverBehaviour observer;

    public GameObject objectToActivate;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;

    private AudioSource[] audioSources;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        if (objectToActivate != null)
        {
            originalPosition = objectToActivate.transform.localPosition;
            originalRotation = objectToActivate.transform.localRotation;
            originalScale = objectToActivate.transform.localScale;

            objectToActivate.SetActive(false);

            audioSources = objectToActivate.GetComponentsInChildren<AudioSource>(true);
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (objectToActivate == null) return;

        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            objectToActivate.transform.localPosition = originalPosition;
            objectToActivate.transform.localRotation = originalRotation;
            objectToActivate.transform.localScale = originalScale;

            objectToActivate.SetActive(true);

            foreach (var source in audioSources)
            {
                source.time = 0f;  // Xoá nếu muốn phát tiếp
                source.Play();
            }
        }
        else
        {
            foreach (var source in audioSources)
            {
                source.Stop();
            }

            objectToActivate.SetActive(false);
        }
    }
}
