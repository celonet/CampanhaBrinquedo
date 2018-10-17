using System;

namespace CampanhaBrinquedo.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public DateTime RegisterDate { get; protected set; }

        public void IncluiDataCadastro() => RegisterDate = DateTime.Now;

        public void IncluiDataCadastro(DateTime date) => RegisterDate = date;
    }
}
