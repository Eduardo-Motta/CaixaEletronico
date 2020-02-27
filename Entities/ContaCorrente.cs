using Dapper.Contrib.Extensions;

namespace Entities
{
    [Table("ContaCorrentes")]
    public class ContaCorrente
    {
        [Key]
        public long Conta { get; set; }

        public decimal Saldo { get; set; }
    }
}
