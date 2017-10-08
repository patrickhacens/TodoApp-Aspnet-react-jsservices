using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Domain
{
    public partial class Task
    {
        /// <summary>
        /// Collection of Todo to maintain reference between Board and Todo
        /// </summary>
        public class TaskCollection : ICollection<Task>
        {
            /// <summary>
            /// Owner Board
            /// </summary>
            public Board Board { get; }

            /// <summary>
            /// inner list to track Todos
            /// </summary>
            private List<Task> innerList = new List<Task>();

            /// <summary>
            /// Initialize a TaskCollection that belongs to a board
            /// </summary>
            /// <param name="board">Board that it belongs to</param>
            public TaskCollection(Board board)
            {
                this.Board = board;
            }
            /// <summary>
            /// Gets or sets a Task at the index position
            /// </summary>
            /// <param name="index">position of the task</param>
            /// <returns>Task at the specified index position</returns>
            public Task this[int index] { get => innerList[index]; set => innerList[index] = value; }

            /// <summary>
            /// Quantity of Tasks
            /// </summary>
            public int Count => innerList.Count;

            /// <summary>
            /// This collection is not read-only
            /// </summary>
            public bool IsReadOnly => false;

            /// <summary>
            /// Inserts a new task and sets it's board to this collection owner
            /// </summary>
            /// <param name="item">task to insert</param>
            public void Add(Task item)
            {
                if (item.Board != null)
                    item.Board.Items.Remove(item);

                innerList.Add(item);
                item._board = this.Board;
            }

            /// <summary>
            /// Inserts a group of Tasks
            /// </summary>
            /// <param name="items">tasks to insert</param>
            public void AddRange(IEnumerable<Task> items)
            {
                foreach (var item in items) Add(item);
            }

            /// <summary>
            /// Inserts a group of Tasks
            /// </summary>
            /// <param name="items">tasks to insert</param>
            public void AddRange(params Task[] items) => AddRange(items.AsEnumerable());

            /// <summary>
            /// Remove all tasks from this collection and sets it's Board to null
            /// </summary>
            public void Clear()
            {
                Parallel.ForEach(this.innerList, (i) => i._board = null); // does it work?
                innerList.Clear();
            }

            /// <summary>
            /// returns whether or not this Collection contains a task
            /// </summary>
            /// <param name="item">task to compare</param>
            public bool Contains(Task item) => innerList.Contains(item);

            public void CopyTo(Task[] array, int arrayIndex) => innerList.CopyTo(array, arrayIndex);

            /// <summary>
            /// Remove a task from this collection
            /// </summary>
            /// <param name="item">task to remove</param>
            /// <returns>whether or not was possible to remove the task - false means task does not belong to this collection</returns>
            public bool Remove(Task item)
            {
                if (item.Board != this.Board) return false;
                item._board = null;
                return innerList.Remove(item);
            }

            public IEnumerator<Task> GetEnumerator() => innerList.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
