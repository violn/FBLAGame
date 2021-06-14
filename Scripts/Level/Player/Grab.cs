using UnityEngine;

public class Grab : MonoBehaviour
{
    private enum HoldingDirection
    {
        left = -1,
        right = 1,
        neutral = 0
    }

    private static HoldingDirection currentDirection = HoldingDirection.neutral;
    public KeyCode grabKey;
    public KeyCode shoveKey;
    private static GameObject blockHeld;
    private static bool holdingSomething;
    public static bool grabbing;
    private const float grabMove = .3125f;

    private void Start()
    {
        grabbing = false;
        holdingSomething = false;
    }

    private void Update()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        Vector3 player_position = PlayerProps.player.transform.position;

        if (PlayerProps.still)
        {
            if (Input.GetKeyDown(grabKey))
            {
                if (!grabbing)
                {
                    Squish();
                }
                else UnSquish();
            }

            if (grabbing)
            {
                if (Mathf.Abs(xDirection) > 0f)
                {
                    if (holdingSomething)
                    {
                        if (Move.CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], player_position + new Vector3(xDirection, -1f)) &&
                            !Move.CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], player_position + new Vector3(xDirection == (float)currentDirection ? xDirection * 2f : xDirection, 0f)))
                        {
                            Move.MoveObj(player_position + new Vector3(xDirection, 0f));
                            Move.MoveObj(blockHeld.transform.position + new Vector3(xDirection, 0f), blockHeld);
                        }
                    }
                    else if (Move.CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], player_position + new Vector3(xDirection, 0f)))
                    {
                        blockHeld = Hold(PlayerProps.depth[PlayerProps.currentDepth], xDirection, 0f);
                        Move.MoveObj(player_position + new Vector3(xDirection * grabMove + (PlayerProps.currentDepth == 0 ? 0f : xDirection * .09375f), 0f));
                        currentDirection = xDirection == 1f ? HoldingDirection.right : HoldingDirection.left;
                    }
                }
                else if (holdingSomething)
                {
                    if (Input.GetKeyDown(shoveKey))
                    {
                        Vector3 collison_detector1 = blockHeld.transform.position + new Vector3((float)currentDirection, 0f);
                        Vector3 collison_detector2 = blockHeld.transform.position + new Vector3((float)currentDirection, -1f);

                        while (true)
                        {
                            if (!Move.CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], collison_detector1))
                            {
                                collison_detector1 += new Vector3((float)currentDirection, 0f);
                            }
                            else
                            {
                                Move.MoveObj(new Vector3(collison_detector1.x - 1f, blockHeld.transform.position.y), blockHeld, .25f * (collison_detector1.x - blockHeld.transform.position.x));
                                UnSquish();
                                break;
                            }

                            if (Move.CheckCollision(PlayerProps.depth[PlayerProps.currentDepth], collison_detector2))
                            {
                                collison_detector2 += new Vector3((float)currentDirection, 0f);
                            }
                            else
                            {
                                Move.MoveObj(new Vector3(collison_detector2.x - 1f, blockHeld.transform.position.y), blockHeld, .25f * (collison_detector2.x - blockHeld.transform.position.x));
                                UnSquish();
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    private void Squish()
    {
        PlayerProps.still = false;

        iTween.ScaleTo(gameObject,
            iTween.Hash(
                "scale", PlayerProps.currentDepth == 1 ? new Vector3(.1875f, .375f, 0f) : new Vector3(.375f, .75f, 0f),
                "time", Move.moveTime,
                "oncompletetarget", gameObject,
                "oncomplete", "DoneSquishing"
                ));

        grabbing = true;
    }

    private void UnSquish()
    {
        PlayerProps.still = false;

        iTween.ScaleTo(gameObject,
            iTween.Hash(
                "scale", PlayerProps.currentDepth == 1 ? new Vector3(.375f, .375f, 0f) : new Vector3(.75f, .75f, 0f),
                "time", Move.moveTime,
                "oncompletetarget", gameObject,
                "oncomplete", "DoneSquishing"
                ));

        Detatch();
        grabbing = false;
    }

    private static void Detatch()
    {
        if (holdingSomething)
        {
            Move.MoveObj(PlayerProps.player.transform.position + new Vector3(-(float)currentDirection * (grabMove + (PlayerProps.currentDepth == 1 ? .09375f : 0f)), 0f));
            currentDirection = HoldingDirection.neutral;
            holdingSomething = false;
        }
    }

    private GameObject Hold(LayerMask Depth, float x, float y)
    {
        holdingSomething = true;
        Collider2D BlockCollider = Physics2D.OverlapCircle(gameObject.transform.position + new Vector3(x, y + .5f, 0f), .001f, Depth);
        return BlockCollider.gameObject;
    }

    private void DoneSquishing()
    {
        PlayerProps.still = true;
    }
}
