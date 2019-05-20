using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tempo : MonoBehaviour
{
    public Text timerText;
    public Text endText;
    public static float clock = 0;
    // Start is called before the first frame update
    void Start()
    {
        clock = 0;
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        timerText.text = clock.ToString("F2");
        if (clock >= 90)
        {
            timerText.enabled = false;
            GameObject item = GameObject.Find("TrashMan");
            item.GetComponent<TrashGrab>().enabled = false;
            endText.text = "Times Up!!!";
            item = GameObject.Find("Credits");
            item.GetComponent<Text>().enabled = true;
            this.GetComponent<Tempo>().enabled = false;
            StartCoroutine(Reset(5));
        }

    }

    IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }
}
