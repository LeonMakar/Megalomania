using TMPro;
using UnityEngine;

public class GameIsPassiveState : BaseState<GameStateMachine.GameStates>
{
    private TextMeshProUGUI _gameOverText;
    private GameObject _gameOverPanel;
    public GameIsPassiveState(GameStateMachine.GameStates key, GameStateMachine gameStateMachine) : base(key)
    {
        _gameOverPanel = gameStateMachine.GameOVerPanel;
        _gameOverText = gameStateMachine.GameOverText;
    }

    public override void EnterToState()
    {
        _gameOverPanel.SetActive(true);
        _gameOverText.text = "You Win";
    }

    public override void ExitFromState()
    {

    }

    public override void UpdateState()
    {

    }

}
