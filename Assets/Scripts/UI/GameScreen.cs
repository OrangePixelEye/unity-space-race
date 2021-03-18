using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    private float waitTime = 1.0f;
    private float timer = 0.0f;

    [SerializeField]
    private Text player_1_points;

    [SerializeField]
    private Text player_2_points;
    [SerializeField]
    private Text winner_text;
    [SerializeField]
    private GameObject show_winner;
    [SerializeField]
    private GameObject timer_obj;
    private Vector2 bar_start;

    public void UpdatePoints(int player_1, int player_2)
    {
        player_1_points.text = player_1.ToString();
        player_2_points.text = player_2.ToString();
    }

    void Start()
    {
        bar_start = timer_obj.transform.position;
    }

    public void ShowWinner(int winner)
    {
        show_winner.SetActive(true);
        winner_text.text = "Congratulations player " + winner;
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer = 0;
            timer_obj.transform.position = new Vector2(0, (timer_obj.transform.position.y - 0.1f));;
            if(timer_obj.transform.position.y< -5.6f)
            {
                GameManager.Instance.StopGame();
            }
        }
    }

    public void ResetGame()
    {
        timer_obj.transform.position = bar_start;
        show_winner.SetActive(false);
        GameManager.Instance.ResetGame();
        
        Players[] total_players = new Players[2];
        total_players = FindObjectsOfType<Players>();
        
        foreach (Players player in total_players)
        {
            player.Respawn();
        }
    }

    public void ExitGame()
    {
        GameManager.Instance.ChangeScene(1);
    }
}