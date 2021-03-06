/*
 * Date: 10.08.2012
 * Time: 21:23
 */
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace ISBLScan.ViewCode
{
	/// <summary>
	/// Отчёт (аналитический отчёт).
	/// </summary>
	public class ReportIntegrate : LoaderCommon
	{
		public ReportIntegrate(SqlConnection sqlConnect) : base(sqlConnect)
		{
		}

		public Node Load()
		{
			Node listNode = null;
			if(this.checkTableExist("MBReports"))
			{
				listNode = new Node();
				listNode.Name = "Интегрированный отчёт";
				listNode.Text = null;
				listNode.Parent = null;
				listNode.Nodes = new List<Node>();
				
				{
					SqlCommand command = new SqlCommand();
					command.Connection = connection;
					command.CommandText = "select XRecID, NameRpt, Comment, Exprn, Report, Viewer from MBReports where TypeRpt='MBAnalitV' order by NameRpt ASC";
					SqlDataReader reader = command.ExecuteReader();
					if(reader.HasRows)
					{
						while(reader.Read())
						{
							Node reportNode = new Node();
							reportNode.Parent = listNode;
							//ИД отчёта
							reportNode.Id = reader.GetInt32(0);
							//Имя отчёта
							if(! reader.IsDBNull(1))
							{
								reportNode.Name = reader.GetString(1);
							}
							//Описание отчёта
							if(! reader.IsDBNull(2))
							{
								reportNode.Text = reader.GetString(2);
							}
							reportNode.Nodes = new List<Node>();
							//Шаблон отчёта
							if(! reader.IsDBNull(4))
							{
								SqlBytes sqlbytes = reader.GetSqlBytes(4);
								System.Text.Encoding win1251 = System.Text.Encoding.GetEncoding(1251);
								string scriptText = win1251.GetString(sqlbytes.Value);
								Node reportTextNode = new Node();
								reportTextNode.Name = "-=[ Шаблон ]=-";
								reportTextNode.Text = scriptText;
								reportTextNode.Parent = reportNode;
								reportNode.Nodes.Add(reportTextNode);
							}
							//Расчёт отчёта
							if(! reader.IsDBNull(3))
							{
								string templateText = reader.GetString(3);
								Node reportTemplateNode = new Node();
								reportTemplateNode.Name = "-=[ Расчёт ]=-";
								reportTemplateNode.Text = templateText;
								reportTemplateNode.Parent = reportNode;
								reportNode.Nodes.Add(reportTemplateNode);
							}
							listNode.Nodes.Add(reportNode);
						}
					}
					reader.Close();
				}				
			}
			return listNode;
		}

	}
}
