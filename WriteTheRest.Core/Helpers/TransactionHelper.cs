using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriteTheRest.Core.Repository.Abstract;
using WriteTheRest.Core.Result; // Ensure this namespace contains the 'Result' type


namespace WriteTheRest.Core.Helpers
{
    public static class TransactionHelper
    {
        public static async Task<WriteTheRest.Core.Result.Result> ExecuteInTransactionAsync(IUnitOfWork unitOfWork, Func<Task<WriteTheRest.Core.Result.Result>> action)
        {
            try
            {
                await unitOfWork.BeginTransactionAsync();
                var result = await action();
                if (result.Success)
                {
                    await unitOfWork.SaveChangesAsync();
                    await unitOfWork.CommitTransactionAsync();
                }
                else
                {
                    await unitOfWork.RollbackTransactionAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransactionAsync();
                return new ErrorResult($"İşlem sırasında hata oluştu..! {ex.Message}");
            }
        }
    }
}