using CampanhaBrinquedo.Domain.Entities.Child;
using System.Collections.Generic;

namespace CampanhaBrinquedo.Domain.Repositories
{
    public interface IChildImportRepository
    {
        IEnumerable<ChildImport> GetImports(string xmlFile);
    }
}
