using UnityEngine;
using System.Collections;

public class VisualFadeOnEndGame : VisualFade {
    public bool endGameVisisble;
    public void EndGame() {
        visible = endGameVisisble;
    }
}
