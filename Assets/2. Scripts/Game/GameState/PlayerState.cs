using UnityEngine;

public class PlayerState : BasePlayerState
{
    private bool isFirstPlayer;
    private Constants.PlayerType player_t;


    public PlayerState(bool isFirstPlayer)
    {
        this.isFirstPlayer = isFirstPlayer;
        player_t = isFirstPlayer ? Constants.PlayerType.O : Constants.PlayerType.X;
    }


    #region 추상 메서드
    public override void OnEnter(GameLogic game_logic)
    {
        // 1. First Player인지 확인해서 게임 UI에 현재 턴 표시

        GameUIController.GameTurnPanelType cur_player_type_ui = isFirstPlayer ? GameUIController.GameTurnPanelType.OTurn : GameUIController.GameTurnPanelType.XTurn;
        GameManager.Instance.SetGameTurnPanel(cur_player_type_ui);

        // 2. Blcok Controller에게 해야 할 일을 전달
        game_logic.block_control.on_block_click_callback = (row, col) =>
        {
            HandleMove(game_logic, row, col);
        };
    }

    public override void OnExit(GameLogic game_logic)
    {
        game_logic.block_control.on_block_click_callback = null;
    }

    public override void HandleMove(GameLogic game_logic, int row, int col)
    {
        ProcessMove(game_logic, player_t, row, col);
    }

    protected override void HandleNextTurn(GameLogic game_logic)
    {
        if (isFirstPlayer)
        {
            game_logic.SetState(game_logic.second_player_state);
        }
        else
        {
            game_logic.SetState(game_logic.first_player_state);
        }
    }



    #endregion

}
