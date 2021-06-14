using UnityEngine;

public class GlobalRefLevel : MonoBehaviour
{
    public GameObject l;
    public static GameObject level;
    public static LevelProps levelProperties;
    public static GlobalGameObjects globalObj;

    private void Awake()
    {
        level = l;
        levelProperties = level.GetComponent<LevelProps>();
        globalObj = gameObject.GetComponent<GlobalGameObjects>();
    }
}
