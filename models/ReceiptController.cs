using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.Cms;
using System.Data.Entity;
using iCantine.models;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace iCantine.models
{
    internal class ReceiptController
    {
        public ReceiptController()
        {
        }

        public bool saveReceipt(Context context, Receipt receipt, Menu menu, Client client, Plate plate, List<Extra> extras)
        {
            try
            {
                List<ItemReceipt> items = new List<ItemReceipt>();
                ItemReceipt itemReceipt = new ItemReceipt();


                if (client is Student)
                {
                    itemReceipt = new ItemReceipt(plate.Description.ToString(), menu.PriceStudent);
                }
                else
                {
                    itemReceipt = new ItemReceipt(plate.Description.ToString(), menu.PriceProf);
                }
                items.Add(itemReceipt);


                foreach (var extra in extras)
                {
                    itemReceipt = new ItemReceipt(extra.Description, extra.Price);
                    items.Add(itemReceipt);
                }


                receipt.Clients = client;
                receipt.Menus = menu;
                receipt.ItemReceipts = items;

                context.Receipts.Add(receipt);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save receipt " + ex.Message);
                return false;
            }
            return true;
        }

        public Receipt loadReceipt(Context context, Client client)
        {
            var queryReceipts = context.Receipts.Where(
            r =>
            r.Clients.idUser == client.idUser).Include(r => r.ItemReceipts)
             .OrderByDescending(r => r.idReceipt)
             .FirstOrDefault();
            return (Receipt)queryReceipts;
        }

        public void genReceipt(Receipt receipt)
        {
            string path = @"../../Receipts/" + receipt.Clients.name.ToString() + "-" + receipt.idReceipt + ".txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("ICantina");
                sw.WriteLine("Recibo de marcação de reserva");
                sw.WriteLine("Cliente: " + receipt.Clients.name);
                sw.WriteLine("NIF: " + receipt.Clients.nif);
                sw.WriteLine("Data: " + receipt.Menus.Data.ToString());
                sw.WriteLine("Menu: " + receipt.Menus.DisplayMenu);
                sw.WriteLine("Reserva: ");

                foreach (var item in receipt.ItemReceipts)
                {
                    sw.WriteLine("\t" + item.ToString());
                }
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("Total: " + receipt.Total);
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("=========================================================================");


                sw.Close();
            }
        }
        public void genInvoice(Receipt receipt)
        {
            string path = @"../../Invoices/" + receipt.Clients.name.ToString() + "-" + receipt.idReceipt + ".pdf";

            Document document = new Document();

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

                document.Open();
                document.Add(new Paragraph("ICantina"));
                document.Add(new Paragraph("Recibo de marcação de reserva"));
                document.Add(new Paragraph("Cliente: " + receipt.Clients.name));
                document.Add(new Paragraph("NIF: " + receipt.Clients.nif));
                document.Add(new Paragraph("Data: " + receipt.Menus.Data.ToString()));
                document.Add(new Paragraph(""));
                document.Add(new Paragraph("Menu: " + receipt.Menus.DisplayMenu));
                document.Add(new Paragraph("Reserva: "));
                foreach (var item in receipt.ItemReceipts)
                {
                    document.Add(new Paragraph("\t" + item.Description));
                }
                document.Add(new Paragraph(""));
                document.Add(new Paragraph(""));
                document.Add(new Paragraph("Total: " + receipt.Total));
                document.Add(new Paragraph(""));
                document.Add(new Paragraph(""));
                document.Add(new Paragraph("========================================================================="));

            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }
            finally
            {
                document.Close();
            }
        }
    }
}
