using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.CategoryAggregate
{
    public interface ICategoryRepository
    {
        Task SaveDataAsync(IEnumerable<Category> categories);
    }
}
