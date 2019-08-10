using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private GameObject game_over_text;
    public bool game_over { get { return is_game_over; } }
    private bool is_game_over = false;

    public float scroll_speed_global { get { return scroll_speed; } }
    [SerializeField] private float scroll_speed = -1.5f;

    private int score = 0;
    [SerializeField] private Text score_ui;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(game_over && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void OnBirdDied()
    {
        game_over_text.SetActive(true);
        is_game_over = true;
    }

    public void OnBirdPassColumn()
    {
        if (!game_over)
        {
            score++;
            score_ui.text = "Score: " + score.ToString();
        }
    }
}
