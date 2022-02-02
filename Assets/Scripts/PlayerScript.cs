using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float score;
    public float timeleft = 100;
    public int timeremaining;

    public Text scoreText;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        timeremaining = Mathf.FloorToInt(timeleft % 60);
        timerText.text = "Time: " + timeremaining.ToString();
        scoreText.text = "Score: " + score;

        if (score == 60 && timeremaining >= 0)
        {
            SceneManager.LoadScene("GameWinScene");
        }

        if (timeremaining <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //coin collision
        if (other.gameObject.tag == "Coin")
        {           
            score += 10f;
            Destroy(other.gameObject);     
        }

        if(other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLoseScene");
        }    
    }
}
