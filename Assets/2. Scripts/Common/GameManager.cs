using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class GameManager : Singleton<GameManager>
{
    /// <summary> Main Scene에서 선택한 게임 타입의 변수 </summary>
    private Constants.GameType game_type;

    [SerializeField] GameObject confirm_panel_prefab;

    private Canvas canvas;

    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {

        this.canvas = FindFirstObjectByType<Canvas>();

    }

    /// <summary> Main에서 Game Scene으로 전환 시 호출될 메서드 </summary>
    public void ChangeToGameScene(Constants.GameType game_type)
    {
        this.game_type = game_type;
        SceneManager.LoadScene(1);
    }

    /// <summary> Game에서 Main Scene으로 전환 시 호출될 메서드 </summary>
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenConfirmPanel(string msg)
    {
        if (canvas != null)
        {
            GameObject temp_confirm = Instantiate(this.confirm_panel_prefab, this.canvas.transform);
            temp_confirm.GetComponent<ConfirmPanelController>().Show(msg);
        }
    }
}
