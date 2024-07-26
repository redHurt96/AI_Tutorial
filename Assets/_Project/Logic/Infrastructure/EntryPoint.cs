using _Project.Common;
using _Project.RuleBasedAI.Implementation;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Button _ruleBasedAiButton0;
        [SerializeField] private Button _ruleBasedAiButton1;
        
        private CharactersRepository _charactersRepository;
        private CharacterFactory _characterFactory;
        private AiRepository _aiRepository;
        
        private RuleBasedAiFactory _ruleBasedFactory;

        private void Start()
        {
            _charactersRepository = new();
            _characterFactory = new(_charactersRepository);
            _aiRepository = new();
            _ruleBasedFactory = new(_characterFactory, _charactersRepository, _aiRepository);
            
            _ruleBasedAiButton0.onClick.AddListener(() => _ruleBasedFactory.Create(0));
            _ruleBasedAiButton1.onClick.AddListener(() => _ruleBasedFactory.Create(1));
        }

        private void OnDestroy()
        {
            _ruleBasedAiButton0.onClick.RemoveAllListeners();
            _ruleBasedAiButton1.onClick.RemoveAllListeners();
        }

        private void Update()
        {
            foreach (IAiBrain brain in _aiRepository.AiBrains)
                brain.Update();

            foreach (Character character in _charactersRepository.All)
                character.Update();
        }
    }
}
