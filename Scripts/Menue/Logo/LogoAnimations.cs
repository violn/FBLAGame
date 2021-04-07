using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class LogoAnimations : MonoBehaviour
{
    public GameObject logo;
    public GameObject bottomText;
    public static RawImage logoImg;
    public static float changeTime = 0f;
    public static bool fadingOut = false;
    private readonly List<string> text = new List<string>()
    {
        "The world said hello back.",
        "This is a world premier.",
        "It's spelled misspelled.",
        "Protect black women.",
        "Support black businesses.",
        "2 + 2 is 22.",
        "The what are the odds of this being the first message you see.",
        "Martin > Fresh Prince.",
        "Isley Brothers are undefeated.",
        "Earth, Wind, & Fire are GOATed.",
        "Yuugh! - Pusha T.",
        "Shoutout to Mr. Alexander.",
        "Chet Hanks gotta sit down.",
        "According to all laws of Aviation, a bee should not be able to fly...",
        "2 tips on how to be successful. Tip #1 never say everything you know.",
        "The average number of eyes per person is less than 2.",
        "Something Witty",
        "If a horse could talk it would only say \"Hey\"",
        "Do you ever wonder why we're here?",
        "42",
    };

    private void Start()
    {
        Random ran = new Random();
        bottomText.GetComponent<TextMeshProUGUI>().text = text[ran.Next(text.Count)];
        logoImg = logo.GetComponent<RawImage>();
        logoImg.color = new Color(logoImg.color.r, logoImg.color.g, logoImg.color.b, 0f);
        Move();
    }

    private void Update()
    {
        if (!fadingOut)
        {
            logoImg.color = new Color(logoImg.color.r, logoImg.color.g, logoImg.color.b, Mathf.Lerp(0f, 1f, changeTime));
            changeTime += 0.75f * Time.deltaTime;
        }
        else
        {
            logoImg.color = new Color(logoImg.color.r, logoImg.color.g, logoImg.color.b, Mathf.Lerp(1f, 0f, changeTime));
            changeTime += 1f * Time.deltaTime;
            if (logoImg.color.a == 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void Move()
    {
        iTween.MoveBy(bottomText,
            iTween.Hash(
                "x", 1920f,
                "time", 0f,
                "oncompletetarget", gameObject,
                "oncomplete", "MoveIn"));
    }

    private void MoveIn()
    {
        iTween.MoveBy(bottomText,
            iTween.Hash(
                "x", -1920f,
                "time", .5,
                "delay", 2.5f,
                "oncompletetarget", gameObject,
                "oncomplete", "MoveOut"));
    }

    private void MoveOut()
    {
        iTween.MoveBy(bottomText,
            iTween.Hash(
                "x", -1920f,
                "time", .5,
                "delay", 2.5f,
                "oncompletetarget", gameObject,
                "oncomplete", "FadeOut"));
    }

    private void FadeOut()
    {
        changeTime = 0f;
        fadingOut = true;
    }
}