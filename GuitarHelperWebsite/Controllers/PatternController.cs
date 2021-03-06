﻿using GuitarHelperWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GuitarHelperWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatternController : ControllerBase
    {
        private List<Pattern> _patterns;

        public PatternController()
        {
            LoadPatterns();
        }

        // GET: api/Pattern
        [HttpGet]
        public IEnumerable<Pattern> Get()
        {
            return _patterns;
        }

        public void LoadPatterns()
        {
            _patterns = new List<Pattern>
            {
                new Pattern("Major / Ionian", "1,2,3,4,5,6,7"),
                new Pattern("Dorian", "1,2,b3,4,5,6,b7"),
                new Pattern("Phrygian", "1,b2,b3,4,5,b6,b7"),
                new Pattern("Lydian", "1,2,3,s4,5,6,7"),
                new Pattern("Mixolydian", "1,2,3,4,5,6,b7"),
                new Pattern("Aeolian", "1,2,b3,4,5,b6,b7"),
                new Pattern("Locrian", "1,b2,b3,4,b5,b6,b7"),
                new Pattern("Harmonic Minor", "1,2,b3,4,5,b6,7"),
                new Pattern("Melodic Minor (Ascending)", "1,2,b3,4,5,6,7"),
                new Pattern("Melodic Minor (Descending)", "1,2,b3,4,5,b6,b7"),
                new Pattern("Chromatic", "1,b2,2,b3,3,4,b5,5,s5,6,b7,7"),
                new Pattern("Whole Tone", "1,2,3,s4,s5,b7"),
                new Pattern("Pentatonic Major", "1,2,3,5,6"),
                new Pattern("Pentatonic Minor", "1,b3,4,5,b7"),
                new Pattern("Pentatonic Blues", "1,b3,4,b5,5,b7"),
                new Pattern("Pentatonic Neutral", "1,2,4,5,b7"),
                new Pattern("Octatonic (H-W)", "1,b2,b3,3,b5,5,6,b7"),
                new Pattern("Octatonic (W-H)", "1,2,b3,4,b5,b6,6,7"),
                new Pattern("Lydian Augmented", "1,2,3,s4,s5,6,7"),
                new Pattern("Lydian Minor", "1,2,3,s4,5,b6,b7"),
                new Pattern("Lydian Diminished", "1,2,b3,s4,5,6,7"),
                new Pattern("Bebop Major", "1,2,3,4,5,6,7"),
                new Pattern("Bebop Minor", "1,2,3,4,5,6,7"),
                new Pattern("Bebop Half Dominant", "1,2,3,4,5,6,7"),
                new Pattern("Blues Variation 1", "1,2,3,4,5,6,7"),
                new Pattern("Blues Variation 2", "1,2,3,4,5,6,7"),
                new Pattern("Blues Variation 3", "1,2,3,4,5,6,7"),
                new Pattern("Mixo-Blues", "1,2,3,4,5,6,7"),
                new Pattern("Major Blues Scale", "1,2,3,4,5,6,7"),
                new Pattern("Dominant Pentatonic", "1,2,3,4,5,6,7"),
                new Pattern("Chinese 2", "1,2,3,4,5,6,7"),
                new Pattern("Hirajoshi 2", "1,2,3,4,5,6,7"),
                new Pattern("Iwato", "1,2,3,4,5,6,7"),
                new Pattern("Japanese (in sen)", "1,2,3,4,5,6,7"),
                new Pattern("Kumoi 2", "1,2,3,4,5,6,7"),
                new Pattern("Pelog", "1,2,3,4,5,6,7"),
                new Pattern("Locrian 6", "1,2,3,4,5,6,7"),
                new Pattern("Ionian s5", "1,2,3,4,5,6,7"),
                new Pattern("Dorian s4", "1,2,3,4,5,6,7"),
                new Pattern("Phrygian Major", "1,2,3,4,5,6,7"),
                new Pattern("Lydian s2", "1,2,3,4,5,6,7"),
                new Pattern("Ultralociran", "1,2,3,4,5,6,7"),
                new Pattern("Moorish Phrygian", "1,2,3,4,5,6,7"),
                new Pattern("Algerian", "1,2,3,4,5,6,7"),
                new Pattern("Altered", "1,2,3,4,5,6,7"),
                new Pattern("Arabian (a)", "1,2,3,4,5,6,7"),
                new Pattern("Arabian (b)", "1,2,3,4,5,6,7"),
                new Pattern("Augmented", "1,2,3,4,5,6,7"),
                new Pattern("Auxiliary Diminished", "1,2,3,4,5,6,7"),
                new Pattern("Auxiliary Augmented", "1,2,3,4,5,6,7"),
                new Pattern("Auxiliary Diminished Blues", "1,2,3,4,5,6,7"),
                new Pattern("Balinese", "1,2,3,4,5,6,7"),
                new Pattern("Blues", "1,2,3,4,5,6,7"),
                new Pattern("Byzantine", "1,2,3,4,5,6,7"),
                new Pattern("Chinese", "1,2,3,4,5,6,7"),
                new Pattern("Chinese Mongolian", "1,2,3,4,5,6,7"),
                new Pattern("Diatonic", "1,2,3,4,5,6,7"),
                new Pattern("Diminished", "1,2,3,4,5,6,7"),
                new Pattern("Diminished, Half", "1,2,3,4,5,6,7"),
                new Pattern("Diminished, Whole", "1,2,3,4,5,6,7"),
                new Pattern("Diminished Whole Tone", "1,2,3,4,5,6,7"),
                new Pattern("Dominant 7th", "1,2,3,4,5,6,7"),
                new Pattern("Double Harmonic", "1,2,3,4,5,6,7"),
                new Pattern("Egyptian", "1,2,3,4,5,6,7"),
                new Pattern("Eight Tone Spanish", "1,2,3,4,5,6,7"),
                new Pattern("Enigmatic", "1,2,3,4,5,6,7"),
                new Pattern("Ethiopian (A raray)", "1,2,3,4,5,6,7"),
                new Pattern("Ethiopian (Geez & Ezel", "1,2,3,4,5,6,7"),
                new Pattern("Half Diminished (Locrian)", "1,2,3,4,5,6,7"),
                new Pattern("Half Diminished s2 (Locrian s2)", "1,2,3,4,5,6,7"),
                new Pattern("Hawaiian", "1,2,3,4,5,6,7"),
                new Pattern("Hindu", "1,2,3,4,5,6,7"),
                new Pattern("Hindustan", "1,2,3,4,5,6,7"),
                new Pattern("Hirajoshi", "1,2,3,4,5,6,7"),
                new Pattern("Hungarian Major", "1,2,3,4,5,6,7"),
                new Pattern("Hungarian Gypsy", "1,2,3,4,5,6,7"),
                new Pattern("Hungarian Gypsy Persian", "1,2,3,4,5,6,7"),
                new Pattern("Hungarian Minor", "1,2,3,4,5,6,7"),
                new Pattern("Japanese (A)", "1,2,3,4,5,6,7"),
                new Pattern("Japanese (B)", "1,2,3,4,5,6,7"),
                new Pattern("Japanese (Ichikosucho)", "1,2,3,4,5,6,7"),
                new Pattern("Japanese (Taishikicho)", "1,2,3,4,5,6,7"),
                new Pattern("Javaneese", "1,b2,b3,4,5,6,b7"),
                new Pattern("Jewish (Adonai Malakh)", "1,2,3,4,5,6,7"),
                new Pattern("Jewish (Ahaba Rabba)", "1,2,3,4,5,6,7"),
                new Pattern("Jewish (Magen Abot)", "1,2,3,4,5,6,7"),
                new Pattern("Kumoi", "1,2,3,4,5,6,7"),
                new Pattern("Leading Whole Tone", "1,2,3,4,5,6,7"),
                new Pattern("Major Locrian", "1,2,3,4,5,6,7"),
                new Pattern("Mohammedan", "1,2,3,4,5,6,7"),
                new Pattern("Natural (Pure) Minor", "1,2,3,4,5,6,7"),
                new Pattern("Neopolitan", "1,2,3,4,5,6,7"),
                new Pattern("Neopolitan Major", "1,2,3,4,5,6,7"),
                new Pattern("Neopolitan Minor", "1,2,3,4,5,6,7"),
                new Pattern("Nine Tone Scale", "1,2,3,4,5,6,7"),
                new Pattern("Oriental (a)", "1,2,3,4,5,6,7"),
                new Pattern("Oriental (b)", "1,2,3,4,5,6,7"),
                new Pattern("Overtone", "1,2,3,4,5,6,7"),
                new Pattern("Overtone Dominant", "1,2,3,4,5,6,7"),
                new Pattern("Pelog", "1,2,3,4,5,6,7"),
                new Pattern("Persian", "1,2,3,4,5,6,7"),
                new Pattern("Prometheus", "1,2,3,4,5,6,7"),
                new Pattern("Prometheus Neopolitan", "1,2,3,4,5,6,7"),
                new Pattern("Roumanian Minor", "1,2,3,4,5,6,7"),
                new Pattern("Six Tone Symmetrical", "1,2,3,4,5,6,7"),
                new Pattern("Spanish Gypsy", "1,b2,3,4,5,b6,b7"),
                new Pattern("Super Locrian", "1,2,3,4,5,6,7"),
                new Pattern("Moorish Phrygian", "1,2,3,4,5,6,7")
            };
        }
    }
}