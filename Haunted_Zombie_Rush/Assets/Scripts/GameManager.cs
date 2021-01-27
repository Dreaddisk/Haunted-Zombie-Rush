
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{

    #region Variables
    public static GameManager instance = null;

    [SerializeField]
    private GameObject mainMenu;

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;

    public bool PlayerActive
    {
        get { return playerActive; }
    }

    public bool GameOver
    {
        get { return gameOver; }
    }

    public bool GameStarted
    {
        get { return gameStarted; }
    }
    #endregion Variables



    #region UnityFunctions
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        Assert.IsNotNull(mainMenu);
    }

    #endregion UnityFunctions

    public void PlayerCollided()
    {
        gameOver = true;
    }

    public void PlayerStartedGame()
    {
        playerActive = true;
    }

    public void EnterGame()
    {
        mainMenu.SetActive(false);
        gameStarted = true;
    }

}// GameManager class
