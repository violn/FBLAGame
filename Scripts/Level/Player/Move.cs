using UnityEngine;

public class Move : MonoBehaviour
{
    public static float MoveTime = .3f;

    private void Update()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");

        if (GlobalRefLevel.playerProperties.finishedScalingDown &&
            GlobalRefLevel.playerProperties.finishedScalingUp &&
            !GlobalRefLevel.playerProperties.moving &&
            !GlobalRefLevel.playerProperties.grabState &&
            !FinishLevel.inResults &&
            StartLevel.levelStarted &&
            !PauseMenue.paused
            && !Grab.squishing)
        {
            if (Mathf.Abs(xDirection) == 1f)
            {
                if (GlobalRefLevel.playerProperties.depth == 0)
                {
                    if (CheckCollision(gameObject, GlobalRef.globalLayer.ground, 0f, -1f))
                    {
                        if (!CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, 0f))
                        {
                            MoveObj(MoveTime, xDirection, 0f);
                        }
                        else if (CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, 0f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, 1f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth0, 0f, 1f))
                        {
                            MoveObj(MoveTime, xDirection, 1f);
                        }
                    }
                    else
                    {
                        if (!CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, 0f) &&
                            CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, -1f))
                        {
                            MoveObj(MoveTime, xDirection, 0f);
                        }
                        else if (!CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, 0f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, -1f) &&
                            CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, -2f))
                        {
                            MoveObj(MoveTime, xDirection, -1f);
                        }
                        else if (CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, 0f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, 1f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth0, xDirection, 2f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth0, 0f, 1f))
                        {
                            MoveObj(MoveTime, xDirection, 1f);
                        }
                    }
                }
                else
                {
                    if (CheckCollision(gameObject, GlobalRef.globalLayer.ground, 0f, -1f))
                    {
                        if (!CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, 0f))
                        {
                            MoveObj(MoveTime, xDirection, 0f);
                        }
                        else if (CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, 0f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, 1f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth1, 0f, 1f))
                        {
                            MoveObj(MoveTime, xDirection, 1f);
                        }
                    }
                    else
                    {
                        if (!CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, 0f) &&
                            CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, -1f))
                        {
                            MoveObj(MoveTime, xDirection, 0f);
                        }
                        else if (!CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, 0f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, -1f) &&
                            CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, -2f))
                        {
                            MoveObj(MoveTime, xDirection, -1f);
                        }
                        else if (CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, 0f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, 1f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth1, xDirection, 2f) &&
                            !CheckCollision(gameObject, GlobalRef.globalLayer.depth1, 0f, 1f))
                        {
                            MoveObj(MoveTime, xDirection, 1f);
                        }
                    }
                }
            }
            else if (yDirection == -1f && GlobalRefLevel.playerProperties.depth == 1)
            {
                if (CheckCollision(gameObject, GlobalRef.globalLayer.depth0, 0f, 0f) &&
                    !CheckCollision(gameObject, GlobalRef.globalLayer.depth0, 0f, 1f) &&
                    !CheckCollision(gameObject, GlobalRef.globalLayer.depth1, 0f, 1f))
                {
                    MoveObj(MoveTime, 0f, -yDirection);
                    GlobalRefLevel.playerProperties.depth = 0;
                }
                else if (!CheckCollision(gameObject, GlobalRef.globalLayer.depth0, 0f, 0f) &&
                    CheckGround(gameObject, GlobalRef.globalLayer.depth0, 0f))
                {
                    GlobalRefLevel.playerProperties.depth = 0;
                }
                else if (!CheckCollision(gameObject, GlobalRef.globalLayer.depth0, 0f, 0f) &&
                    !CheckCollision(gameObject, GlobalRef.globalLayer.depth0, 0f, -1f) &&
                    CheckCollision(gameObject, GlobalRef.globalLayer.depth0, 0f, -2f))
                {
                    MoveObj(MoveTime, 0f, yDirection);
                    GlobalRefLevel.playerProperties.depth = 0;
                }
            }
            else if (yDirection == 1f && GlobalRefLevel.playerProperties.depth == 0)
            {
                if (CheckCollision(gameObject, GlobalRef.globalLayer.depth1, 0f, 0f) &&
                    !CheckCollision(gameObject, GlobalRef.globalLayer.depth1, 0f, 1f) &&
                    !CheckCollision(gameObject, GlobalRef.globalLayer.depth0, 0f, 1f))
                {
                    MoveObj(MoveTime, 0f, yDirection);
                    GlobalRefLevel.playerProperties.depth = 1;
                }
                else if (!CheckCollision(gameObject, GlobalRef.globalLayer.depth1, 0f, 0f) &&
                    CheckGround(gameObject, GlobalRef.globalLayer.depth1, 0f))
                {
                    GlobalRefLevel.playerProperties.depth = 1;
                }
                else if (!CheckCollision(gameObject, GlobalRef.globalLayer.depth1, 0f, 0f) &&
                    !CheckCollision(gameObject, GlobalRef.globalLayer.depth1, 0f, -1f) &&
                    CheckCollision(gameObject, GlobalRef.globalLayer.depth1, 0f, -2f))
                {
                    MoveObj(MoveTime, 0f, -yDirection);
                    GlobalRefLevel.playerProperties.depth = 1;
                }
            }
        }
    }

    public void DoneMoving()
    {
        GlobalRefLevel.playerProperties.moving = false;
    }

    public void MoveObj(float time, float x, float y)
    {
        GlobalRefLevel.playerProperties.moving = true;
        iTween.MoveBy(gameObject,
            iTween.Hash(
                "x", x,
                "y", y,
                "easeType", "linear",
                "time", time,
                "oncompletetarget", gameObject,
                "oncomplete", "DoneMoving"));
    }

    public void MoveObj(GameObject obj, float time, float x, float y)
    {
        GlobalRefLevel.playerProperties.moving = true;
        iTween.MoveBy(obj,
            iTween.Hash(
                "x", x,
                "y", y,
                "easeType", "linear",
                "time", time,
                "oncompletetarget", gameObject,
                "oncomplete", "DoneMoving"));
    }

    public bool CheckCollision(GameObject obj, LayerMask layer, float x, float y)
    {
        return Physics2D.OverlapCircle(obj.transform.position + new Vector3(x, y), .001f, layer);
    }

    public bool CheckGround(GameObject plr, LayerMask layer, float x)
    {
        return CheckCollision(plr, layer, x, -1f) || CheckCollision(plr, GlobalRef.globalLayer.ground, x, -1f);
    }
}