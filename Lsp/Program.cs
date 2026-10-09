using Lsp;
using Lsp.Frameworks;

Console.WriteLine("Hello, World!");
List<IContact> contacts = new List<IContact>();

contacts.Add(new Email());
contacts.Add(new Tel());
contacts.Add(new Sms());