using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ReflectionLibrary;

class Program
{
    static void Main()
    {
        string libraryPath = "ReflectionLibrary.dll";
        Assembly assembly = Assembly.LoadFrom(libraryPath);

        XElement root = new XElement("Classes");

        foreach (Type type in assembly.GetTypes().Where(t => t.IsClass || t.IsAbstract))
        {
            XElement classElement = new XElement("Class",
                new XAttribute("Name", type.Name));

            var attribute = type.GetCustomAttribute<CommentAttribute>();
            if (attribute != null)
            {
                classElement.Add(new XAttribute("Comment", attribute.Comment));
            }

            foreach (var property in type.GetProperties())
            {
                XElement propertyElement = new XElement("Property",
                    new XAttribute("Name", property.Name),
                    new XAttribute("Type", property.PropertyType.Name));
                classElement.Add(propertyElement);
            }

            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                XElement methodElement = new XElement("Method",
                    new XAttribute("Name", method.Name),
                    new XAttribute("ReturnType", method.ReturnType.Name));
                classElement.Add(methodElement);
            }

            root.Add(classElement);
        }

        string xmlPath = "C:\\xml_handler\\goal.xml";
        root.Save(xmlPath);
        Console.WriteLine($"XML diagram saved to {xmlPath}");
    }
}
