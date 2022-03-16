using System;
using System.Threading.Tasks;

namespace ExpensesApp.Interfaces
{
    public interface IShare
    {
        Task Show(string title, string message, string filePath);
    }
}