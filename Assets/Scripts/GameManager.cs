using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private GameScreen gameScreen;

    private int player_1_points = 0;
    private int player_2_points = 0;

    public static GameManager Instance
	{
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void ChangeScene(int scene_build_index) => SceneManager.LoadScene(scene_build_index);

    public void GivePoint(bool is_player_1_point)
    {
        if(is_player_1_point)
        {
            player_1_points++;
        }
        else
        {
            player_2_points++;
        }

        gameScreen.UpdatePoints(player_1_points, player_2_points);
    }

    public void StopGame()
    {
        if(player_1_points >= player_2_points)
            gameScreen.ShowWinner(1);
        else
            gameScreen.ShowWinner(2);
    }

    public void StartGame() => gameScreen = FindObjectOfType<GameScreen>();

    public void ResetGame()
    {
        player_1_points = 0;
        player_2_points = 0;
        gameScreen.UpdatePoints(0, 0);
    }

    public void ExitGame() => Application.Quit();
}
