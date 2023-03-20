using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace laba4_309_Tebenko_Andrew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type employeeInfo = typeof(Employee);
            Console.WriteLine(employeeInfo);

            Employee employee = new Employee("Andrew", "Tebenko", 20, "Front-end developer");
            PropertyInfo position = employeeInfo.GetProperty("Position", BindingFlags.Instance | BindingFlags.NonPublic);
            PropertyInfo age = employeeInfo.GetProperty("Age"); // public
            PropertyInfo isActive = employeeInfo.GetProperty("IsActive", BindingFlags.Instance | BindingFlags.NonPublic);
            
            Console.WriteLine(position);
            Console.WriteLine(position.GetValue(employee));
            Console.WriteLine(age.GetValue(employee));
            Console.WriteLine(isActive.GetValue(employee));
            separate();

            getPropertiesInfo(employeeInfo);

            var methodInfo = employeeInfo.GetMethod("getFullName");

            var fullname = methodInfo.Invoke(employee, null);
            Console.WriteLine(fullname);
            separate();

            TypeInfo employeeTypeInfo = typeof(Employee).GetTypeInfo();
            PropertyInfo[] props = employeeInfo.GetProperties();

            foreach (PropertyInfo property in props)
            {
                Console.WriteLine("   {0} ({1}): {2}", property.Name,
                                  property.PropertyType.Name,
                                  property.GetValue(employee));
            }
            separate();

            Type theType = Type.GetType("laba4_309_Tebenko_Andrew.Employee");
            Console.WriteLine("\nSingle Type is {0}\n", theType);
            MemberInfo[] mbrInfoArray = theType.GetMembers();
            foreach (MemberInfo mbrInfo in mbrInfoArray)
            {
                Console.WriteLine("{0}\t\t\t{1}", mbrInfo.MemberType, mbrInfo.Name);
            }
            separate();

            FieldInfo[] fieldInfo = employeeInfo.GetFields();

            logFieldInfo(fieldInfo, employee);

            foreach (FieldInfo info in fieldInfo)
            {
                switch (info.Name)
                {
                    case "hasMentor":
                        info.SetValue(employee, true);
                        break;
                    case "InstanceCase":
                        info.SetValue(employee, employee);
                        break;
                }
            }

            logFieldInfo(fieldInfo, employee);
            separate();

            var methods = employeeInfo.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                                               .Where(m => !m.IsSpecialName);
            foreach (MethodInfo info in methods)
            {
                if (info.GetParameters().Count() != 0) continue;
                Console.Write($"\t{info.Name}: ");

                var result = info.Invoke(employee, null);
                Console.WriteLine(result != null ? result : "__void__");
            }

            Console.ReadKey();
        }
        static void getPropertiesInfo(Type type)
        {
            foreach (PropertyInfo property in type.GetProperties(
                   BindingFlags.Instance | BindingFlags.NonPublic |
                   BindingFlags.Public | BindingFlags.Static))
            {
                Console.Write($"{property.PropertyType} {property.Name} {{");

                if (property.CanRead) Console.Write("get;");
                if (property.CanWrite) Console.Write("set;");
                Console.WriteLine("}");
            }
            separate();
        }
        static void logFieldInfo(FieldInfo[] fi, Object obj)
        {
            foreach (FieldInfo info in fi)
            {
                Console.WriteLine(info.Name + ": " +
                   info.GetValue(obj).ToString());
            }
        }
        static void separate()
        {
            Console.WriteLine("\n<---------------------------->\n");
        }
    }
}