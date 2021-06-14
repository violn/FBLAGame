using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public static int liveRemaining = 3;
    public static Color32 lifeColor = new Color32(179, 77, 77, 255);
    public RawImage life1;
    public RawImage life2;
    public RawImage life3;

    private void Start()
    {
        switch (liveRemaining)
        {
            case 1:
                life1.color = lifeColor;
                life2.color = Color.gray;
                life3.color = Color.gray;
                break;

            case 2:
                life1.color = lifeColor;
                life2.color = lifeColor;
                life3.color = Color.gray;
                break;

            case 3:
                life1.color = lifeColor;
                life2.color = lifeColor;
                life3.color = lifeColor;
                break;
        }
    }
}
