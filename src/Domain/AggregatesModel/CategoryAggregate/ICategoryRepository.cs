using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.CategoryAggregate
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> RetrieveCategoryAsync(Expression<Func<Category, bool>> criteria);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void AddCategoryAsync(List<Category> category);
        void UpdateCategoryAsync(List<Category> category);
        void UpdateCategoryAsync(Category category);
    }
}
