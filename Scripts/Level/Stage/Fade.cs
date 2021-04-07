using UnityEngine;

public class Fade : MonoBehaviour
{
    public GameObject fo;
    public static GameObject fade_obj;
    public static Color fade_color;
    public static float change_time = 0f;

    private void Start()
    {
        fade_obj = fo;
        fade_color = fade_obj.GetComponent<Renderer>().material.color;
        fade_color.a = 0f;
        fade_obj.GetComponent<Renderer>().material.color = fade_color;
    }

    public static void FadeIn()
    {
        if (fade_color.a != .4f)
        {
            fade_color.a = Mathf.Lerp(0f, .4f, change_time);
            fade_obj.GetComponent<Renderer>().material.color = fade_color;
            change_time += 1f * Time.deltaTime;
        }

        if (fade_color.a == .4f)
        {
            change_time = 0f;
        }
    }
}