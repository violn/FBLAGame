using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    public const float moveTime = .25f;

    private void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Vector3 player_position = gameObject.transform.position;

        if (PlayerProps.still && !Grab.grabbing && (Math.Abs(xInput) > 0 || Math.Abs(yInput) > 0))
        {
            if (Math.Abs(xInput) == 1f)
            {
                if (!CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], player_position + new Vector3(xInput, 0f)) &&
                    CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], player_position + new Vector3(xInput, -1f)))
                {
                    MoveObj(player_position + new Vector3(xInput, 0f));
                }
                else if (CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], player_position + new Vector3(xInput, 0f)) &&
                    !CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], player_position + new Vector3(0f, 1f)) &&
                    !CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], player_position + new Vector3(xInput, 1f)))
                {
                    MoveObj(player_position + new Vector3(xInput, 1f));
                }
                else if (!CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], player_position + new Vector3(xInput, 0f)) &&
                    CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], player_position + new Vector3(xInput, -2f)))
                {
                    MoveObj(player_position + new Vector3(xInput, -1f));
                }
            }
            else if ((yInput == 1f && PlayerProps.currentDepth != 1) || (yInput == -1f && PlayerProps.currentDepth != 0))
            {
                if (
                    !CheckCollision(PlayerProps.depth[PlayerProps.GetOppositeDepth()], player_position) &&
                    CheckCollision(PlayerProps.depth[PlayerProps.GetOppositeDepth()], player_position + new Vector3(0f, -1f)))
                {
                    MoveObj(player_position + new Vector3(0f, yInput * -.1875f));
                    PlayerProps.ChangeScale();
                }
                else if (
                    CheckCollision(PlayerProps.depth[PlayerProps.GetOppositeDepth()], player_position) &&
                    !CheckCollision(PlayerProps.depth[PlayerProps.GetOppositeDepth()], player_position + new Vector3(0f, 1f)) &&
                    !CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], player_position + new Vector3(0f, 1f)))
                {
                    MoveObj(player_position + new Vector3(0f, 1f + yInput * -.1875f));
                    PlayerProps.ChangeScale();
                }
                else if (
                    !CheckCollision(PlayerProps.depth[PlayerProps.GetOppositeDepth()], player_position) &&
                    CheckCollision(PlayerProps.depth[PlayerProps.GetOppositeDepth()], player_position + new Vector3(0f, -2f)))
                {
                    MoveObj(player_position + new Vector3(0f, -1f + yInput * -.1875f));
                    PlayerProps.ChangeScale();
                }
            }
        }
    }
    
    public static void MoveObj(Vector3 position, GameObject obj = null, float time = moveTime)
    {
        obj = obj != null ? obj : PlayerProps.player;

        PlayerProps.still = false;
        iTween.MoveTo(obj,
            iTween.Hash(
                "position", position,
                "easeType", "linear",
                "time", time,
                "oncompletetarget", PlayerProps.player,
                "oncomplete", "DoneMoving"));
    }
    
    public static bool CheckCollision(LayerMask layer, Vector3 position) => Physics2D.OverlapCircle(position, .001f, layer);

    public void DoneMoving()
    {
        PlayerProps.still = true;
    }
}
