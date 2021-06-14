using UnityEngine;
using UnityEngine.UI;

public class NameEntryWarning : MonoBehaviour
{
    public static Color TextColor;
    private static float ChangeTime = 0f;

    private void Start()
    {
        TextColor = gameObject.GetComponent<Text>().color;
    }

    private void Update()
    {
        if (TextColor != Color.white)
        {
            gameObject.GetComponent<Text>().color = TextColor;
            TextColor.r = Mathf.Lerp(TextColor.r, 1f, ChangeTime);
            TextColor.g = Mathf.Lerp(TextColor.g, 1f, ChangeTime);
            TextColor.b = Mathf.Lerp(TextColor.b, 1f, ChangeTime);
            ChangeTime += Time.deltaTime * .5f;
        }
        else ChangeTime = 0f;
    }
}
