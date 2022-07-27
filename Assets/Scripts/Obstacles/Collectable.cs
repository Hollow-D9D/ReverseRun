using UnityEngine;

namespace Assets.Scripts.Obstacles {
    public enum CollectableType {
        Positive,
        Negative
    }

    public class Collectable : MonoBehaviour {
        [SerializeField] protected CollectableType collectableType;

        [SerializeField] protected float collectableMulitiplicator;

        public float GetMultiplicator() => collectableMulitiplicator;
        public CollectableType GetType() => collectableType;
    }
}