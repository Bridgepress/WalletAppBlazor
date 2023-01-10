using System.Text.Json;
using System;
using WalletApp.Client.DTO.TypeOfExpense;
using WalletApp.Domain.DTO.TypeOfExpense;

namespace WalletApp.Client.HttpRepositories
{
    public interface ITypeOfExpenseRepository
    {
        public Task<TypeOfExpenseDTO> CreateTypeOfExpense(TypeOfExpenseDTO typeOfExpenseDTO);

        public Task<TypeOfExpenseDTO> DeleteTypeOfExpense(Guid id);

        public Task<List<TypeOfExpenseDetatilsDTO>> GetAllTypeOfExpense();
    }
}
