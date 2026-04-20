using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ResetWhenTracked : MonoBehaviour
{
    private Dictionary<Transform, Vector3> originalPositions = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, Quaternion> originalRotations = new Dictionary<Transform, Quaternion>();
    private Dictionary<GameObject, bool> originalActives = new Dictionary<GameObject, bool>();
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();

    private ObserverBehaviour observerBehaviour;
    private bool hasSaved = false;

    public GameObject objectToControl;

    void Awake()
    {
        observerBehaviour = GetComponentInParent<ObserverBehaviour>();
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        if (objectToControl == null)
            objectToControl = this.gameObject;
    }

    void OnDestroy()
    {
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            if (!hasSaved)
            {
                SaveOriginalState();
                hasSaved = true;
            }

            ResetTransforms();
            RestoreActiveStates();

            if (objectToControl != null && !objectToControl.activeSelf)
                objectToControl.SetActive(true);
        }
        else
        {
            if (objectToControl != null && objectToControl.activeSelf)
                objectToControl.SetActive(false);
        }
    }

    void SaveOriginalState()
    {
        originalPositions.Clear();
        originalRotations.Clear();
        originalActives.Clear();
        rigidbodies.Clear();

        foreach (Transform child in GetComponentsInChildren<Transform>(true)) // include inactive
        {
            originalPositions[child] = child.localPosition;
            originalRotations[child] = child.localRotation;
            originalActives[child.gameObject] = child.gameObject.activeSelf;

            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
                rigidbodies.Add(rb);
        }
    }

    void ResetTransforms()
    {
        foreach (var rb in rigidbodies)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        foreach (Transform t in originalPositions.Keys)
        {
            t.localPosition = originalPositions[t];
            t.localRotation = originalRotations[t];
        }

        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
    }

    void RestoreActiveStates()
    {
        foreach (var pair in originalActives)
        {
            pair.Key.SetActive(pair.Value);
        }
    }
}
