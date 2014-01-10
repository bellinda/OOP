using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Collections.Generic;
using System.Reflection;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private string name;
        public List<ICourse> courses = new List<ICourse>();

        public Teacher(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value != null)
                {
                    this.name = value;
                }
                else
                    throw new ArgumentNullException("The name of the teacher can not be null");
            }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Teacher: Name={0}", this.Name);
            if (this.courses.Count > 0)
            {
                output.Append("; Courses=[");
                for (int i = 0; i < this.courses.Count - 1; i++)
                {
                    output.AppendFormat("{0}, ", this.courses[i].Name);
                }
                output.AppendFormat("{0}]", this.courses[this.courses.Count - 1].Name);
            }
            return output.ToString();
        }
    }

    public class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        public List<string> topics = new List<string>();

        public Course(string name, ITeacher teacher)
        {
            this.name = name;
            this.teacher = teacher;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value != null)
                {
                    this.name = value;
                }
                else
                    throw new ArgumentNullException("The name of the course can not be null");
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;   //can be null !!!
            }
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}: Name={1}; ", this.GetType().Name, this.Name);
            if (this.Teacher != null)
            {
                output.AppendFormat("Teacher={0}; ", this.Teacher.Name);
            }
            if (this.topics.Count > 0)
            {
                output.Append("Topics=[");
                for (int i = 0; i < this.topics.Count - 1; i++)
                {
                    output.AppendFormat("{0}, ", this.topics[i]);
                }
                output.AppendFormat("{0}]; ", this.topics[this.topics.Count - 1]);
            }

            return output.ToString();
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (value != null)
                {
                    this.lab = value;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}Lab={1}", base.ToString(), this.Lab);
            return output.ToString();
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (value != null)
                {
                    this.town = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}Town={1}", base.ToString(), this.Town);
            return output.ToString();
        }
    }

    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            Teacher teacher = new Teacher(name);
            return teacher;
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            LocalCourse local = new LocalCourse(name, teacher, lab);
            return local;
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            OffsiteCourse offsite = new OffsiteCourse(name, teacher, town);
            return offsite;
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            //CourseFactory factory = new CourseFactory();
            //ITeacher nakov = factory.CreateTeacher("Nakov");
            //Console.WriteLine(nakov);
            //nakov.Name = "Svetlin Nakov";
            //ICourse oop = factory.CreateLocalCourse("OOP", nakov, "Light");
            //oop.AddTopic("Using Classes and Objects");
            //oop.AddTopic("Defining Classes");
            //oop.AddTopic("OOP Principles");
            //oop.AddTopic("Teamwork");
            //oop.AddTopic("Exam Preparation");
            //Console.WriteLine(oop);
            //ICourse html = factory.CreateOffsiteCourse("HTML", nakov, "Plovdiv");
            //html.AddTopic("Using Classes and Objects");
            //html.AddTopic("Defining Classes");
            //html.AddTopic("OOP Principles");
            //html.AddTopic("Teamwork");
            //html.AddTopic("Exam Preparation");
            //Console.WriteLine(html);
            //nakov.AddCourse(oop);
            //nakov.AddCourse(html);
            //Console.WriteLine(nakov);
            //oop.Name = "Object-Oriented Programming";
            //(oop as ILocalCourse).Lab = "Enterprise";
            //oop.Teacher = factory.CreateTeacher("George Georgiev");
            //oop.AddTopic("Practical Exam");
            //Console.WriteLine(oop);
            //html.Name = "HTML Basics";
            //(html as IOffsiteCourse).Town = "Varna";
            //html.Teacher = oop.Teacher;
            //html.AddTopic("Practical Exam");
            //Console.WriteLine(html);
            //ICourse css = factory.CreateLocalCourse("CSS", null, "Ultimate");
            //Console.WriteLine(css);
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
                  using SoftwareAcademy;

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
