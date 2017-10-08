using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication2.Domain
{
    /// <summary>
    /// Represents a Task to be done in the system
    /// </summary>
    public partial class Task
    {
        /// <summary>
        /// Identification
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Task title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Whether the task has been completed or not
        /// </summary>
        public bool Done { get; set; }

        private Board _board;

        /// <summary>
        /// The board that the task belongs to
        /// </summary>
        public Board Board
        {
            get => _board;
            set
            {
                if (value != _board)
                {
                    Board?.Items.Remove(this);
                    value?.Items.Add(this);
                }
            }
        }

        /// <summary>
        /// Initialize the task with a random Id
        /// </summary>
        public Task()
        {
            this.Id = Guid.NewGuid();
        }

    }
}