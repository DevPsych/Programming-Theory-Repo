using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Encapsulation
    public bool isGameActive;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI congratulationsText;
    [SerializeField] Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Game Over UI and stops game
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void WinGame()
    {
        restartButton.gameObject.SetActive(true);
        congratulationsText.gameObject.SetActive(true);
        isGameActive = false;
    }
}
