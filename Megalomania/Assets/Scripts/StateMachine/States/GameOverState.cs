using TMPro;
using UnityEngine;

public class GameOverState : BaseState<GameStateMachine.GameStates>
{
    private TextMeshProUGUI _gameOverText;
    private GameObject _gameOverPanel;
    public GameOverState(GameStateMachine.GameStates key, GameStateMachine gameStateMachine) : base(key)
    {
        _gameOverPanel = gameStateMachine.GameOVerPanel;
        _gameOverText = gameStateMachine.GameOverText;
    }

    public override void EnterToState()
    {
        _gameOverPanel.SetActive(true);
        _gameOverText.text = "Game is Over";
    }

    public override void ExitFromState()
    {
    }

    public override void UpdateState()
    {
    }


}
