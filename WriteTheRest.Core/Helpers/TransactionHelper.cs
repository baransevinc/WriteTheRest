using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteTheRest.Core.Helpers
{
    public static class TransactionHelper
    {
        public static async Task<Result> ExecuteInTransactionAsync(IUnitOfWork unitOfWork, Func<Task<Result>> action)
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
