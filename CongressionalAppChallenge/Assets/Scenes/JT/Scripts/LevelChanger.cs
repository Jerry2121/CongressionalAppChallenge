using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;

    public int gameLevel = 1;

    public int LevelToLoad;

	// Update is called once per frame
	void Update () {
		
	}

    public void FadeToLevel (int levelIndex)
    {
        LevelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
    public void Play()
    {
        FadeToLevel(gameLevel);
    }
    public void LoadGame()
    {
        GameObject.Find("SaveLoadManager").GetComponent<SaveLoadGame>().LoadGame();
    }
    public void QuitMenu()
    {
        FadeToLevel(0);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        FadeToLevel(2);
        Time.timeScale = 1;
    }
  
}
