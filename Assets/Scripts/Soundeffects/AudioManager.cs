using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("AudioManager instance was not me, destroying");
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

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
    public AudioClip CardDraw;
    public AudioClip CardBurn;

    private void Start()
    {
        MusikSource.clip = Background;
        MusikSource.Play();
    }

    public void PlayRegen()
    {
        Debug.Log("playing rain");
        SFXSource.PlayOneShot(this.Regen, 1);
    }

    public void PlaykalterWind()
    {
        Debug.Log("playing cold wind");
        SFXSource.PlayOneShot(this.kalterWind, 1);
    }
    public void PlaywarmerWind()
    {
        Debug.Log("playing hot wind");
        SFXSource.PlayOneShot(this.warmerWind, 1);
    }
    public void PlayKieseln()
    {
        Debug.Log("playing Gravel");
        SFXSource.PlayOneShot(this.Kiesel, 1);
    }
    public void PlayMatsch()
    {
        Debug.Log("playing Mud");
        SFXSource.PlayOneShot(this.Matsch, 1);
    }
    public void PlayRegensturm()
    {
        Debug.Log("playing rainstorm");
        SFXSource.PlayOneShot(this.Regensturm, 1);
    }
    public void PlaySchnee()
    {
        Debug.Log("playing snow");
        SFXSource.PlayOneShot(this.Schnee, 1);
    }
    public void PlaySturm()
    {
        Debug.Log("playing storm");
        SFXSource.PlayOneShot(this.Sturm, 1);
    }
    public void PlayTreibsand()
    {
        Debug.Log("playing quicksand");
        SFXSource.PlayOneShot(this.Treibsand, 1);
    }
    public void PlaySteinschlag()
    {
        Debug.Log("playing rockfall");
        SFXSource.PlayOneShot(this.Steinschlag, 1);
    }
    public void PlayMonsun()
    {
        Debug.Log("playing monsoon");
        SFXSource.PlayOneShot(this.Monsun, 1);
    }
    public void PlaySchneematsch()
    {
        Debug.Log("playing muddy snow");
        SFXSource.PlayOneShot(this.Schneematsch, 1);
    }
    public void PlayMatschsturtm()
    {
        Debug.Log("playing muddy storm");
        SFXSource.PlayOneShot(this.Matschsturtm, 1);
    }
    public void PlayFlut()
    {
        Debug.Log("playing flood");
        SFXSource.PlayOneShot(this.Flut, 1);
    }
    public void PlaySchneesturm()
    {
        Debug.Log("playing snowstorm");
        SFXSource.PlayOneShot(this.Schneesturm, 1);
    }
    public void PlaySandsturm()
    {
        Debug.Log("playing sandstorm");
        SFXSource.PlayOneShot(this.Sandsturm, 1);
    }
    public void PlaySanduhr()
    {
        Debug.Log("playing Hourglass");
        SFXSource.PlayOneShot(this.Sanduhr, 1);
    }
    public void PlayErdbeben()
    {
        Debug.Log("playing earthquake");
        SFXSource.PlayOneShot(this.Erdbeben, 1);
    }
    public void PlaySchneebaelleVomSchuhlhof()
    {
        Debug.Log("playing snowball");
        SFXSource.PlayOneShot(this.SchneebaelleVomSchuhlhof, 1);
    }
    public void PlayErdrutsch()
    {
        Debug.Log("playing landside");
        SFXSource.PlayOneShot(this.Erdrutsch, 1);
    }
    public void PlayWindhose()
    {
        Debug.Log("playing vortex");
        SFXSource.PlayOneShot(this.Windhose, 1);
    }
    public void PlayTsunamie()
    {
        Debug.Log("playing tsunamie");
        SFXSource.PlayOneShot(this.Tsunamie, 1);
    }
    public void PlayEissturm()
    {
        Debug.Log("playing blizzard");
        SFXSource.PlayOneShot(this.Eissturm, 1);
    }
    public void PlayReset()
    {
        Debug.Log("playing reset");
        SFXSource.PlayOneShot(this.Reset, 1);
    }
    public void PlayHagelsturm()
    {
        Debug.Log("playing hailstorm");
        SFXSource.PlayOneShot(this.Hagelsturm, 1);
    }
    public void PlayErdbebenMitDerStaerke10()
    {
        Debug.Log("playing haevy earthquake");
        SFXSource.PlayOneShot(this.ErdbebenMitDerStaerke10, 1);
    }
    public void PlayTornado()
    {
        Debug.Log("playing tornado");
        SFXSource.PlayOneShot(this.Tornado, 1);
    }
    public void PlayFeuerschaden()
    {
        Debug.Log("playing burn");
        SFXSource.PlayOneShot(this.Feuerschaden, 1);
    }
    public void PlayNass()
    {
        Debug.Log("playing wet");
        SFXSource.PlayOneShot(this.Nass, 1);
    }
    public void PlayVergiftet()
    {
        Debug.Log("playing poisen");
        SFXSource.PlayOneShot(this.Vergiftet, 1);
    }
    public void PlayCardDraw()
    {
        Debug.Log("playing poisen");
        SFXSource.PlayOneShot(this.CardDraw, 1);
    }
        public void PlayCardBurn()
    {
        Debug.Log("playing poisen");
        SFXSource.PlayOneShot(this.CardBurn, 1);
    }
}
