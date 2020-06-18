using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayUtil {

    private static readonly Texture2D rectTexture = new Texture2D(1, 1);
    private static readonly GUIStyle style = new GUIStyle();

    public static void drawRect(Rect rect, Color color) {
        rectTexture.SetPixel(0, 0, color);
        rectTexture.Apply();

        style.normal.background = rectTexture;
        GUI.Box(rect, GUIContent.none, style);
    }
}
