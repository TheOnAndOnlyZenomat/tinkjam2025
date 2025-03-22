using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static TimerScript Instance { get; private set; }
    public float MaxTime = 5f;
    private float timeLeft;
    public GameObject gameOverText;
    public TMP_Text timerText;
    
    private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Debug.Log("TimerScript instance was not me, destroying");
			Destroy(this.gameObject);
		} else {
			Instance = this;
		}
	}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.SetActive(false);
        timeLeft = MaxTime;
        timerText.text = MaxTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = (timeLeft).ToString("0");
        }
        else
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void SetTime(float time) {
        this.timeLeft= timeLeft + time;
        timerText.text = timeLeft.ToString();
    }

    public void DamageTime(int damage) {
        this.timeLeft = timeLeft - damage;
        timerText.text = timeLeft.ToString();
    }
}

