using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private float respawnDelay = 2f;
    private bool isGameEnding = false;
    private int score;
    public Text scoreText;
    public Text winText;
    public GameObject WinnerUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = Object.FindFirstObjectByType<PlayerController>();
    }

    // Update is called once per frame

    public void RespawnPlayer()
    {
        if (isGameEnding == false)
        {
            isGameEnding = true;
            StartCoroutine("RespawnCoroutine");
        }
    }

    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false); // Oyuncuyu geçici olarak devre dışı bırak
        yield return new WaitForSeconds(respawnDelay); // Belirtilen süre kadar bekle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        //playerController.transform.position = playerController.respawnPoint; // Yeniden doğma noktasına taşı
        //playerController.gameObject.SetActive(true); // Oyuncuyu tekrar etkinleştir
        isGameEnding = false;
    }

    public void AddScore(int numberOfScore)
    {
        score += numberOfScore;
        scoreText.text = score.ToString();
    }

    public void LevelUp()
    {
        Debug.Log("LevelUp method called");
        if (WinnerUI != null)
        {
            WinnerUI.SetActive(true);
        }
        else
        {
            Debug.LogError("WinnerUI is not assigned!");
        }

        if (winText != null)
        {
            winText.text = "Seviye Tamamlandı Toplam Puan " + score;
        }
        else
        {
            Debug.LogError("winText is not assigned!");
        }

        Invoke("NextLevel", respawnDelay);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
