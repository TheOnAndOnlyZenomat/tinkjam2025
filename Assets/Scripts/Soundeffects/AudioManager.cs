using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ---------")]
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource MusikSource;
    [Header("---------- Audio Clip ----------")]
    public AudioClip Background;
    public AudioClip Regen;
    public AudioClip kalterWind;
    public AudioClip warmerWind;
    public AudioClip Kiesel;
    public AudioClip Matsch;
    public AudioClip Regensturm;
    public AudioClip Schnee;
    public AudioClip Sturm;
    public AudioClip Treibsand;
    public AudioClip Steinschlag;
    public AudioClip Monsun;
    public AudioClip Schneematsch;
    public AudioClip Matschsturtm;
    public AudioClip Flut;
    public AudioClip Schneesturm;
    public AudioClip Sandsturm;
    public AudioClip Sanduhr;
    public AudioClip Erdbeben;
    public AudioClip SchneebaelleVomSchuhlhof;
    public AudioClip Erdrutsch;
    public AudioClip Windhose;
    public AudioClip Tsunamie;
    public AudioClip Eissturm;
    public AudioClip Reset;
    public AudioClip Hagelsturm;
    public AudioClip ErdbebenMitDerStaerke10;
    public AudioClip Tornado;
    public AudioClip Feuerschaden;
    public AudioClip Nass;
    public AudioClip Vergiftet;
    


    private void Start()
    {
        MusikSource.clip = Background;
;       MusikSource.Play();

    }
}
