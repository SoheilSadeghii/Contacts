using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    interface IContactRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int contactId);
        DataTable Search(string parameter);
        bool Insert(string name, string family, int age, string mobile, string email, string address);
        bool Update(int contactId, string name, string family, int age, string mobile, string email, string address);
        bool Delete(int contactId);
    }
}
