using UnityEngine;

public class AudioManager_Start : MonoBehaviour
{
    [Header("---------- Audio Source ---------")]
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource MusikSource;
    [Header("---------- Audio Clip ----------")]
    public AudioClip Background;

    private void Start()
    {
        MusikSource.clip = Background;
;       MusikSource.Play();

    }
}
