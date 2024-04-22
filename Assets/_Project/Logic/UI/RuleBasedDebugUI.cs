using _Project.Logic.Common;
using _Project.Logic.RuleBasedAI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static _Project.Logic.Common.CreepType;

namespace _Project.Logic.UI
{
    public class RuleBasedDebugUI : MonoBehaviour
    {
        [SerializeField] private Team _team;
        [SerializeField] private Button _melee;
        [SerializeField] private Button _range;
        
        private IRuleBasedAiFactory _ruleBasedAiFactory;

        [Inject]
        private void Construct(IRuleBasedAiFactory ruleBasedAiFactory) => 
            _ruleBasedAiFactory = ruleBasedAiFactory;

        private void Start()
        {
            _melee.onClick.AddListener(SpawnMelee);
            _range.onClick.AddListener(SpawnRange);
        }

        private void OnDestroy()
        {
            _melee.onClick.RemoveListener(SpawnMelee);
            _range.onClick.RemoveListener(SpawnRange);
        }

        private void SpawnMelee() => 
            _ruleBasedAiFactory.Spawn(_team, Melee);

        private void SpawnRange() => 
            _ruleBasedAiFactory.Spawn(_team, Range);
    }
}
