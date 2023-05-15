using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
	[SerializeField] string nameEssentialScene;
	[SerializeField] string nameNewGameStartScene;
    public void StartGame()
	{
		SceneManager.LoadScene(nameNewGameStartScene, LoadSceneMode.Single);
		SceneManager.LoadScene(nameEssentialScene ,LoadSceneMode.Additive);
		
	}
	public void LoadGame()
	{

	}
	public void ExitGmae()
	{
		Application.Quit();
	}
}
