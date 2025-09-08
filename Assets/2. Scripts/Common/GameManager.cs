using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class GameManager : Singleton<GameManager>
{
    /// <summary> Main Scene에서 선택한 게임 타입의 변수 </summary>
    private Constants.GameType game_type;

    [SerializeField] private GameObject confirm_panel_prefab;
    [SerializeField] private GameObject signin_panel_prefab;
    [SerializeField] private GameObject signup_panel_prefab;

    private GameObject confirm_panel;

    private Canvas canvas;

    private GameLogic game_logic;

    private GameUIController game_ui_control;

    void Start()
    {
        OpenSigninPanel();
    }

    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        this.canvas = FindFirstObjectByType<Canvas>();

        if (scene.name == "Game")
        {
            BlockController blcok_control = FindFirstObjectByType<BlockController>();
            if (blcok_control != null)
            {
                blcok_control.InitBlocks();
            }
            else
            {
                // TODO: 오류 팝업
            }

            this.game_ui_control = FindFirstObjectByType<GameUIController>();
            if (this.game_ui_control != null)
            {
                this.game_ui_control.SetGameTurnPanel(GameUIController.GameTurnPanelType.None);
            }
            else
            {
                // TODO: 오류 팝업
            }

            // 게임 로직 생성
            this.game_logic = new GameLogic(blcok_control, this.game_type);

        }
    }

    /// <summary> Game Scene에서 턴을 표시하는 UI를 제어하는 함수 </summary>
    public void SetGameTurnPanel(GameUIController.GameTurnPanelType game_turn_panel_t)
    {
        this.game_ui_control.SetGameTurnPanel(game_turn_panel_t);
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

    public void OpenConfirmPanel(string msg, Action on_confirm_btn_callback)
    {
        if (canvas != null)
        {
            if (this.confirm_panel == null)
            {
                GameObject temp_confirm = Instantiate(this.confirm_panel_prefab, this.canvas.transform);
                this.confirm_panel = temp_confirm;
            }
            else
            {
                this.confirm_panel.gameObject.SetActive(true);
            }
            this.confirm_panel.GetComponent<ConfirmPanelController>().Show(msg, on_confirm_btn_callback);

        }
    }

    public void OpenSigninPanel()
    {
        if (canvas != null)
        {
            GameObject signin_panel_temp = Instantiate(signin_panel_prefab, canvas.transform);
            signin_panel_temp.GetComponent<SigninPanelController>().Show();
        }
    }

    public void OpenSignupPanel()
    {
        if (canvas != null)
        {
            GameObject signup_panel_temp = Instantiate(signup_panel_prefab, canvas.transform);
            signup_panel_temp.GetComponent<SignupPanelController>().Show();
        }
    }
}
