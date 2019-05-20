using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collition4 : MonoBehaviour
{
    // Start is called before the first frame update
    int score, points;
    public Text scoreText;
    public Text endText;
    void Start()
    {
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        points = TrashGrab.points;
        if (score + points == TrashGrab.limit)
        {
            GameObject canvas = GameObject.Find("Canvas");
            canvas.GetComponent<Tempo>().enabled = false;
            GameObject item = GameObject.Find("Credits");
            item.GetComponent<Text>().enabled = true;
            endText.text = "Final score: " + score.ToString() + "/" + TrashGrab.limit.ToString();
            StartCoroutine(Reset(5));
        }
    }

    IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("paper"))
        {
            other.gameObject.SetActive(false);
            score = TrashGrab.score + 1;
            TrashGrab.score = score;
            SetScore();
        }
        else
        {
            points = TrashGrab.points + 1;
            TrashGrab.points = points;
            other.gameObject.SetActive(false);
        }
        
    }

    void SetScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
