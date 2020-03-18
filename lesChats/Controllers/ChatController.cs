using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lesChats.Models;

namespace lesChats.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> meuteDeChats = Chat.GetMeuteDeChats();

        private Chat getChatById(int id)
        {
            var chat = meuteDeChats.FirstOrDefault(c => c.Id == id);
            return chat;
        }

        // GET: Chat
        public ActionResult Index()
        {
            return View(meuteDeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            var chat = getChatById(id);
            return View(chat);
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var chat = getChatById(id);
            return View(chat);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chat = getChatById(id);
                meuteDeChats.Remove(chat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
