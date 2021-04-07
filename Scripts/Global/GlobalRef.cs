using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalRef : MonoBehaviour
{
    public static GlobalVariables globalVariable;
    public static GlobalMethods globalMethod;
    public static GlobalLayerMasks globalLayer;
    public static int[] levelScores = new int[0];

    private void Awake()
    {
        if (levelScores.Length <= 0)
        {
            levelScores = new int[SceneManager.sceneCountInBuildSettings - 2];
        }

        globalLayer = gameObject.GetComponent<GlobalLayerMasks>();
        globalVariable = gameObject.GetComponent<GlobalVariables>();
        globalMethod = gameObject.GetComponent<GlobalMethods>();
    }
}