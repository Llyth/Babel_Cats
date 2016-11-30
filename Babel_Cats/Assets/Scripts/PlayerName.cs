using UnityEngine;
using System.Collections;

public class PlayerName : MonoBehaviour
{
    public GUISkin guiSkin; // choose a guiStyle (Important!)

    public string text = "Player 1"; // choose your name

    public Color color = Color.white;   // choose font color/size
    public float fontSize;
    public float offsetX;
    public float offsetY;

    float boxW = 1.50f;
    float boxH = 2.0f;

    public bool messagePermanent = true;

    public float messageDuration { get; set; }

    Vector2 boxPosition;
    void Start()
    {
        if (messagePermanent)
        {
            messageDuration = 1;
        }
    }
    void OnGUI()
    {
        if (messageDuration > 0)
        {
            if (!messagePermanent) // if you set this to false, you can simply use this script as a popup messenger, just set messageDuration to a value above 0
            {
                messageDuration -= Time.deltaTime;
            }

            GUI.skin = guiSkin;
            boxPosition = Camera.main.WorldToScreenPoint(transform.position);
            boxPosition.y = Screen.height - boxPosition.y;
            boxPosition.x -= boxW * 0.1f;
            boxPosition.y -= boxH * 0.5f;

            GUI.contentColor = color;

            Vector2 content = guiSkin.box.CalcSize(new GUIContent(text));

            //GUI.Box(new Rect(boxPosition.x - content.x / 2 * offsetX, boxPosition.y + offsetY, content.x, content.y), text);
            GUI.Box(new Rect(boxPosition.x - content.x / 2, boxPosition.y + offsetY, content.x, content.y), text);
            }
    }
}
