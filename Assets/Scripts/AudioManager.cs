using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    Camera cam;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        cam = Camera.main;
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 camPos = cam.transform.position;
            AudioSource.PlayClipAtPoint(clip, camPos, volume);
        }
    }
}
