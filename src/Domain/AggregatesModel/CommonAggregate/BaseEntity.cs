using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.CommonAggregate
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? CreatedBy { get; set; } = "SYSTEM";
        public string? UpdatedBy { get; set; } = "SYSTEM";
        public DateTimeOffset? DateTimeCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? DateTimeUpdated { get; set; } = DateTimeOffset.Now;
    }
}