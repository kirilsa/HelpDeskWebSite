using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDeskWebSite.Data;
using HelpDeskWebSite.Models;

namespace HelpDeskWebSite.Controllers
{
    public class MailgunController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MailgunController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mailgun
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Emails.Include(e => e.Conversation).Include(e => e.Recipient).Include(e => e.Sender);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Mailgun/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Emails == null)
            {
                return NotFound();
            }

            var email = await _context.Emails
                .Include(e => e.Conversation)
                .Include(e => e.Recipient)
                .Include(e => e.Sender)
                .FirstOrDefaultAsync(m => m.EmailId == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // GET: Mailgun/Create
        public IActionResult Create()
        {
            ViewData["ConversationId"] = new SelectList(_context.Conversations, "ConversationId", "ConversationId");
            ViewData["RecipientId"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["SenderId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Mailgun/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmailId,SenderId,RecipientId,Subject,Body,SentDate,IsIncoming,ConversationId")] Email email)
        {
            if (ModelState.IsValid)
            {
                _context.Add(email);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConversationId"] = new SelectList(_context.Conversations, "ConversationId", "ConversationId", email.ConversationId);
            ViewData["RecipientId"] = new SelectList(_context.Users, "UserId", "UserId", email.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Users, "UserId", "UserId", email.SenderId);
            return View(email);
        }

        // GET: Mailgun/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Emails == null)
            {
                return NotFound();
            }

            var email = await _context.Emails.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }
            ViewData["ConversationId"] = new SelectList(_context.Conversations, "ConversationId", "ConversationId", email.ConversationId);
            ViewData["RecipientId"] = new SelectList(_context.Users, "UserId", "UserId", email.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Users, "UserId", "UserId", email.SenderId);
            return View(email);
        }

        // POST: Mailgun/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmailId,SenderId,RecipientId,Subject,Body,SentDate,IsIncoming,ConversationId")] Email email)
        {
            if (id != email.EmailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(email);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailExists(email.EmailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConversationId"] = new SelectList(_context.Conversations, "ConversationId", "ConversationId", email.ConversationId);
            ViewData["RecipientId"] = new SelectList(_context.Users, "UserId", "UserId", email.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Users, "UserId", "UserId", email.SenderId);
            return View(email);
        }

        // GET: Mailgun/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Emails == null)
            {
                return NotFound();
            }

            var email = await _context.Emails
                .Include(e => e.Conversation)
                .Include(e => e.Recipient)
                .Include(e => e.Sender)
                .FirstOrDefaultAsync(m => m.EmailId == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // POST: Mailgun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Emails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Emails'  is null.");
            }
            var email = await _context.Emails.FindAsync(id);
            if (email != null)
            {
                _context.Emails.Remove(email);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailExists(int id)
        {
          return (_context.Emails?.Any(e => e.EmailId == id)).GetValueOrDefault();
        }
    }
}
