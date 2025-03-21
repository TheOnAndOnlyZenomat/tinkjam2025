using UnityEngine;

public class SetTime : MonoBehaviour
{
    public TimerScript timerScript;

    public void SetNewTime()
    {
        timerScript.SetTime(20);
    }
}
