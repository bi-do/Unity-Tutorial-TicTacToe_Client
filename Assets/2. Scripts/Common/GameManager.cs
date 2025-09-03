using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class GameManager : Singleton<GameManager>
{
    /// <summary> Main Scene에서 선택한 게임 타입의 변수 </summary>
    private Constants.GameType game_type;

    [SerializeField] GameObject confirm_panel_prefab;
    private GameObject confirm_panel;

    private Canvas canvas;

    private GameLogic game_logic;

    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        this.canvas = FindFirstObjectByType<Canvas>();

        if (scene.name == "Game")
        {
            BlockController blcok_control = FindFirstObjectByType<BlockController>();
            blcok_control.InitBlocks();
            if (this.game_logic != null)
            {

            }
            else
            {
                this.game_logic = new GameLogic(blcok_control, this.game_type);
            }
        }
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

    public void OpenConfirmPanel(string msg , Action on_confirm_btn_callback)
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
}
