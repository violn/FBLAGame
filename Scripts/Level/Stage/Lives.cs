using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public static int liveRemaining = 3;
    public static bool resetLives = false;
    private static Color gray = new Color(.5f, .5f, .5f, 1f);
    public static Color32 lifeColor = new Color32(179, 77, 77, 255);
    public RawImage life1;
    public RawImage life2;
    public RawImage life3;

    public void Start()
    {
        if (resetLives)
        {
            life1.color = lifeColor;
            life2.color = lifeColor;
            life3.color = lifeColor;
            resetLives = false;
        }
    }

    public void Update()
    {
        switch (liveRemaining)
        {
            case 1:
                life2.color = gray;
                life3.color = gray;
                break;

            case 2:
                life3.color = gray;
                break;
        }
    }
}