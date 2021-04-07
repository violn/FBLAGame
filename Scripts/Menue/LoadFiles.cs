using UnityEngine;

public class LoadFiles : MonoBehaviour
{
    private void Awake()
    {
        ScoreHandler.Load();
    }
}