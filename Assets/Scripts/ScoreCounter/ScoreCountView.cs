using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.ScoreCounter
{
    public class ScoreCountView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _count;

        private ScoreCounter _scoreCounter;
        
        [Inject]
        private void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
            _scoreCounter.KillCountChanged += UpdateView;
        }

        private void UpdateView(int value)
        {
            _count.text = value.ToString();
        }

        private void OnDestroy()
        {
            _scoreCounter.KillCountChanged -= UpdateView;
        }
    }
}