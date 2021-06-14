using System.Collections.Generic;
using UnityEngine;

public class PlayerProps : MonoBehaviour
{
    public static List<LayerMask> depth = new List<LayerMask>();
    public List<LayerMask> d = new List<LayerMask>();
    public static GameObject player;
    public static int currentDepth;
    public static bool still;

    private void Awake()
    {
        depth = d;
        currentDepth = 0;
        player = gameObject;
        still = false;
    }

    private void DoneScaling()
    {
        still = true;
    }

    public static void ChangeScale()
    {
        still = false;
        player.GetComponent<Renderer>().material.color *= currentDepth == 0 ? new Color(.5f, .5f, .5f) : new Color(2f, 2f, 2f);
        iTween.ScaleTo(player,
            iTween.Hash(
                "scale", currentDepth == 0 ? new Vector3(.375f, .375f) : new Vector3(.75f, .75f),
                "time", Move.moveTime,
                "oncompletetarget", player,
                "oncomplete", "DoneScaling"));
        currentDepth = currentDepth == 0 ? 1 : 0;
    }

    public static int GetOppositeDepth() => currentDepth == 0 ? 1 : 0;
}
