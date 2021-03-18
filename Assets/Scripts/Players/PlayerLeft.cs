using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeft : Players
{
    public override void HandleInput()
    {
        int move = 0;
        if (Input.GetKey(KeyCode.W))
        {
            move = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move = -1;
        }
        MoveBar(move);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        GameManager.Instance.GivePoint(true);
    }
}
