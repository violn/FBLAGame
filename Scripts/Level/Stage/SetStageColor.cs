using UnityEngine;
using Random = System.Random;

public class SetStageColor : MonoBehaviour
{
    private static Color32 foregroundColor = new Color32();
    private static readonly Random ran = new Random();

    public void Start()
    {
        int colorsToChange;
        int whichColor;

        colorsToChange = ran.Next(2);
        whichColor = ran.Next(3);

        switch (colorsToChange)
        {
            case 0:
                switch (whichColor)
                {
                    case 0:
                        foregroundColor = new Color32(179, 77, 77, 175);
                        break;

                    case 1:
                        foregroundColor = new Color32(77, 179, 77, 175);
                        break;

                    case 2:
                        foregroundColor = new Color32(77, 77, 179, 175);
                        break;
                }
                break;

            case 1:
                switch (whichColor)
                {
                    case 0:
                        foregroundColor = new Color32(179, 179, 77, 175);
                        break;

                    case 1:
                        foregroundColor = new Color32(77, 179, 179, 175);
                        break;

                    case 2:
                        foregroundColor = new Color32(179, 77, 177, 175);
                        break;
                }
                break;
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Stage"))
        {
            go.GetComponent<Renderer>().material.color = foregroundColor;
        }
    }
}