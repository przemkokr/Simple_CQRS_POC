using System.ComponentModel.DataAnnotations;

namespace Simple_CQRS_POC.Domain.Base
{
    public abstract class EntityBase
    {
        [Required]
        public long Id { get; protected set; }
    }
}
