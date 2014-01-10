using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;

namespace HTMLRenderer
{
	public interface IElement
	{
		string Name { get; }
		string TextContent { get; set; }
		IEnumerable<IElement> ChildElements { get; }
		void AddElement(IElement element);
		void Render(StringBuilder output);
		string ToString();
	}

	public interface ITable : IElement
	{
		int Rows { get; }
		int Cols { get; }
		IElement this[int row, int col] { get; set; }
	}

    public interface IElementFactory
    {
		IElement CreateElement(string name);
		IElement CreateElement(string name, string content);
		ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
		public IElement CreateElement(string name)
		{
            IElement newElement = new HTMLElement(name, "");
            return newElement;
		}

		public IElement CreateElement(string name, string content)
		{
            IElement newElement = new HTMLElement(name, content);
            return newElement;
		}

		public ITable CreateTable(int rows, int cols)
		{
            ITable newTable = new HTMLTable(rows, cols);
            return newTable;
		}
	}

    public class HTMLElement : IElement
    {
        private IList<IElement> childElements;

        public HTMLElement(string name, string textContent)
        {
            this.Name = name;
            this.TextContent = textContent;
            this.childElements = new List<IElement>();
        }


        public string Name { get; private set; }

        public string TextContent { get; set; }

        public IEnumerable<IElement> ChildElements
        {
            get { return this.childElements; }
        }

        public void  AddElement(IElement element)
        {
            ((IList<IElement>)this.ChildElements).Add(element);
        }

        public void  Render(StringBuilder output)
        {
            //string pattern = "<(name)>(text_content)(child_content)</(name)>";
            StringBuilder helper = new StringBuilder();
            if (this.TextContent.Contains('&'))
            {
                //this.TextContent.Replace("&", "&amp;");
                for (int i = 0; i < this.TextContent.Length; i++)
                {
                    if (this.TextContent[i] == '&')
                    {
                        helper.Append("&amp;");
                    }
                    else
                    {
                         helper.Append(this.TextContent[i]);
                    }
                }
                this.TextContent = helper.ToString();
                helper.Clear();
            }
            if (this.TextContent.Contains('<'))
            {
                //this.TextContent.Replace("<", "&lt;");
                for (int i = 0; i < this.TextContent.Length; i++)
                {
                    if (this.TextContent[i] == '<')
                    {
                        helper.Append("&lt;");
                    }
                    else
                    {
                        helper.Append(this.TextContent[i]);
                    }
                }
                this.TextContent = helper.ToString();
                helper.Clear();
            }
            if (this.TextContent.Contains('>'))
            {
                //this.TextContent.Replace(">", "&gt;");
                for (int i = 0; i < this.TextContent.Length; i++)
                {
                    if (this.TextContent[i] == '>')
                    {
                        helper.Append("&gt;");
                    }
                    else
                    {
                        helper.Append(this.TextContent[i]);
                    }
                }
                this.TextContent = helper.ToString();
                helper.Clear();
            }
            if (this.ChildElements.Count() > 0)
            {
                output.AppendFormat("<{0}>{1}", this.Name, this.TextContent ?? "");
                for (int i = 0; i < this.ChildElements.Count(); i++)
                {
                    if (this.childElements[i].Name == "table")
                    {
                        output.Append(this.childElements[i].ToString());
                    }
                    else if(this.childElements[i].TextContent != null)
                    {
                        if (this.childElements[i].TextContent.Contains('&'))
                        {
                            //this.childElements[i].TextContent.Replace("&", "&amp;");
                            for (int k = 0; k < this.childElements[i].TextContent.Length; k++)
                            {
                                if (this.childElements[i].TextContent[k] == '&')
                                {
                                    helper.Append("&amp;");
                                }
                                else
                                {
                                    helper.Append(this.childElements[i].TextContent[k]);
                                }
                            }
                            this.childElements[i].TextContent = helper.ToString();
                            helper.Clear();
                        }
                        if (this.childElements[i].TextContent.Contains('<'))
                        {
                            //this.childElements[i].TextContent.Replace("<", "&lt;");
                            for (int k = 0; k < this.childElements[i].TextContent.Length; k++)
                            {
                                if (this.childElements[i].TextContent[k] == '<')
                                {
                                    helper.Append("&lt;");
                                }
                                else
                                {
                                    helper.Append(this.childElements[i].TextContent[k]);
                                }
                            }
                            this.childElements[i].TextContent = helper.ToString();
                            helper.Clear();
                        }
                        if (this.childElements[i].TextContent.Contains('>'))
                        {
                            //this.childElements[i].TextContent.Replace(">", "&gt;");
                            for (int k = 0; k < this.childElements[i].TextContent.Length; k++)
                            {
                                if (this.childElements[i].TextContent[k] == '>')
                                {
                                    helper.Append("&gt;");
                                }
                                else
                                {
                                    helper.Append(this.childElements[i].TextContent[k]);
                                }
                            }
                            this.childElements[i].TextContent = helper.ToString();
                            helper.Clear();
                        }
                        if (this.childElements[i].Name != null)
                        {
                            output.AppendFormat("<{0}>{1}</{2}>", this.childElements[i].Name, this.childElements[i].TextContent ?? "", this.childElements[i].Name);
                        }
                        else
                            output.AppendFormat("{0}", this.childElements[i].TextContent ?? "");
                    }
                }
                output.AppendFormat("</{0}>", this.Name);
            }
            else
            {
                if (this.Name != null)
                {
                    output.AppendFormat("<{0}>{1}</{2}>", this.Name, this.TextContent ?? "", this.Name);
                }
                else
                    output.AppendFormat("{0}", this.TextContent ?? "");
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }
    }

    public class HTMLTable : ITable
    {
        private HTMLElement[,] cells;
        readonly string name = "table";
        public HTMLTable(int row, int col)
        {
            this.Rows = row;
            this.Cols = col;
            this.cells = new HTMLElement[row, col];
        }

        public int Rows
        {
            get;
            private set;
        }

        public int Cols
        {
            get;
            private set;
        }

        public IElement this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= this.Rows || col < 0 || col >= this.Cols)
                {
                    throw new IndexOutOfRangeException("You are trying to take an element, that doesn't exist!");
                }
                return this.cells[row, col];
            }
            set { this.cells[row, col] = (HTMLElement)value; }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
            }
        }

        public string TextContent { get; set; }

        public IEnumerable<IElement> ChildElements { get; private set; }

        public void AddElement(IElement element)
        {
        }

        public void Render(StringBuilder output)
        {
            //string sth = "<table><tr><td>(cell_0_0)</td><td>(cell_0_1)</td>…</tr><tr><td>(cell_1_0)</td><td>(cell_1_1)</td>…</tr>…</table>";
            output.Append("<table>");
            for (int i = 0; i < this.Rows; i++)
            {
                output.Append("<tr>");
                for (int k = 0; k < this.Cols; k++)
                {
                    output.Append("<td>");
                    output.Append(this[i, k]);
                    output.Append("</td>");
                }
                output.Append("</tr>");
            }
            output.Append("</table>");
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }
    }

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
            //IElementFactory htmlFactory = new HTMLElementFactory();
            //IElement html = htmlFactory.CreateElement("html");
            //IElement h1 = htmlFactory.CreateElement("h1", "Welcome!");
            //html.AddElement(h1);
            //Console.WriteLine(html);
            //ITable table = htmlFactory.CreateTable(3, 2);
            //table[0, 0] = htmlFactory.CreateElement("b", "First Name");
            //table[0, 1] = htmlFactory.CreateElement("b", "Last Name");
            //table[1, 0] = htmlFactory.CreateElement(null, "Svetlin");
            //table[1, 1] = htmlFactory.CreateElement(null, "Nakov");
            //table[2, 0] = htmlFactory.CreateElement(null, "George");
            //table[2, 1] = htmlFactory.CreateElement(null, "Georgiev");
            //html.AddElement(table);
            //IElement br = htmlFactory.CreateElement("br", null);
            //html.AddElement(br);
            //IElement div = htmlFactory.CreateElement("div",
            //  "(c) Nakov & Joro @ <Telerik Software Academy>");
            //html.AddElement(div);
            //Console.WriteLine(html);

			string csharpCode = ReadInputCSharpCode();
			CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
