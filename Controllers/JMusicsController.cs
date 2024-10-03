using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JMusicBlog.Data;
using JMusicBlog.Models;

namespace JMusicBlog.Controllers
{
    public class JMusicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JMusicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JMusics
        public async Task<IActionResult> Index()
        {
            return View(await _context.JMusic.ToListAsync()); //SHOW ALL JMUSIC TABLES

        }
        // GET: JMusics/ShowSearchForm
        //We created a ShowSearchForm asp-action 
        public async Task<IActionResult> ShowSearchForm()
        {
            return View(); 
        }

        //PoSt: JMusics/ShowSearchResultsSong
        //We created a ShowSearchResults asp-action in ShowSearchForm
        public async Task<IActionResult> ShowSearchResults(String SearchPhraseSong, String SearchPhraseArtist)
        {
            // If both SearchPhrase are provided
            if (!string.IsNullOrEmpty(SearchPhraseSong) && !string.IsNullOrEmpty(SearchPhraseArtist))
            {
                return View("Index", await _context.JMusic
                    .Where(j => j.Song.Contains(SearchPhraseSong) || j.Artist.Contains(SearchPhraseArtist))
                    .ToListAsync());
            }
            // If ONLY SearchPhraseSong is provided
            else if (!string.IsNullOrEmpty(SearchPhraseSong))
            {
                return View("Index", await _context.JMusic
                    .Where(j => j.Song.Contains(SearchPhraseSong))
                    .ToListAsync());
            }
            // If If ONLY SearchPhraseArtist is provided
            else if (!string.IsNullOrEmpty(SearchPhraseArtist))
            {
                return View("Index", await _context.JMusic
                    .Where(j => j.Artist.Contains(SearchPhraseArtist))
                    .ToListAsync());
            }
            // If no search phrase is provided
            else
            {
                return View("ShowSearchForm");
            }
        }

        // GET: JMusics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jMusic = await _context.JMusic
                .FirstOrDefaultAsync(m => m.JMusicId == id);
            if (jMusic == null)
            {
                return NotFound();
            }

            return View(jMusic);
        }


        // GET: JMusics/Lyrics/5
        public async Task<IActionResult> Lyrics(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jMusic = await _context.JMusic
                .FirstOrDefaultAsync(m => m.JMusicId == id);
            if (jMusic == null)
            {
                return NotFound();
            }
 
            return View(jMusic);
        }




        // GET: JMusics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JMusics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JMusicId,Artist,Song,Blog, Lyrics")] JMusic jMusic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jMusic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jMusic);
        }

        // GET: JMusics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jMusic = await _context.JMusic.FindAsync(id);
            if (jMusic == null)
            {
                return NotFound();
            }
            return View(jMusic);
        }

        // POST: JMusics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JMusicId,Artist,Song,Blog, Lyrics")] JMusic jMusic)
        {
            if (id != jMusic.JMusicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jMusic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JMusicExists(jMusic.JMusicId))
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
            return View(jMusic);
        }

        // GET: JMusics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jMusic = await _context.JMusic
                .FirstOrDefaultAsync(m => m.JMusicId == id);
            if (jMusic == null)
            {
                return NotFound();
            }

            return View(jMusic);
        }

        // POST: JMusics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jMusic = await _context.JMusic.FindAsync(id);
            if (jMusic != null)
            {
                _context.JMusic.Remove(jMusic);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JMusicExists(int id)
        {
            return _context.JMusic.Any(e => e.JMusicId == id);
        }
    }
}
