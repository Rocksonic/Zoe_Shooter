using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
	[SerializeField]
	private int minutes; 
	[SerializeField]
	private int seconds; 

	private int m,s; 

	[SerializeField]
    public GameObject UiTimer;
    public float velocityTime;
	public Text timerText; 

    public bool isFinishTime;

    private void Start() {
        isFinishTime = false;
        UiTimer.SetActive(false);
    }


	public void startTimer(){
        
        isFinishTime = false;
		m = minutes; 
		s = seconds; 
		writeTimer (m, s); 
        UiTimer.SetActive(true);
		Invoke ("updateTimer", velocityTime); 
	}

    public void endTimer()
    {
        stopTimer();
        UiTimer.SetActive(false);
        isFinishTime = true;
    }

	
	public void stopTimer(){
		CancelInvoke (); 
	}

	
	private void updateTimer(){
		s--; 

		if (s < 0) { 

			if (m == 0) {
				
				endTimer(); 
				return; 
			} else {
				
				m--; 
				s = 59; 

			}

		}

		writeTimer (m, s); 
		Invoke ("updateTimer", 1f); 
		
	}

	private void writeTimer(int m,int s){ 

		if (s < 10) { 

			timerText.text = m.ToString () + ":0" + s.ToString ();

		} else {
			timerText.text = m.ToString () + ":" + s.ToString (); 

		}
	}
}
