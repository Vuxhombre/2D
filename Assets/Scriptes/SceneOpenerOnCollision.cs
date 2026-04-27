using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpenerOnCollision : SceneOpener
{
    public string NextLevelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OpenScene(NextLevelName);
    }
}
