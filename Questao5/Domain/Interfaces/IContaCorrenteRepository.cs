﻿using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente?> GetContaCorrenteByIdAsync(string id);
    }
}
