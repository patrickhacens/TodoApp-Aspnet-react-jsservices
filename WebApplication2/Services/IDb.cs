using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain;

namespace WebApplication2.Services
{
    public interface IDb
    {
        ObservableCollection<Board> Boards { get; }
    }
}
