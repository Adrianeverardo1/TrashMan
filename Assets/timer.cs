using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerText;
    public Text endText;
    public static float clock=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        timerText.text = clock.ToString("F2");
        if (clock >= 15)
        {
            timerText.enabled = false;
            GameObject item = GameObject.Find("TrashMan");
            item.GetComponent<TrashGrab>().enabled = false;
            endText.text = "Times Up!!!";
        }
        
    }
}
