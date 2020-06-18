using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager: MonoBehaviour {

    private const int WIDTH = 10;

    private Vector2 mid;

    void Start() {
        this.onResize();
    }

    void Update() {

    }

    private void onResize() {
        this.mid = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private void OnGUI() {
        /*Rect point = new Rect(this.mid.x - WIDTH / 2, this.mid.y - WIDTH / 2,
                WIDTH, WIDTH);
        OverlayUtil.drawRect(point, new Color(0.1F, 0.75F, 0.1F, 0.5F));*/
    }
}
