using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextMeshProUGUI gt = this.GetComponent<TextMeshProUGUI>();
        gt.text = "High Score: "+score;
    }

    void Awake()
    { //a
      // Если значение HighScore уже существует в PlayerPrefs, прочитать его
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        // Сохранить высшее достижение HighScore в хранилище
        PlayerPrefs.SetInt("HighScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI gt = this.GetComponent<TextMeshProUGUI>();
        gt.text = "High Score: "+score;

        // Обновить HighScore в PlayerPrefs, если необходимо
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
