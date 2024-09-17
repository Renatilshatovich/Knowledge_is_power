using System.Collections.Generic;
using CodeBase.Services;
using CodeBase.Services.PersistentProgress;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        
        void Register(ISavedProgressReader savedProgress);
        
        GameObject CreateMonster(MonsterTypeId typeId, Transform parent);
        GameObject CreateHero(GameObject at);
        GameObject CreateHud();
        
        GameObject HeroGameObject { get; }
        
        void Cleanup();
        GameObject CreateLoot();
    }
}