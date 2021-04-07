using UnityEngine;

public class Grab : MonoBehaviour
{
    public KeyCode grabKey;
    private GameObject blockHeld;
    public static bool squishing;

    /// <summary>
    /// 0 is none, 1 is left, 2 is right
    /// </summary>
    private static int HoldingDirection = 0;

    private void Start()
    {
        squishing = false;
    }

    private void Update()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");

        if (GlobalRefLevel.playerProperties.finishedScalingUp &&
            GlobalRefLevel.playerProperties.finishedScalingDown &&
            !GlobalRefLevel.playerProperties.moving &&
            !FinishLevel.inResults &&
            StartLevel.levelStarted &&
            !PauseMenue.paused
            && !squishing)
        {
            if (Input.GetKeyDown(grabKey))
            {
                if (!GlobalRefLevel.playerProperties.grabState)
                {
                    Squish(gameObject, Move.MoveTime);
                    GlobalRefLevel.playerProperties.grabState = true;
                }
                else
                {
                    if (GlobalRefLevel.playerProperties.depth == 1)
                    {
                        UnSquish(gameObject, Move.MoveTime);
                        if (GlobalRefLevel.playerProperties.holdingSomething)
                        {
                            if (HoldingDirection == 1)
                            {
                                GlobalRefLevel.objectMove.MoveObj(Move.MoveTime, -(1 - GlobalRefLevel.playerProperties.grabMove + .09375f), 0f);
                            }
                            else if (HoldingDirection == 2)
                            {
                                GlobalRefLevel.objectMove.MoveObj(Move.MoveTime, (1 - GlobalRefLevel.playerProperties.grabMove + .09375f), 0f);
                            }

                            HoldingDirection = 0;
                            GlobalRefLevel.playerProperties.holdingSomething = false;
                        }
                    }
                    else
                    {
                        UnSquish(gameObject, Move.MoveTime);
                        if (GlobalRefLevel.playerProperties.holdingSomething)
                        {
                            if (HoldingDirection == 1)
                            {
                                GlobalRefLevel.objectMove.MoveObj(Move.MoveTime, -(1 - GlobalRefLevel.playerProperties.grabMove), 0f);
                            }
                            else if (HoldingDirection == 2)
                            {
                                GlobalRefLevel.objectMove.MoveObj(Move.MoveTime, (1 - GlobalRefLevel.playerProperties.grabMove), 0f);
                            }

                            HoldingDirection = 0;
                            GlobalRefLevel.playerProperties.holdingSomething = false;
                        }
                    }

                    GlobalRefLevel.playerProperties.grabState = false;
                }
            }
            else if (Mathf.Abs(xDirection) == 1f)
            {
                if (GlobalRefLevel.playerProperties.holdingSomething)
                {
                    if (HoldingDirection == 1)
                    {
                        if (GlobalRefLevel.playerProperties.depth == 0)
                        {
                            if (xDirection == 1f)
                            {
                                if (GlobalRefLevel.objectMove.CheckGround(gameObject, GlobalRef.globalLayer.depth0, xDirection) &&
                                    !GlobalRefLevel.objectMove.CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection + 1f, 0f))
                                {
                                    GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection, 0f);
                                    GlobalRefLevel.objectMove.MoveObj(blockHeld, Move.MoveTime, xDirection, 0f);
                                }
                            }
                            else
                            {
                                if (GlobalRefLevel.objectMove.CheckGround(gameObject, GlobalRef.globalLayer.depth0, xDirection) &&
                                    !GlobalRefLevel.objectMove.CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, 0f))
                                {
                                    GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection, 0f);
                                    GlobalRefLevel.objectMove.MoveObj(blockHeld, Move.MoveTime, xDirection, 0f);
                                }
                            }
                        }
                        else
                        {
                            if (xDirection == 1f)
                            {
                                if (GlobalRefLevel.objectMove.CheckGround(gameObject, GlobalRef.globalLayer.depth1, xDirection) &&
                                    !GlobalRefLevel.objectMove.CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection + 1f, 0f))
                                {
                                    GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection, 0f);
                                    GlobalRefLevel.objectMove.MoveObj(blockHeld, Move.MoveTime, xDirection, 0f);
                                }
                            }
                            else
                            {
                                if (GlobalRefLevel.objectMove.CheckGround(gameObject, GlobalRef.globalLayer.depth1, xDirection) &&
                                    !GlobalRefLevel.objectMove.CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, 0f))
                                {
                                    GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection, 0f);
                                    GlobalRefLevel.objectMove.MoveObj(blockHeld, Move.MoveTime, xDirection, 0f);
                                }
                            }
                        }
                    }
                    else if (HoldingDirection == 2)
                    {
                        if (GlobalRefLevel.playerProperties.depth == 0)
                        {
                            if (xDirection == -1f)
                            {
                                if (GlobalRefLevel.objectMove.CheckGround(gameObject, GlobalRef.globalLayer.depth0, xDirection) &&
                                    !GlobalRefLevel.objectMove.CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection - 1f, 0f))
                                {
                                    GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection, 0f);
                                    GlobalRefLevel.objectMove.MoveObj(blockHeld, Move.MoveTime, xDirection, 0f);
                                }
                            }
                            else
                            {
                                if (GlobalRefLevel.objectMove.CheckGround(gameObject, GlobalRef.globalLayer.depth0, xDirection) &&
                                    !GlobalRefLevel.objectMove.CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, 0f))
                                {
                                    GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection, 0f);
                                    GlobalRefLevel.objectMove.MoveObj(blockHeld, Move.MoveTime, xDirection, 0f);
                                }
                            }
                        }
                        else
                        {
                            if (xDirection == -1f)
                            {
                                if (GlobalRefLevel.objectMove.CheckGround(gameObject, GlobalRef.globalLayer.depth1, xDirection) &&
                                    !GlobalRefLevel.objectMove.CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection - 1f, 0f))
                                {
                                    GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection, 0f);
                                    GlobalRefLevel.objectMove.MoveObj(blockHeld, Move.MoveTime, xDirection, 0f);
                                }
                            }
                            else
                            {
                                if (GlobalRefLevel.objectMove.CheckGround(gameObject, GlobalRef.globalLayer.depth1, xDirection) &&
                                    !GlobalRefLevel.objectMove.CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, 0f))
                                {
                                    GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection, 0f);
                                    GlobalRefLevel.objectMove.MoveObj(blockHeld, Move.MoveTime, xDirection, 0f);
                                }
                            }
                        }
                    }
                }
                else if (GlobalRefLevel.playerProperties.grabState)
                {
                    if (GlobalRefLevel.playerProperties.depth == 0)
                    {
                        if (GlobalRefLevel.objectMove.CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, 0f))
                        {
                            blockHeld = Hold(gameObject, GlobalRef.globalLayer.depth0, xDirection, 0f);
                            if (xDirection == 1f)
                            {
                                GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection - GlobalRefLevel.playerProperties.grabMove, 0f);
                                HoldingDirection = 1;
                            }
                            else if (xDirection == -1f)
                            {
                                GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection + GlobalRefLevel.playerProperties.grabMove, 0f);
                                HoldingDirection = 2;
                            }
                        }
                    }
                    else if (GlobalRefLevel.playerProperties.depth == 1)
                    {
                        if (GlobalRefLevel.objectMove.CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, 0f))
                        {
                            blockHeld = Hold(gameObject, GlobalRef.globalLayer.depth1, xDirection, 0f);
                            if (xDirection == 1f)
                            {
                                GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection - GlobalRefLevel.playerProperties.grabMove + .09375f, 0f);
                                HoldingDirection = 1;
                            }
                            else if (xDirection == -1f)
                            {
                                GlobalRefLevel.objectMove.MoveObj(gameObject, Move.MoveTime, xDirection + GlobalRefLevel.playerProperties.grabMove - .09375f, 0f);
                                HoldingDirection = 2;
                            }
                        }
                    }
                }
            }
        }
    }

    private void Squish(GameObject plr, float time)
    {
        squishing = true;

        if (GlobalRefLevel.playerProperties.depth == 1)
        {
            iTween.ScaleTo(plr,
                iTween.Hash(
                    "scale", new Vector3(.1875f, .375f, 0f),
                    "time", time,
                    "oncompletetarget", gameObject,
                    "oncomplete", "DoneSquishing"
                    ));
        }
        else
        {
            iTween.ScaleTo(plr,
              iTween.Hash(
                  "scale", new Vector3(.375f, .75f, 0f),
                  "time", time,
                  "oncompletetarget", gameObject,
                  "oncomplete", "DoneSquishing"
                  ));
        }
    }

    private void UnSquish(GameObject plr, float time)
    {
        squishing = true;

        if (GlobalRefLevel.playerProperties.depth == 1)
        {
            iTween.ScaleTo(plr,
                iTween.Hash(
                    "scale", new Vector3(.375f, .375f, 0f),
                    "time", time,
                    "oncompletetarget", gameObject,
                    "oncomplete", "DoneSquishing"
                    ));
        }
        else
        {
            iTween.ScaleTo(plr,
                iTween.Hash(
                    "scale", new Vector3(.75f, .75f, 0f),
                    "time", time,
                    "oncompletetarget", gameObject,
                    "oncomplete", "DoneSquishing"
                    ));
        }
    }

    private GameObject Hold(GameObject plr, LayerMask Depth, float x, float y)
    {
        GlobalRefLevel.playerProperties.holdingSomething = true;
        Collider2D BlockCollider = Physics2D.OverlapCircle(plr.transform.position + new Vector3(x, y + .5f, 0f), .001f, Depth);
        return BlockCollider.gameObject;
    }

    private void DoneSquishing()
    {
        squishing = false;
    }
}