using UnityEngine;

public class AudioMerger : MonoBehaviour
{
    public AudioClip clip1;      // đoạn âm thanh đầu
    public AudioClip clip2;      // đoạn âm thanh sau
    public float silenceDuration = 1.0f; // thời gian im lặng giữa 2 clip (giây)

    void Start()
    {
        AudioClip merged = MergeAudioClips(clip1, clip2, silenceDuration);
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = merged;
        audioSource.Play();
    }

    AudioClip MergeAudioClips(AudioClip a, AudioClip b, float silenceSeconds)
    {
        if (a.channels != b.channels || a.frequency != b.frequency)
        {
            Debug.LogError("Hai đoạn âm thanh phải cùng số kênh và tần số mẫu!");
            return null;
        }

        int sampleRate = a.frequency;
        int channels = a.channels;

        int aSamples = a.samples * channels;
        int bSamples = b.samples * channels;
        int silenceSamples = Mathf.FloorToInt(silenceSeconds * sampleRate * channels);

        float[] mergedData = new float[aSamples + silenceSamples + bSamples];

        a.GetData(mergedData, 0); // ghi clip1 vào đầu
        // không cần ghi gì cho đoạn silence — mặc định đã là 0
        b.GetData(mergedData, aSamples + silenceSamples); // ghi clip2 sau đoạn silence

        AudioClip mergedClip = AudioClip.Create("MergedClip", mergedData.Length / channels, channels, sampleRate, false);
        mergedClip.SetData(mergedData, 0);
        return mergedClip;
    }
}
