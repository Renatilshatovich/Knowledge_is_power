using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "StaticData/Monster")]
    public class MonsterStaticData : ScriptableObject
    {
        public MonsterTypeId MonsterTypeId;
    
        [Range(1,100)]
        public int Hp = 50;
    
        [Range(1,30)]
        public float Damage = 10;
    
        [Range(0,10)]
        public float MoveSpeed = 3;
        
        [Range(.5f,1)]
        public float EffectiveDistance = .5f;
    
        [Range(.5f,1)]
        public float Cleavage = .5f;
        
        public GameObject Prefab;
    }
}