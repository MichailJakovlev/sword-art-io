using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneState : MonoBehaviour, ISceneState
{
    private ISceneState _sceneState;
    SceneState ISceneState.SceneState => this;

    public void ToGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 1);
    }

    public void ToMenuScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
