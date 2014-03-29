namespace ISBLScan.ViewCode
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Узел дерева элементов разработки
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets or sets ИД записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Код записи, группы, вида, ...
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets Имя узла, отображаемое в дереве
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Текст отображаемый при выборе узла
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets Признак того, что узел явялется конечным
        /// </summary>
        public bool Flag { get; set; }
	
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="Node"/> is visible.
	/// </summary>
	/// <value>
	/// <c>true</c> if visible; otherwise, <c>false</c>.
	/// </value>
	public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets Список подузлов
        /// </summary>
        public List<Node> Nodes { get; set; }

        /// <summary>
        /// Gets or sets Список родительского узла
        /// </summary>
        public Node Parent { get; set; }

	public Node()
	{
			Visible = true;
			Flag = true;
	}
    }
	/// <summary>
	/// Description of Tree.
	/// </summary>
	public class Tree
	{
		public Tree()
		{
			
		}
	}
}