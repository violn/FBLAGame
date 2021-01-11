using UnityEngine;

public class ChangeOpacity : MonoBehaviour
{
    private Renderer rend;

    private Color AssetColor = new Color();

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<Renderer>();
        AssetColor.a = .5f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (MoveUp())
        {
            rend.material.color = AssetColor;
            if (AssetColor.a == 1f)
            {
                AssetColor.a = .5f;
            }
        }

        else if (MoveDown())
        {
            rend.material.color = AssetColor;
            if (AssetColor.a != 1f)
            {
                AssetColor.a = 1f;
            }
        }
    }

    private static bool MoveUp()
    {
        return Input.GetAxis("Vertical") > 0;
    }

    private static bool MoveDown()
    {
        return Input.GetAxis("Vertical") < 0;
    }
}