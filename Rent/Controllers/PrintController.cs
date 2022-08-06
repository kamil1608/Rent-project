using Microsoft.AspNet.Identity;
using Rent.Models.Domains;
using Rent.Models.Repositories;
using Rotativa;
using Rotativa.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent.Controllers
{
    public class PrintController : Controller
    {
        private OrderRepository _orderRepository = new OrderRepository();

        public ActionResult OrderToPdf(int id)
        {
            var handle = Guid.NewGuid().ToString();
            var userId = User.Identity.GetUserId();
            var order = _orderRepository.GetOrder(id, userId);

            TempData[handle] = GetPdfContent(order);

            return Json(new
            {
                FileGuid = handle,
                FileName = $@"Zamówienie_{order.Id}.pdf"
            });
        }


        private byte[] GetPdfContent(Order order)
        {
            var pdfResult = new ViewAsPdf(@"OrderTemplate", order)
            {
                PageSize = Size.A4,
                PageOrientation = Orientation.Portrait
            };

            return pdfResult.BuildFile(ControllerContext);
        }


        public ActionResult DownloadOrderPdf(string fileGuid, string fileName)
        {
            if (TempData[fileGuid] == null)
                throw new Exception("Błąd przy próbie eksportu faktury do PDF");

            var data = TempData[fileGuid] as byte[];
            return File(data, "application/pdf", fileName);

        }

    }
}