using UnityEngine;
using Player.Props;

//Moves the player up and down in depth
//This is currently only visual as there's no blocks on the secondlayer
public class MoveZ : MonoBehaviour
{
    private float OR;
    private float OG;
    private float OB;
    private Renderer Rend;
    private Color AssetColor = new Color();

    // Start is called before the first frame update
    private void Start()
    {
        Rend = GetComponent<Renderer>();
        OR = Rend.material.color.r;
        OG = Rend.material.color.g;
        OB = Rend.material.color.b;
        AssetColor = Rend.material.color;
    }

    // Update is called once per frame
    private void Update()
    {
        //Checks for the up input to change the color of the player
        if (MoveUp())
        {
            Rend.material.color = AssetColor;
            if (PlayerProps.Depth == 0 && AssetColor.r != OR /2 && AssetColor.g != OG /2 && AssetColor.b != OB / 2)
            {
                PlayerProps.Depth = 1;
                AssetColor.r *= .5f;
                AssetColor.g *= .5f;
                AssetColor.b *= .5f;
            }
        }

        //Checks the down input to change the color
        else if (MoveDown())
        {
            Rend.material.color = AssetColor;
            if (PlayerProps.Depth == 1 && AssetColor.r != OR && AssetColor.g != OG && AssetColor.b != OB)
            {
                PlayerProps.Depth = 0;
                AssetColor.r *= 2f;
                AssetColor.g *= 2f;
                AssetColor.b *= 2f;
            }
        }
    }

    //Get player up input
    private static bool MoveUp()
    {
        return Input.GetAxis("Vertical") > 0f;
    }

    //Get player down input
    private static bool MoveDown()
    {
        return Input.GetAxis("Vertical") < 0f;
    }
}
