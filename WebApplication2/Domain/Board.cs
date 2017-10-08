using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication2.Domain.Task;

namespace WebApplication2.Domain
{
    /// <summary>
    /// a Board that contains 
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Identification
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Board Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection's Tasks
        /// </summary>
        public TaskCollection Items { get; }


        /// <summary>
        /// Initialize a Board with a random Id
        /// </summary>
        public Board()
        {
            Id = Guid.NewGuid();
            Items = new TaskCollection(this);
        }

        public override string ToString() => $"{Id} - {Name} - {Items.Count} task(s)";
    }
}
