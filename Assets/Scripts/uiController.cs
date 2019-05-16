using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiController : MonoBehaviour
{
    private const int SceneBuildIndex = 1;
    public GameObject player;
    public Text GameOverText;
    public Text WinGameText;
    public Button quitGameBut;
    public Button restartBut;

    int gameOverPos = -6;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        //GameOverLogic
        if(player.gameObject.transform.position.y < gameOverPos)
        {
            GameOverText.gameObject.SetActive(true);
            restartBut.gameObject.SetActive(true);
            quitGameBut.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.tag == "Win")
        {
            WinGameText.gameObject.SetActive(true);
            restartBut.gameObject.SetActive(true);
            quitGameBut.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void restartGame()
    {
        Debug.LogError("test");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneBuildIndex: 1);
        WinGameText.gameObject.SetActive(false);
        quitGameBut.gameObject.SetActive(false);
        restartBut.gameObject.SetActive(false);
    }

    public void QuitGame() => Application.Quit();
}