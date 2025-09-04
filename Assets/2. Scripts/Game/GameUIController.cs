using UnityEngine;
using UnityEngine.UI;


public class GameUIController : MonoBehaviour
{

    [SerializeField] private GameObject player_o_turn_panel;
    [SerializeField] private GameObject player_x_turn_panel;
    [SerializeField] public Button back_btn;
    [SerializeField] public Button setting_btn;

    public enum GameTurnPanelType{ None, OTurn, XTurn}

    void Awake()
    {
        this.back_btn.onClick.AddListener(OnBackBtn);
        this.setting_btn.onClick.AddListener(OnSetthingBtn);
    }


    public void OnBackBtn()
    {
        // GameManager.Instance.ChangeToMainScene()
        GameManager.Instance.OpenConfirmPanel("게임을 종료하시겠습니까?", GameManager.Instance.ChangeToMainScene);
    }

    public void OnSetthingBtn()
    {

    }

    public void SetGameTurnPanel(GameTurnPanelType game_turn_panel_t)
    {
        switch (game_turn_panel_t)
        {
            case GameTurnPanelType.None:
                player_o_turn_panel.SetActive(false);
                player_x_turn_panel.SetActive(false);
                break;
            case GameTurnPanelType.OTurn:
                player_o_turn_panel.SetActive(true);
                player_x_turn_panel.SetActive(false);
                break;
            case GameTurnPanelType.XTurn:
                player_o_turn_panel.SetActive(false);
                player_x_turn_panel.SetActive(true);
                break;
        }
    }
}