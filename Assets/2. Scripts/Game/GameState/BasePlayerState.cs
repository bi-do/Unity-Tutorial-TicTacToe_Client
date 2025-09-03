public abstract class BasePlayerState
{
    /// <summary> 상태 시작 </summary>
    public abstract void OnEnter(GameLogic game_logic);

    /// <summary> 상태 종료 </summary>
    public abstract void OnExit(GameLogic game_logic);

    /// <summary> 마커 표시 </summary>
    public abstract void HandleMove(GameLogic game_logic, int row, int col);

    /// <summary> 턴 전환 </summary>
    protected abstract void HandleNextTurn(GameLogic game_logic);

    /// <summary> 게임 결과 처리 </summary>
    protected void ProcessMove(GameLogic game_logic, Constants.PlayerType player_t, int row, int col)
    {
        if (game_logic.SetNewBoardValue(player_t, row, col))
        {
            GameLogic.GameResult game_result = game_logic.CheckGameResult();
            
            if (game_result == GameLogic.GameResult.None)
            {
                HandleNextTurn(game_logic);
            }
            else
            {
                game_logic.EndGame(game_result);
            }
        }
        else
        {

        }
    }
}