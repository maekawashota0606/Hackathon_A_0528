using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RandomDungeonWithBluePrint
{
    public class MapGenerator : SingletonMonoBehaviour<MapGenerator>
    {
        [Serializable]
        public class BluePrintWithWeight
        {
            public FieldBluePrint BluePrint = default;
            public int Weight = default;
        }

        [SerializeField] private BluePrintWithWeight[] bluePrints = default;

        public void GenerateMap(int seed)
        {
            Random.InitState(seed);
            Create(Raffle());
        }

        private void Create(BluePrintWithWeight bluePrint)
        {
            var field = FieldBuilder.Build(bluePrint.BluePrint);
            Map.Instance.ShowField(field);
        }

        private BluePrintWithWeight Raffle()
        {
            var candidate = bluePrints.ToList();
            var rand = Random.Range(0, candidate.Sum(c => c.Weight));
            var pick = 0;
            for (var i = 0; i < candidate.Count; i++)
            {
                if (rand < candidate[i].Weight)
                {
                    pick = i;
                    break;
                }

                rand -= candidate[i].Weight;
            }

            return candidate[pick];
        }
    }
}
