//Player properties that can be referenced by other classes
using UnityEngine;

public class PlayerProps : MonoBehaviour
{
    public int depth;
    public int currentDepth;
    public bool holdingSomething;
    public bool grabState;
    public bool moving;
    public bool finishedScalingDown;
    public bool finishedScalingUp;
    public readonly float moveTime = .25f;
    public readonly float shrinkMove = .1875f;
    public readonly float grabMove = .6875f;
    public Renderer playerRend;
    private Color defaultColor;

    private void Start()
    {
        holdingSomething = false;
        grabState = false;
        moving = false;
        finishedScalingDown = true;
        finishedScalingUp = true;
        depth = 0;
        currentDepth = 0;
        defaultColor = playerRend.material.color;
    }

    private void Update()
    {
        if (depth != currentDepth)
        {
            if (finishedScalingUp && finishedScalingDown)
            {
                if (currentDepth == 0 && !ChangedToDepth1())
                {
                    playerRend.material.color *= new Color(.5f, .5f, .5f);
                    finishedScalingDown = false;
                    ScaleDown();
                }

                if (currentDepth == 1 && !ChangedToDepth0())
                {
                    playerRend.material.color *= new Color(2f, 2f, 2f);
                    finishedScalingUp = false;
                    ScaleUp();
                }
            }
        }
    }

    private bool ChangedToDepth1()
    {
        return playerRend.material.color.r == defaultColor.r * .5f && finishedScalingDown;
    }

    private bool ChangedToDepth0()
    {
        return playerRend.material.color == defaultColor && finishedScalingUp;
    }

    private void DoneScalingDown()
    {
        finishedScalingDown = true;
        currentDepth = 1;
    }

    private void DoneScalingUp()
    {
        finishedScalingUp = true;
        currentDepth = 0;
    }

    private void ScaleDown()
    {
        iTween.MoveAdd(gameObject,
            iTween.Hash(
                "amount", new Vector3(0f, -shrinkMove, 0f),
                "time", moveTime));

        iTween.ScaleTo(gameObject,
            iTween.Hash(
                "scale", new Vector3(.375f, .375f, 0f),
                "time", moveTime,
                "oncompletetarget", gameObject,
                "oncomplete", "DoneScalingDown"));
    }

    private void ScaleUp()
    {
        iTween.MoveAdd(gameObject,
            iTween.Hash(
                "amount", new Vector3(0f, shrinkMove, 0f),
                "time", moveTime));

        iTween.ScaleTo(gameObject,
            iTween.Hash(
                "scale", new Vector3(.75f, .75f, 0f),
                "time", moveTime,
                "oncompletetarget", gameObject,
                "oncomplete", "DoneScalingUp"));
    }
}