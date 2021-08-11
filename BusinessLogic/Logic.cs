using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using EmailHandling;
using PcResources;
using System.Data;
using System.Data.Entity;

namespace BusinessLogic
{
    public class Logic
    {

        private readonly ResourceDatabaseContext _context;
        private readonly Resources _pcResources;
        private readonly EmailSender _emailHandling;

        public Logic()
        {
            _pcResources = new Resources();
            _emailHandling = new EmailSender();
            _context = new ResourceDatabaseContext();
        }

        public async Task ServiceExecution()
        {

            List<double> resources = _pcResources.GetResources();

            for (int i = 0; i <= 2; i++)
            {
                await InsertResource(i + 1, resources[i]);
            }

            IEnumerable<Suscriber> suscribers = await SelectEmails();

            SendingEmail(resources, suscribers);

        }

        private async Task<bool> InsertResource(int _resourceKindId, double _value)
        {

            try
            {
                _context.Resource.Add(new Resource 
                {
                    Value = _value,
                    ResourceKindId = _resourceKindId,
                    Date = DateTime.Now
                });
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e) { return false; }

        }

        private async Task<IEnumerable<Suscriber>> SelectEmails()
        {

            try
            {
                return await _context.Suscriber.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private void SendingEmail(List<double> resources, IEnumerable<Suscriber> suscribers)
        {


            if (resources[0] > 80)
            {

                if (resources[1] > 70 && resources[2] > 50)
                {
                    foreach (var suscriber in suscribers)
                    {
                        _emailHandling.SendEmail(suscriber.Mail, "Aumento en la Memoria Ram, Unidad Central de Procesamiento y Disco Duro",
                            $"La memoria ram, la Unidad Central de Procesamiento y Disco Duro " +
                            $"en fecha: {DateTime.Now:dd/MM/yyyy}; " +
                            $"y hora: {DateTime.Now:hh/mm}. " +
                            $"se encuentran al {resources[0]}%, {resources[1]}%, {resources[2]}%," +
                            $"de su uso superando el límite del 80%, 70%, 50%, respectivamente.");
                    }
                }
                else
                {
                    foreach (var suscriber in suscribers)
                    {
                        _emailHandling.SendEmail(suscriber.Mail, "Aumento en la Memoria Ram",
                            $"La memoria ram, en fecha: {DateTime.Now:dd/MM/yyyy}; " +
                            $"y hora: {DateTime.Now:hh/mm}. está al {resources[0]}% " +
                            $"de su uso superando el límite del 80%.");
                    }
                }

            }
            else { }

        }

    }
}
