using UnityEngine;

public class Fade : MonoBehaviour
{
    private static GameObject fade_obj;
    public static Color fade_color;
    private static float change_time;

    private void Start()
    {
        change_time = 0f;
        fade_obj = gameObject;
        fade_color = fade_obj.GetComponent<Renderer>().material.color;
        fade_obj.GetComponent<Renderer>().material.color -= new Color(0f, 0f, 0f, 1f);
    }

    public static void FadeIn()
    {
        while (fade_color.a != .4f)
        {
            fade_color.a = Mathf.Lerp(0f, .4f, change_time);
            fade_obj.GetComponent<Renderer>().material.color = fade_color;
            change_time += 1f * Time.deltaTime;
        }

        change_time = 0f;
    }
}
