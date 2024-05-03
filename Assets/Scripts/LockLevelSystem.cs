using Infrastructure;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LockLevelSystem : MonoBehaviour
{
    [SerializeField] private Button[] levels;
    [Inject] private GameData gameData;

    private void Awake()
    {
        for (var i = 0; i < levels.Length; i++) levels[i].interactable = i < gameData.unlockedLevels;
    }
}