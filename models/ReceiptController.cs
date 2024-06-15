﻿using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    internal class ReceiptController
    {
        public void genReceipt(Reservation reservation)
        {
            string filePath = @"../../";
            string fileName = reservation.Menus.Data.ToString() + "-" + reservation.Clients.name.ToString();
            string path = filePath + fileName + ".txt";

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            using (StreamWriter reciept = File.AppendText(path))
            {
                reciept.WriteLine("ICantina");
                reciept.WriteLine("Recibo de marcação de reserva");
                reciept.WriteLine("Cliente: " + reservation.Clients.name);
                reciept.WriteLine("NIF: " + reservation.Clients.nif);
                reciept.WriteLine("Data: " + reservation.Menus.Data.ToString());
                reciept.WriteLine("Reserva");
                reciept.WriteLine("Prato: " + reservation.Plates.Description);
                reciept.WriteLine("Extras: ");
                foreach (var item in reservation.Extras)
                {
                    reciept.WriteLine("\t" + item.Description);
                }
                if (reservation.Clients is Student)
                {
                    reciept.WriteLine("Preço : " + reservation.Menus.PriceStudent);
                }
                else
                {
                    reciept.WriteLine("Preço : " + reservation.Menus.PriceStudent);
                }

                reciept.Close();
            }
        }
        public void generateInvoice(Reservation reservation)
        {
            string filePath = @"../../";
            string fileName = reservation.Menus.Data.ToString() + "-" + reservation.Clients.name.ToString();
            string path = filePath + fileName + ".txt";

            Document document = new Document();

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

                document.Open();
                document.Add(new Paragraph("ICantina"));
                document.Add(new Paragraph("Recibo de marcação de reserva"));
                document.Add(new Paragraph("Cliente: " + reservation.Clients.name));
                document.Add(new Paragraph("NIF: " + reservation.Clients.nif));
                document.Add(new Paragraph("Data: " + reservation.Menus.Data.ToString()));
                document.Add(new Paragraph("Reserva"));
                document.Add(new Paragraph("Prato: " + reservation.Plates.Description));
                document.Add(new Paragraph("Extras: "));
                foreach (var item in reservation.Extras)
                {
                    document.Add(new Paragraph("\t" + item.Description));
                }
                if (reservation.Clients is Student)
                {
                    document.Add(new Paragraph("Preço : " + reservation.Menus.PriceStudent));
                }
                else
                {
                    document.Add(new Paragraph("Preço : " + reservation.Menus.PriceStudent));
                }
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
