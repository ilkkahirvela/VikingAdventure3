using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour
{
  public void LoadMap()
    {
        // Play painiketta painettu valikossa
        SceneManager.LoadScene("Map");

    }

    public void Save()
    {
        Debug.Log("Save painiketta painettu");
        GameManager.manager.Save();
    }

    public void Load()
    {
        Debug.Log("Load painiketta painettu");
        GameManager.manager.Load();
    }
}
