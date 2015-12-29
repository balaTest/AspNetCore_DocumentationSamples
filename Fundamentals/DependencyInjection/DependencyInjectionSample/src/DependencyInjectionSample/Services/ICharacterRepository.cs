using System.Collections.Generic;
using DependencyInjectionSample.Models;

namespace DependencyInjectionSample.Services
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> ListAll();
        void Add(Character character);
    }
}

