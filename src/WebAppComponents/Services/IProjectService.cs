using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.WebAppComponents.Catalog;
using eShop.WebAppComponents.Game;

namespace eShop.WebAppComponents.Services
{
    public interface IProjectService
    {
        Task<List<ProjectItem>> GetProjects();
    }
}
