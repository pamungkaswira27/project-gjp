using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    [SerializeField] Transform fadeImage;
    [SerializeField] float fadeDuration;

    const string MENU_SCENE = "MainMenu";
    const string GAME_SCENE = "Gameplay";

    void OnEnable()
    {
        // Trigger Fade In Animation
        fadeImage.LeanScale(Vector2.zero, 1f);
    }

    void Awake()
    {
        Instance = this;
    }

    public void LoadMenuScene()
    {
        StartCoroutine(FadeSceneCoroutine(MENU_SCENE));
    }

    public void LoadGameScene()
    {
        StartCoroutine(FadeSceneCoroutine(GAME_SCENE));
    }

    public void LoadNextLevel()
    {
        StartCoroutine(FadeSceneCoroutine(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReloadScene()
    {
        StartCoroutine(FadeSceneCoroutine(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator FadeSceneCoroutine(int sceneIndex)
    {
        // Trigger Fade Out Animation
        fadeImage.localScale = Vector2.zero;
        fadeImage.LeanScale(Vector2.one, 1f);

        yield return new WaitForSeconds(fadeDuration);

        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator FadeSceneCoroutine(string sceneName)
    {
        // Trigger Fade Out Animation
        fadeImage.localScale = Vector2.zero;
        fadeImage.LeanScale(Vector2.one, 1f);

        yield return new WaitForSeconds(fadeDuration);

        SceneManager.LoadScene(sceneName);
    }
}
