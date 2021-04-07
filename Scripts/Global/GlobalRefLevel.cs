using UnityEngine;

public class GlobalRefLevel : MonoBehaviour
{
    public GameObject p;
    public GameObject l;
    public static GameObject player;
    public static GameObject level;
    public static PlayerProps playerProperties;
    public static LevelProps levelProperties;
    public static Move objectMove;
    public static GlobalGameObjects globalObj;

    private void Awake()
    {
        player = p;
        level = l;
        levelProperties = level.GetComponent<LevelProps>();
        playerProperties = player.GetComponent<PlayerProps>();
        objectMove = player.GetComponent<Move>();
        globalObj = gameObject.GetComponent<GlobalGameObjects>();
    }
}