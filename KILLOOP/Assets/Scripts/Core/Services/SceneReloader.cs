using UnityEngine.SceneManagement;

public class SceneReloader
{
    public void ReloadCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
