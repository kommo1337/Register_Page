using Microsoft.Office.Interop.Excel;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using Register_Page.WindowFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register_Page.ClassFolder
{
    class DateStorage
    {
        private List<Client> deletedClients = new List<Client>();
        

        public void ArchiveClient(Client client)
        {
            deletedClients.Add(client);
        }

        public void RestoreClient(int clientId)
        {
            var restoredClient = deletedClients.FirstOrDefault(c => c.ClientId == clientId);

            if (restoredClient != null)
            {

                DBEntities.GetContext().Client.Add(restoredClient);

                // Удалите клиента из коллекции удаленных данных
                deletedClients.Remove(restoredClient);
            }
        }

        public List<Client> GetDeletedClients()
        {
            return deletedClients;
        }
    }
}
