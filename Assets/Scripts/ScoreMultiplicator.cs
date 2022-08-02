using Assets.Scripts.Obstacles;
using UnityEngine;

namespace Assets.Scripts {
    public class ScoreMultiplicator {
        private ScoreMultiplicator() { }

        public static ScoreMultiplicator GetInstance() =>
            instance ?? new ScoreMultiplicator();

        private static ScoreMultiplicator instance;

        private float positiveCount;
        private float negativeCount;

        private float posMultiplicator;
        private float negMultiplicator;

        public void Add(Collectable collectable) {
            if(collectable.GetType() == CollectableType.Positive)
                AddPositive(collectable.GetMultiplicator());
            else
                AddNegative(collectable.GetMultiplicator());

        }

        public void AddPositive(float posMultiplicator) {
            positiveCount++;
            this.posMultiplicator += posMultiplicator;
        }
        public void AddNegative(float negMultiplicator) {
            negativeCount++;
            this.negMultiplicator += negMultiplicator;
        }

        public float GetMultiplicator() {
            float result = (positiveCount * posMultiplicator) + (negativeCount * negMultiplicator);

            if(result <= 0) return 0;
            return result;
        }
    }
}